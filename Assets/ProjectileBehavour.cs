using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileBehavour : MonoBehaviour
{
    public float speed;
    public GameObject target;
    private void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
//TODO correct prefab behaviour to get enemy as a target