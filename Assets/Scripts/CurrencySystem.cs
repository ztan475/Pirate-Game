using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem Instance;
    [SerializeField] private int startingGold;
    public int totalGold;
    public static int totalGoldPublic;
    public GameObject goldText;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
       
        totalGold = startingGold;
         totalGoldPublic=totalGold;
    }

    private void Update()
    {
        totalGold=totalGoldPublic;
        if (goldText != null)
        {
            goldText.GetComponentInChildren<TextMeshProUGUI>().SetText($"Gold:{totalGold}");
        }
    }

    public void AddCoins(int amount)
    {
        totalGold += amount;
        totalGoldPublic = totalGold;
        
    }

    public void RemoveCoins(int amount)
    {
        totalGold -= amount;
         totalGoldPublic = totalGold;
         
    }

    public int CheckGold()
    {
        return totalGold;
    }
}
