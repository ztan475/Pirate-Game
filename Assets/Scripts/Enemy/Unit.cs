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

    [Header("Unit Sprites")]
    [SerializeField] private Sprite[] idleSprites;
    [SerializeField] private Sprite[] walkSprites;
    [SerializeField] private Sprite[] attackSprites;
    [SerializeField] private float animationSpeed = 0.1f;

    protected NavMeshAgent agent;
    protected string targetTag;
    private GameObject currentTarget = null;
    private Coroutine attackCoroutine = null;

    public float MoveSpeed => moveSpeed;
    public int Attack => attack;
    public int Health => health;

    private SpriteRenderer spriteRenderer;
    private int currentSpriteIndex = 0;
    

    // Start is called before the first frame update
    protected void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GetComponentInChildren<UnitRange>().SetRange(range);

        spriteRenderer = GetComponent<SpriteRenderer>();

        if (idleSprites.Length > 0)
        {
            spriteRenderer.sprite = idleSprites[0];
        }
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

            if (walkSprites.Length > 0)
            {
                SpriteWalk();
            }
        }
        else
        {
            agent.isStopped = true;
            agent.ResetPath();

            if (idleSprites.Length > 0)
            {
                SpriteIdle();
            }
        }
    }

    public void SpriteWalk()
    {
        if (walkSprites.Length == 1){
            spriteRenderer.sprite = walkSprites[0];
        }
        else
        {
            // Use animated sprites
        }
    }

    public void SpriteIdle()
    {
        if (idleSprites.Length == 1){
            spriteRenderer.sprite = idleSprites[0];
        }
        else
        {
            // Use animated sprites
        }
    }

    public void UnitDetected(string collisionTag)
    {
        if (collisionTag == targetTag && attackCoroutine == null)
        {
            agent.isStopped = true;
            agent.ResetPath();
            attackCoroutine = StartCoroutine(StartAttacking());
        }
    }

    public void UnitExit(string collisionTag)
    {
        if (collisionTag == targetTag && attackCoroutine != null)
        {
            StopCoroutine(attackCoroutine);
            attackCoroutine = null;

            spriteRenderer.sprite = SpriteIdle[0];
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
            yield return StartCoroutine(SpriteAttackAnimation());
            if (this.type == UnitType.Melee)
            {
                MeleeAttack();
            }
            else if (this.type == UnitType.Ranged)
            {
                RangedAttack();
            }
            
            yield return new WaitForSeconds(attackSpeed);
            attackCoroutine = null;
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

    private IEnumerator SpriteAttackAnimation()
    {
        currentSpriteIndex = 0;
        while (currentSpriteIndex < attackSprites.Length)
        {
            spriteRenderer.sprite = attackSprites[currentSpriteIndex];
            currentSpriteIndex++;
            yield return new WaitForSeconds(animationSpeed);
        }
        
        spriteRenderer.sprite = idleSprites[0];
    }
}
