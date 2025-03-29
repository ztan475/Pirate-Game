using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GooSlowOverTime : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;
    [SerializeField] private float duration;
    [Range(0,1)] public float slowAmount; 

    private Dictionary<GameObject,float> enemyList = new Dictionary<GameObject,float>();

    private void Awake()
    {
        Destroy(gameObject, duration);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NavMeshAgent>().speed *= slowAmount;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<NavMeshAgent>().speed /= slowAmount;
        }
    }
}
