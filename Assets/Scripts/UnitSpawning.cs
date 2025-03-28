using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawning : MonoBehaviour
{
    [Header("Unit Prefabs")]
    [SerializeField] private GameObject allyPrefab;
    [SerializeField] private GameObject allyRangedPrefab;
    [SerializeField] private GameObject enemyMeleePrefab;
    [SerializeField] private GameObject enemyRangedPrefab;

    [Header("Spawn Location")]
    [SerializeField] private GameObject allySpawnPoint;
    [SerializeField] private GameObject enemySpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnMeleeEnemyUnit()
    {
        Instantiate(enemyMeleePrefab, enemySpawnPoint.transform.position, Quaternion.identity);
    }

    public void spawnRangedEnemyUnit()
    {
        Instantiate(enemyRangedPrefab, enemySpawnPoint.transform.position, Quaternion.identity);
    }

    public void spawnMeleeAllyUnit()
    {
        Instantiate(allyPrefab, allySpawnPoint.transform.position, Quaternion.identity);
    }

    public void spawnRangedAllyUnit()
    {
        Instantiate(allyRangedPrefab, allySpawnPoint.transform.position, Quaternion.identity);
    }
}
