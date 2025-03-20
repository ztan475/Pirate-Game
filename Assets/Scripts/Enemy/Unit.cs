using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected int attack = 10;
    [SerializeField] protected int health = 100;
    [SerializeField] protected float attackSpeed = 1.0f;
    [SerializeField] protected int defense = 0;
    [SerializeField] protected float range = 2;

    protected NavMeshAgent agent;
    protected string targetTag;

    public float MoveSpeed => moveSpeed;
    public int Attack => attack;
    public int Health => health;
    public GameObject attackArea;
    private Coroutine attackCoroutine;

    // Start is called before the first frame update
    void Start()
    {

        BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(range * 2, range * 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Enemy")
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * Time.deltaTime * moveSpeed;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * Time.deltaTime * moveSpeed;
            }
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

    private void Die()
    {
        string tag = gameObject.tag;
        Debug.Log("An " + tag + " has died!");
        Destroy(gameObject);
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
        Vector3 spawnPosition = gameObject.transform.position + Vector3.left * 0.75f;
        GameObject attack = Instantiate(attackArea, spawnPosition, Quaternion.identity);

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
