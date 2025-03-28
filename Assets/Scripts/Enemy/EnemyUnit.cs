using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUnit : Unit
{

    // Start is called before the first frame update
    void Start()
    {
        targetTag = "Ally";
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

}
