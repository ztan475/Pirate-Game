using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;

    // private float minDistanceToDealDamage = 0.1f;
    private Tower currentTower;
    private float minDistanceToDealDamage = 0.1f;
    private Unit enemyTarget;
    private BoxCollider2D boxCollider;

    protected virtual void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();

        // Set collider to size of sprite
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null && boxCollider != null)
        {
            boxCollider.size = spriteRenderer.bounds.size;
        }
    }

    protected virtual void Update()
    {
        if(enemyTarget != null)
        {
            MoveProjectile();
            RotateProjectile();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    protected virtual void MoveProjectile()
    {
        transform.position = Vector2.MoveTowards(transform.position, enemyTarget.transform.position, projectileStats.projectileVelocity * Time.deltaTime);
        float distanceBetweenEnemyTarget = (enemyTarget.transform.position - transform.position).magnitude;
        /*if(distanceBetweenEnemyTarget < minDistanceToDealDamage)
        {
            enemyTarget.TakeDamage(projectileStats.damage);
            Destroy(gameObject);
        }*/
    }

    private void RotateProjectile()
    {
        Vector3 enemyPos = enemyTarget.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
        transform.Rotate(0f,0f,angle);
    }

    public void SetEnemy(Unit enemy)
    {
        enemyTarget = enemy;
    }

    public void SetTower(Tower tower)
    {
        currentTower = tower;
    }

    public Tower GetTower()
    {
        return currentTower;
    }
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == enemyTarget.gameObject)
        {
            if (enemyTarget.type != UnitType.Shielder)
            {
                enemyTarget.TakeDamage(projectileStats.damage);
            }
                
            Destroy(gameObject);
        }
    }*/
}
