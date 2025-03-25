
using UnityEngine;

public class NewPlayerUnit: MonoBehaviour
{
    // Properties with private backing fields
    [SerializeField]private int _health;
    [SerializeField]private float _speed;
    [SerializeField]private float _attackRange;
    [SerializeField]private float _attackSpeed;
    [SerializeField]private int _damage;
    private string _role;

    // Public properties with getters and setters
    public int Health
    {
        get { return _health; }
        set { _health = value; }
    }

    public float Speed
    {
        get { return _speed; }
    }

    public float AttackRange
    {
        get { return _attackRange; }
    }

    public float AttackSpeed
    {
        get { return _attackSpeed; }
    }

    public int Damage
    {
        get{return _damage;}
    }
    
    public string Role
    {
        get { return _role; }
        set { _role = value; }
    }

    // Constructor to initialize all properties
    public void Initialize(int health, float speed, float attackRange, float attackSpeed, int damage, string role)
    {
        _health = health;
        _speed = speed;
        _attackRange = attackRange;
        _attackSpeed = attackSpeed;
        _damage = damage;
        _role = role;
    }

    // Virtual methods that can be overridden in child classes
    public void Move(Transform from,Transform to)
    {
        from.position = new Vector3(from.position.x, from.position.y, 0); 
        to.position = new Vector3(to.position.x, to.position.y, 0);
        from.position = Vector3.MoveTowards(from.position,to.position, Speed * Time.deltaTime);
    }

    public virtual void Attack(NewPlayerUnit target)
    {
    }

    public virtual void TakeDamage(int damage)
    {
    }

    public void Die()
    {
        Destroy(gameObject);
        Debug.Log(_role + " Dead");
    }
    
}