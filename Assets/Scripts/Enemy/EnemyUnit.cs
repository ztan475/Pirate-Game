using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUnit : Unit
{
    private GameObject currentTarget = null;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetTag = "Ally";
        BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(range * 2, range * 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }

        transform.rotation = Quaternion.identity;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Ally");
        GameObject targetObject = null;
        foreach (GameObject gameObject in gameObjects)
        {
            if (targetObject == null)
            {
                targetObject = gameObject;
            }
            else if (Vector3.Distance(gameObject.transform.position, transform.position) < Vector3.Distance(targetObject.transform.position, transform.position))
            {
                targetObject = gameObject;
            }
        }
        if (currentTarget != targetObject)
        {
            Debug.Log("Changing target");
            currentTarget = targetObject;
        }

        if (targetObject)
        {
            agent.SetDestination(targetObject.transform.position);
        }
    }
}
