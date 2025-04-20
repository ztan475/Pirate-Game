using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSchedule1 : MonoBehaviour
{
    private UnitSpawning spawner;

    // Start is called before the first frame update
    void Start()
    {
        spawner = GetComponent<UnitSpawning>();
        StartCoroutine(SpawnEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemies()
    {
        yield return null;
        while (true)
        {
            spawner.spawnMeleeEnemyUnit();
            spawner.spawnMeleeEnemyUnit();
            spawner.spawnMeleeEnemyUnit();
            spawner.spawnMeleeEnemyUnit();
            spawner.spawnRangedEnemyUnit();
            yield return new WaitForSeconds(8);
        }
    }
}
