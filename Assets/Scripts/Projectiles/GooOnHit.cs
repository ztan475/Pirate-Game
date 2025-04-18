using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooOnHit : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;
    public int damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemey hit");
            collision.gameObject.GetComponent<EnemyUnit>().TakeDamage(damage);
            GameObject slowField = Instantiate(projectileStats.projectileOnHit, transform.position, Quaternion.identity);
            Destroy(gameObject, 0.05f);
        }
    }
}
