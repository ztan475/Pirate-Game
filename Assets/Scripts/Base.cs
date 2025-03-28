using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    [SerializeField] protected int baseHealth;
    public int Health => health;
    GameObject loseScreen;
    // Start is called before the first frame update
    void Start()
    {
        loseScreen = GameObject.Find("Lose Screen");
        loseScreen.SetActive(false);
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
            loseScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
