using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public BaseHealth playerBase;
    public BaseHealth enemyBase;

    void Update()
    {
        if (playerBase != null && enemyBase != null)
        {
            Debug.Log("Player Base Health: " + playerBase.currentHealth);
            Debug.Log("Enemy Base Health: " + enemyBase.currentHealth);
        }
    }
}