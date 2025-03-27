using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TowerType
{
    Arrow,
    Cannon,
    Goo
}

[CreateAssetMenu(fileName = "Tower Stats")]
public class TowerStats : ScriptableObject
{
    public float range;
    public float reloadTime;
    public int health;
    public GameObject projectilePrefab;
    public int projectileDamage;

    public int sellCost;
    public int upgradeCost;

    public float rangeUpgradeIncrement;
    public float reloadTimeUpgradeIncrement;
    public int healthUpgradeIncrement;
    public int damageUpgradeIncrement;

    public TowerType towerType;

}
