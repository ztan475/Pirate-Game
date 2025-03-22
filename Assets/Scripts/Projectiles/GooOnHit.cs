using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooOnHit : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<BasicEnemy>().DealDamage(projectileStats.damage);
            GameObject slowField = Instantiate(projectileStats.projectileOnHit, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.05f);
        }
    }
}
