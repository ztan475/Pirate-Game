using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public bool hasTower;
    public GameObject currentTower;

    [SerializeField] private GameObject towerOptionUI;

    private void Start()
    {
        hasTower = false;
        currentTower = null;
        towerOptionUI.SetActive(false);
    }

    public void OpenShop()
    {
        if (!hasTower)
        {
            UIManager.Instance.OpenShop();
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
        towerOptionUI.SetActive(false);
    }
}
