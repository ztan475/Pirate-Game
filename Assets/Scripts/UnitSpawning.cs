using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawning : MonoBehaviour
{
    [Header("Gold")]
    [SerializeField] private GameObject goldObject;

    [Header("Unit Prefabs")]
    [SerializeField] private GameObject allyPrefab;
    [SerializeField] private GameObject allyRangedPrefab;
    [SerializeField] private GameObject allyShielderPrefab;
    [SerializeField] private GameObject enemyMeleePrefab;
    [SerializeField] private GameObject enemyRangedPrefab;
    [SerializeField] private GameObject enemyShielderPrefab;
    [SerializeField] private GameObject enemyCartPrefab;

    [Header("Spawn Location")]
    [SerializeField] private GameObject allySpawnPoint;
    [SerializeField] private GameObject allySpawnPoint2;
    [SerializeField] private GameObject enemySpawnPoint;
    [SerializeField] private GameObject enemySpawnPoint2;
    private bool useSecondAllySpawn = false;

    private CurrencySystem currencySystem;

    // Start is called before the first frame update
    void Start()
    {
        currencySystem = goldObject.GetComponent<CurrencySystem>();
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

    public void spawnShielderEnemyUnit()
    {
        Instantiate(enemyShielderPrefab, enemySpawnPoint.transform.position, Quaternion.identity);
    }

    public void spawnCartEnemyUnit()
    {
        Instantiate(enemyCartPrefab, enemySpawnPoint.transform.position, Quaternion.identity);
    }

    public void spawnMeleeEnemyUnit2()
    {
        Instantiate(enemyMeleePrefab, enemySpawnPoint2.transform.position, Quaternion.identity);
    }

    public void spawnRangedEnemyUnit2()
    {
        Instantiate(enemyRangedPrefab, enemySpawnPoint2.transform.position, Quaternion.identity);
    }

    public void spawnShielderEnemyUnit2()
    {
        Instantiate(enemyShielderPrefab, enemySpawnPoint2.transform.position, Quaternion.identity);
    }

    public void spawnCartEnemyUnit2()
    {
        Instantiate(enemyCartPrefab, enemySpawnPoint2.transform.position, Quaternion.identity);
    }

    public void spawnMeleeAllyUnit()
    {
        if (currencySystem.CheckGold() >= 10)
        {
            Instantiate(allyPrefab, GetAllySpawnPoint().position, Quaternion.identity);
            currencySystem.RemoveCoins(10);
        }
    }

    public void spawnRangedAllyUnit()
    {
        if (currencySystem.CheckGold() >= 15)
        {
            Instantiate(allyRangedPrefab, GetAllySpawnPoint().position, Quaternion.identity);
            currencySystem.RemoveCoins(15);
        }
    }

    public void spawnShielderAllyUnit()
    {
        if (currencySystem.CheckGold() >= 20)
        {
            Instantiate(allyShielderPrefab, GetAllySpawnPoint().position, Quaternion.identity);
            currencySystem.RemoveCoins(20);
        }
    }
    public void ToggleAllySpawnPoint()
    {
        useSecondAllySpawn = !useSecondAllySpawn;
        Debug.Log("Switched Spawn Point.");
    }

    private Transform GetAllySpawnPoint()
    {
        if (useSecondAllySpawn && allySpawnPoint2 != null)
        {
            return allySpawnPoint2.transform;
            Debug.Log("This code never executes.");
        }
        return allySpawnPoint.transform;
    }

}
