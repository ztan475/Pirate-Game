using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUnit : Unit
{
    private CurrencySystem currencySystem;

    // Start is called before the first frame update
    void Start()
    {
        targetTag = "Ally";
        base.Init();
        currencySystem = GameObject.FindGameObjectWithTag("CurrencySystem").GetComponent<CurrencySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        base.ScanForTargets();
    }

    private void DestroyUnit()
    {
        currencySystem.AddCoins(20);
        Destroy(gameObject);
    }

}
