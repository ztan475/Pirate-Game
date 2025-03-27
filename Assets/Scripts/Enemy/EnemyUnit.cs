using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUnit : Unit
{
    private GameObject currentTarget = null;
    public GameObject attackArea;
    private Coroutine attackCoroutine;

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
        else
        {
            agent.isStopped = true;
            agent.ResetPath();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag && attackCoroutine == null)
        {
            attackCoroutine = StartCoroutine(SummonAttackAreaRepeat());
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == targetTag && attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
        }
    }

    IEnumerator SummonAttackAreaRepeat()
    {
        while (true)
        {
            SummonAttackArea();
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    void SummonAttackArea()
    {
        // Get direction to the target and rotate sprite (rotate 90 degrees for vertical facing sprite rn)
        Vector3 directionToTarget = (currentTarget.transform.position - transform.position).normalized;
        Vector3 rotatedDirection = new Vector3(-directionToTarget.y, directionToTarget.x, 0);
        Quaternion attackRotation = Quaternion.LookRotation(Vector3.forward, rotatedDirection);

        Vector3 spawnPosition = transform.position + directionToTarget * 0.60f;
        GameObject attack = Instantiate(attackArea, spawnPosition, attackRotation);

        EnemyAttackHitbox enemyAttackHitbox = attack.GetComponent<EnemyAttackHitbox>();
        List<GameObject> alliesHit = enemyAttackHitbox.unitsHit();

        foreach (GameObject obj in alliesHit)
        {
            Unit unit = obj.GetComponent<Unit>();
            unit.TakeDamage(this);
        }
        
        Destroy(attack, 0.5f);
    }
}
