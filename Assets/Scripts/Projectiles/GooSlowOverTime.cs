using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GooSlowOverTime : MonoBehaviour
{
    [SerializeField] private ProjectileStats projectileStats;
    [SerializeField] private float duration;
    [Range(0,1)] private float slowAmount; 

    private void Awake()
    {
        InvokeRepeating("SlowOverTime", 0.5f, 1.0f);
        Destroy(gameObject, duration);
    }

    private void SlowOverTime()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position, projectileStats.radius, projectileStats.targetLayer);
        foreach (Collider2D enemy in enemies)
        {
            // Take enemy move speed and reduce by however much
            Debug.Log("Slow enemy down");
        }
    }
}
