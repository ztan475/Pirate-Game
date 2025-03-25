using System;
using UnityEngine;

public class MeleeActions : MonoBehaviour
{
    public enum WhoToAttack
    {
        Player,
        Enemy,
    }
    
    public WhoToAttack whoToAttack;
    public Transform targetPosition;
    private Melee _melees;
    private bool _isMoving = false;
    private Transform _oldPosition;
    
    // Start is called before the first frame update
    public void Start()
    {
        _melees = GetComponent<Melee>();
        gameObject.GetComponent<CircleCollider2D>().radius = _melees.AttackRange;
        _isMoving = true;
        _oldPosition = targetPosition;
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (_isMoving)
        {
            _melees.Move(gameObject.transform, targetPosition);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(whoToAttack.ToString()))
        {
            targetPosition = other.transform;
            _isMoving = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(whoToAttack.ToString()))
        {
            if (other.gameObject.GetComponent<Melee>() && gameObject.transform.position == other.transform.position)
            {
                _melees.Attack(other.gameObject.GetComponent<Melee>());
            }

            if (other.gameObject.GetComponent<Archer>() && gameObject.transform.position == other.transform.position)
            {
                _melees.Attack(other.gameObject.GetComponent<Archer>());
            }

            if (other.gameObject.GetComponent<Tank>() && gameObject.transform.position == other.transform.position)
            {
                _melees.Attack(other.gameObject.GetComponent<Tank>());
            }
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        targetPosition = _oldPosition;
        _isMoving = true;
    }

}
