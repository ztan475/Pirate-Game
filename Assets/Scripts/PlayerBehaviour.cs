using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 _targetPosition = Vector3.zero;
    private bool _enemyInRange = false;
    private GameObject _enemy;
    private bool _isMoving = true;
    public SpriteRenderer projectileSprite;
    public Transform shootOffset;
    public float attackRange;
    public int health;
    public int damage;
    public Role role;
    public enum Role
    {
        Melee,
        Ranged,
        Tank,
    }
    //TODO lock on target,
    //TODO Atack for melee and ranged, block for tank
    //TODO fix the movement and placement
    
    void Start()
    {
        GetComponent<CircleCollider2D>().radius = attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(1) && !_enemyInRange)
        {
            _targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _targetPosition.z = 0;
        }

        if (_targetPosition != Vector3.zero && !_enemyInRange && _isMoving)
        {
            
            transform.position = Vector3.MoveTowards(transform.position,
                _targetPosition,
                Time.deltaTime * 5);
        }

        if (_enemyInRange)
        {
            _isMoving = false;
            attack(_enemy);
            _isMoving = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.transform.position);
        _enemyInRange = true;
        _enemy = other.gameObject;
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        _enemyInRange = false;
    }

    void attack(GameObject target)
    {
        Instantiate(projectileSprite, shootOffset.position, transform.rotation);
    }
} 
