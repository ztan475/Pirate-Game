using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class TowerShopCard : MonoBehaviour
{
    [SerializeField] private TowerShopSettings towerSettings;
    [SerializeField] private Image towerImage;
    [SerializeField] private TextMeshProUGUI towerCost;
    [SerializeField] private Button cardButton;

    private void Start()
    {
        
        SetupTowerButton();
    }

    public void SetupTowerButton()
    {
        towerImage.sprite = towerSettings.towerShopSprite;
        towerCost.text = towerSettings.towerCost.ToString();
        cardButton.onClick.AddListener(PlaceTurret);
    }

    public void PlaceTurret()
    {
        if(CurrencySystem.Instance.totalGold >= towerSettings.towerCost)
        {
            GameObject newTower = Instantiate(towerSettings.towerPrefab, UIManager.Instance.GetCurrentNodePos(), Quaternion.identity);
            CurrencySystem.Instance.RemoveCoins(towerSettings.towerCost);
            UIManager.Instance.GetNode().hasTower = true;
            UIManager.Instance.GetNode().currentTower = newTower;
            UIManager.Instance.GetNode().SwitchNodeSprite();
        }
        UIManager.Instance.CloseShop();      
    }
}
