using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCastle : Unit
{

    [SerializeField] GameObject otherCastle;

    void Start()
    {
        //adjust health if desired
        health = 500;
        targetTag = "Enemy";
        BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(range * 2, range * 2);
    }

    //override the summon attack area to be castle-unique
    //larger, potentially more damage?
    void SummonAttackArea()
    {
        Vector3 spawnPosition = Vector3.Normalize(otherCastle.transform.position - gameObject.transform.position) * 1.00f;
        GameObject attack = Instantiate(attackArea, spawnPosition, Quaternion.identity);

        EnemyAttackHitbox enemyAttackHitbox = attack.GetComponent<EnemyAttackHitbox>();
        List<GameObject> unitsHit = enemyAttackHitbox.unitsHit();

        foreach (GameObject obj in unitsHit)
        {
            Unit unit = obj.GetComponent<Unit>();
            unit.TakeDamage(this);
        }
        
        Destroy(attack, 0.5f);
    }
}
