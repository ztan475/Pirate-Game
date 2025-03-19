using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;

    private float minDistanceToDealDamage = 0.1f;
    private BasicEnemy enemyTarget;

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
        if(distanceBetweenEnemyTarget < minDistanceToDealDamage)
        {
            // Replace with whatever damage script
            enemyTarget.DealDamage(projectileStats.damage);
            Destroy(gameObject);
        }
    }

    private void RotateProjectile()
    {
        Vector3 enemyPos = enemyTarget.transform.position - transform.position;
        float angle = Vector3.SignedAngle(transform.up, enemyPos, transform.forward);
        transform.Rotate(0f,0f,angle);
    }

    public void SetEnemy(BasicEnemy enemy)
    {
        enemyTarget = enemy;
    }
}
