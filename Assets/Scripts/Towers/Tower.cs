using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerStats towerStats;
    [SerializeField] private GameObject projectileSpawnPoint;

    private float reloadTime;
    private int health;
    private GameObject projectilePrefab;
    private int projectileDamage;
    private int upgradeCost;
    public int sellCost;

    private CircleCollider2D towerCollider2D;
    private ArrayList enemyList = new ArrayList();
    private Unit currentEnemy;
    private bool canShoot;
    

    private void Start()
    {
        towerCollider2D = GetComponent<CircleCollider2D>();
        towerCollider2D.radius = towerStats.range;
        health = towerStats.health;
        canShoot = true;
        reloadTime = towerStats.reloadTime;
        projectilePrefab = towerStats.projectilePrefab;
        sellCost = towerStats.sellCost;
        upgradeCost = towerStats.upgradeCost;
        projectileDamage = towerStats.projectileDamage;
    }

    // Update is called once per frame
    void Update()
    {
        GetCurrentEnemy();
        ShootEnemy();
    }

    private void GetCurrentEnemy()
    {
        if(enemyList.Count <= 0)
        {
            currentEnemy = null;
            return;
        }
        currentEnemy = (Unit) enemyList[0];
    }

    // Tracks all enemies within range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Unit newEnemy = collision.GetComponent<Unit>();
            enemyList.Add(newEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Unit enemy = collision.GetComponent<Unit>();
            if(enemyList.Contains(enemy))
                enemyList.Remove(enemy);
        }
    }

    private void ShootEnemy()
    {    
        if(currentEnemy != null && canShoot)
        {
            Debug.Log("Attempting Shot");
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.transform.position, Quaternion.identity);
            SetDamage(projectile);
            Projectile projectileInstance = projectile.GetComponent<Projectile>();
            projectileInstance.SetEnemy(currentEnemy);
            projectileInstance.SetTower(this);
            StartCoroutine(ReloadProjectile());
        }
    }

    private void SetDamage(GameObject projectile)
    {
        switch (towerStats.towerType)
        {
            case TowerType.Arrow:
                projectile.GetComponent<ArrowOnHit>().damage = projectileDamage;
                break;
            case TowerType.Cannon:
                projectile.GetComponent<CannonOnHit>().damage = projectileDamage;
                break;
            case TowerType.Goo:
                projectile.GetComponent<GooOnHit>().damage = projectileDamage;
                break;
        }
    }

    public void UpgradeTower()
    {
        if(CurrencySystem.Instance.totalGold >= upgradeCost)
        {
            towerCollider2D.radius = towerCollider2D.radius + towerStats.rangeUpgradeIncrement;
            health += towerStats.healthUpgradeIncrement;
            reloadTime -= towerStats.reloadTimeUpgradeIncrement;
            projectileDamage += towerStats.damageUpgradeIncrement;
            CurrencySystem.Instance.RemoveCoins(upgradeCost);
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }

    private  IEnumerator ReloadProjectile()
    {
        canShoot = false;
        yield return new WaitForSeconds(towerStats.reloadTime);
        canShoot = true;
    }
}
