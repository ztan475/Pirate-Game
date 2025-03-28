using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum UnitType
{
    Melee,
    Ranged,
    Shielder
}

public class Unit : MonoBehaviour
{
    [Header("Unit Type and Attack Properties")]
    public UnitType type;
    public GameObject meleeAttackHitbox;
    public GameObject projectile;

    [Header("Unit Stats")]
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected int attack = 10;
    [SerializeField] protected int health = 100;
    [SerializeField] protected float attackSpeed = 1.0f;
    [SerializeField] protected int defense = 0;
    [SerializeField] protected float range = 0.5f;

    protected NavMeshAgent agent;
    protected string targetTag;
    private GameObject currentTarget = null;
    private Coroutine attackCoroutine = null;
    private Animator anim = null;

    public float MoveSpeed => moveSpeed;
    public int Attack => attack;
    public int Health => health;
    

    // Start is called before the first frame update
    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponentInChildren<UnitRange>().SetRange(range);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    protected void Update()
    {
        transform.rotation = Quaternion.identity;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(targetTag);
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
            anim.SetBool("isWalking", true);
        }
        else
        {
            agent.isStopped = true;
            agent.ResetPath();
            anim.SetBool("isWalking", false);
        }
    }

    public void UnitDetected(string collisionTag)
    {
        if (collisionTag == targetTag && attackCoroutine == null)
        {
            agent.isStopped = true;
            agent.ResetPath();
            anim.SetBool("isAttacking", true);
            attackCoroutine = StartCoroutine(StartAttacking()); 
        }
    }

    public void UnitExit(string collisionTag)
    {
        if (collisionTag == targetTag && attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;
            anim.SetBool("isAttacking", false);
        }
    }

    public void TakeDamage(Unit attacker)
    {
        int damage = attacker.Attack;
        health -= damage;
        Debug.Log(damage + " damage dealth. " + health + " health remaining");
        if (health <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log(damage + " damage dealth. " + health + " health remaining");
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        string tag = gameObject.tag;
        Debug.Log("An " + tag + " has died!");
        Destroy(gameObject);
    }

    IEnumerator StartAttacking()
    {
        while (true)
        {
            if (this.type == UnitType.Melee)
            {
                MeleeAttack();
            }
            else if (this.type == UnitType.Ranged)
            {
                RangedAttack();
            }
            
            yield return new WaitForSeconds(attackSpeed);
        }
    }

    void MeleeAttack()
    {
        // Get direction to the target and rotate sprite (rotate 90 degrees for vertical facing sprite rn)
        Vector3 directionToTarget = (currentTarget.transform.position - transform.position).normalized;
        Vector3 rotatedDirection = new Vector3(-directionToTarget.y, directionToTarget.x, 0);
        Quaternion attackRotation = Quaternion.LookRotation(Vector3.forward, rotatedDirection);

        Vector3 spawnPosition = transform.position + directionToTarget * 0.60f;
        GameObject attack = Instantiate(meleeAttackHitbox, spawnPosition, attackRotation);

        MeleeHitbox enemyAttackHitbox = attack.GetComponent<MeleeHitbox>();
        List<GameObject> alliesHit = enemyAttackHitbox.unitsHit(targetTag);

        foreach (GameObject obj in alliesHit)
        {
            Unit unit = obj.GetComponent<Unit>();
            unit.TakeDamage(this);
        }

        Destroy(attack, 0.5f);
    }

    void RangedAttack()
    {
        Vector3 directionToTarget = (currentTarget.transform.position - transform.position).normalized;
        Quaternion attackRotation = Quaternion.LookRotation(Vector3.forward, directionToTarget);

        Vector3 spawnPosition = transform.position + directionToTarget * 0.30f;
        GameObject attack = Instantiate(projectile, spawnPosition, attackRotation);

        Projectile projectileScript = attack.GetComponent<Projectile>();
        projectileScript.SetEnemy(currentTarget.GetComponent<Unit>());
    }
}
