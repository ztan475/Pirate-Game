using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem Instance;
    [SerializeField] private int startingGold;
    public int totalGold;

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
    }

    public void AddCoins(int amount)
    {
        totalGold += amount;
    }
    public void RemoveCoins(int amount)
    {
        totalGold -= amount;
    }
}
