using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Tower Shop Setting")]
public class TowerShopSettings : ScriptableObject
{
    public GameObject towerPrefab;
    public int towerCost;
    public int sellCost;
    public Sprite towerShopSprite;
}
