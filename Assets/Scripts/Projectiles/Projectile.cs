using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Projectile : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;

    // private float minDistanceToDealDamage = 0.1f;
    private BasicEnemy enemyTarget;
    private Tower currentTower;

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

    public void SetTower(Tower tower)
    {
        currentTower = tower;
    }

    public Tower GetTower()
    {
        return currentTower;
    }
}
