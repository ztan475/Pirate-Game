using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOnHit : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BasicEnemy>().DealDamage(projectileStats.damage);
            Destroy(gameObject, 0.05f);
        }
    }
}
