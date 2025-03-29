using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GooSlowOverTime : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;
    [SerializeField] private float duration;
    [Range(0,1)] private float slowAmount; 

    private Dictionary<GameObject,float> enemyList = new Dictionary<GameObject,float>();

    private void Awake()
    {
        InvokeRepeating("SlowOverTime", 0.5f, 1.0f);
        Destroy(gameObject, duration);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NavMeshAgent>().speed *= slowAmount;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NavMeshAgent>().speed /= slowAmount;
        }
    }
}
