using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSchedule3 : MonoBehaviour
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
            spawner.spawnRangedEnemyUnit();
            spawner.spawnShielderEnemyUnit();

            spawner.spawnMeleeEnemyUnit2();
            spawner.spawnMeleeEnemyUnit2();
            spawner.spawnRangedEnemyUnit2();
            spawner.spawnCartEnemyUnit2();
            yield return new WaitForSeconds(45);
        }
    }
}
