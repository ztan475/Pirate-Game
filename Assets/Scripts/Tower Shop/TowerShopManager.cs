using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerShopManager : MonoBehaviour
{
    [SerializeField] private GameObject towerCard;
    [SerializeField] private GameObject towerPanelContainer;
    [SerializeField] private List<TowerShopSettings> allTowers;

    private void Start()
    {
        //SetUpTowerCards();
    }

    /*private void SetUpTowerCards()
    {
        foreach(TowerShopSettings towerSettings in allTowers)
        {
            GameObject newCard = towerCard;
            newCard.GetComponent<TowerShopCard>().SetupTowerButton(towerSettings);
            Instantiate(newCard, towerPanelContainer.transform);
        }
    }*/
}
