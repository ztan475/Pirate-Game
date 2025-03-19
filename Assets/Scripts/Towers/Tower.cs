using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private TowerStats towerStats;
    [SerializeField] private GameObject projectileSpawnPoint;
    
    private CircleCollider2D towerCollider2D;
    private ArrayList enemyList = new ArrayList();
    private BasicEnemy currentEnemy;
    private bool canShoot;
    private int health;

    private void Start()
    {
        towerCollider2D = GetComponent<CircleCollider2D>();
        towerCollider2D.radius = towerStats.range;
        health = towerStats.health;
        canShoot = true;
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
        currentEnemy = (BasicEnemy) enemyList[0];
    }

    // Tracks all enemies within range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            BasicEnemy newEnemy = collision.GetComponent<BasicEnemy>();
            enemyList.Add(newEnemy);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            BasicEnemy enemy = collision.GetComponent<BasicEnemy>();
            if(enemyList.Contains(enemy))
                enemyList.Remove(enemy);
        }
    }

    private void ShootEnemy()
    {
        
        if(currentEnemy != null && canShoot)
        {
            Debug.Log("Attempting Shot");
            GameObject projectile = Instantiate(towerStats.projectilePrefab, projectileSpawnPoint.transform.position, Quaternion.identity);
            projectile.GetComponent<Projectile>().SetEnemy(currentEnemy);
            StartCoroutine(ReloadProjectile());
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
