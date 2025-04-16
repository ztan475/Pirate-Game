using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonOnHit : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;
    public int damage;
    private AudioSource explosionAudioSource;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Explode();
            Debug.Log("ksakjdksasada");
            Destroy(gameObject);
        }
        
    }


    private void Explode()
    {
        GameObject explosion = Instantiate(projectileStats.projectileOnHit, transform.position, Quaternion.identity);
        gameObject.GetComponent<CircleCollider2D>().radius *= 10;
        explosionAudioSource = GetComponents<AudioSource>()[0];
        explosionAudioSource.PlayOneShot(explosionAudioSource.clip);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.GetComponent<CircleCollider2D>().bounds.center, gameObject.GetComponent<CircleCollider2D>().radius, LayerMask.GetMask("Enemy"));
        Debug.Log(colliders.Length);
        foreach (var enemy in colliders) {
            EnemyUnit enemyUnit = enemy.GetComponent<EnemyUnit>();
            if(enemyUnit != null)
            {
                enemyUnit.TakeDamage(damage);
            }

        }

        Destroy(explosion, 0.1f);
    }


}
