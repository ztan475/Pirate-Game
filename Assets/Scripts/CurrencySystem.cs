using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrencySystem : MonoBehaviour
{
    public static CurrencySystem Instance;
    [SerializeField] private int startingGold;
    private int totalGold;
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
    }

    private void Update()
    {
        if (goldText != null)
        {
            goldText.GetComponentInChildren<TextMeshProUGUI>().SetText($"Gold:{totalGold}");
        }
    }

    public void AddCoins(int amount)
    {
        totalGold += amount;
    }

    public void RemoveCoins(int amount)
    {
        totalGold -= amount;
    }

    public int CheckGold()
    {
        return totalGold;
    }
}
