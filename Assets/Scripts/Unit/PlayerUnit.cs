using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerUnit : Unit
{

    // Start is called before the first frame update
    void Start()
    {
        targetTag = "Enemy";
        base.Init();
    }

    // Update is called once per frame
    void Update()
    {
        base.ScanForTargets();
    }
}
