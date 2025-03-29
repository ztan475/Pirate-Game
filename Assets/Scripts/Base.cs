using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected GameObject defeatScreen;
    public int Health => health;

    // Start is called before the first frame update
    void Start()
    {
        defeatScreen.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage + " damage dealt to tower. " + health + " health remaining");
        if (health <= 0)
        {
            defeatScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
