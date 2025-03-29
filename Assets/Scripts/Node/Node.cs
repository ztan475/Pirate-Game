using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public bool hasTower;
    public GameObject currentTower;
    public GameObject shopUI;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private GameObject towerOptionUI;
    
    private void Start()
    {
        hasTower = false;
        currentTower = null;
        towerOptionUI.SetActive(false);
        shopUI.SetActive(false);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OpenShop()
    {
        if (!hasTower)
        {
            shopUI.SetActive(true);
            UIManager.Instance.SetCurrentNodePos(gameObject.transform.position);
            UIManager.Instance.SetNode(this);
        }
        else
        {
            if (towerOptionUI.activeSelf)
            {
                towerOptionUI.SetActive(false);
            }
            else
            {
                towerOptionUI.SetActive(true);
            }
        }
    }

    public void UpgradeTower()
    {
        currentTower.GetComponent<Tower>().UpgradeTower();
        towerOptionUI.SetActive(false);
    }

    public void SellTower()
    {
        CurrencySystem.Instance.AddCoins(currentTower.GetComponent<Tower>().sellCost);
        hasTower = false;
        Destroy(currentTower);
        currentTower = null;
        SwitchNodeSprite();
        towerOptionUI.SetActive(false);
    }

    public void SwitchNodeSprite()
    {
        if (spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
        }
        else
        {
            spriteRenderer.enabled = true;
        }
    }
}
