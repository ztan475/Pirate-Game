using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tower Stats")]
public class TowerStats : ScriptableObject
{
    public float range;
    public float reloadTime;
    public int health;
    public GameObject projectilePrefab;
}
