using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Base : MonoBehaviour
{
    public GameObject healthText;

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
        healthText.GetComponent<TextMeshProUGUI>().text = "HP: " + health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage + " damage dealt to tower. " + health + " health remaining");
        if (health <= 0)
        {
            if(gameObject.name!="EnemyBase 2"){
                CurrencySystem.totalGoldPublic=0;
            defeatScreen.SetActive(true);
            Time.timeScale = 0;
            }
             if(gameObject.name=="EnemyBase 2"){
                 transform.position=new Vector3(transform.position.x+50,0,0);
            }
        }
    }
}
