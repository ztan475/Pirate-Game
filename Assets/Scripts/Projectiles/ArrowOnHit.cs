using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowOnHit : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyUnit>().TakeDamage(damage);
            Destroy(gameObject, 0.05f);
        }
    }
}
