using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonOnHit : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;
    public int damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Explode();
            Destroy(gameObject,0.05f);
        }
    }


    private void Explode()
    {
        GameObject explosion = Instantiate(projectileStats.projectileOnHit, transform.position, Quaternion.identity);
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, projectileStats.radius, projectileStats.targetLayer);
        foreach (Collider2D enemy in enemies)
        {
            // enemy.gameObject.GetComponent<BasicEnemy>().DealDamage(damage);
            // Add function to Unit.
            Debug.Log(damage);
        }
        Destroy(explosion, 0.1f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, projectileStats.radius);
    }
}
