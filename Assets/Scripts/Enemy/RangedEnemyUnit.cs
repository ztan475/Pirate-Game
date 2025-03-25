using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyUnit : Unit
{
    private GameObject currentTarget = null;
    public GameObject projectile;
    private Coroutine attackCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetTag = "Ally";
        BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(range * 4, range * 4);
    }

    // Update is called once per frame
    void Update()
    {
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

        if (targetObject && attackCoroutine == null)
        {
            agent.SetDestination(targetObject.transform.position);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag && attackCoroutine == null)
        {
            agent.isStopped = true;
            agent.SetDestination(transform.position);
            attackCoroutine = StartCoroutine(StartShooting());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag && attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
            agent.isStopped = false;
        }
    }

    IEnumerator StartShooting()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    void Shoot()
    {
        Vector3 directionToTarget = (currentTarget.transform.position - transform.position).normalized;
        Quaternion attackRotation = Quaternion.LookRotation(Vector3.forward, directionToTarget);

        Vector3 spawnPosition = transform.position + directionToTarget * 0.30f;
        GameObject attack = Instantiate(projectile, spawnPosition, attackRotation);

        Projectile projectileScript = attack.GetComponent<Projectile>();
        projectileScript.SetEnemy(currentTarget.GetComponent<Unit>()); 
    }
}
