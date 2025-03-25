using System;
using UnityEngine;

public class ArcherActions : MonoBehaviour
{
    public enum WhoToAttack
    {
        Player,
        Enemy,
    }
    
    public WhoToAttack whoToAttack;
    public Transform targetPosition;
    private Archer _archers;
    private bool _isMoving = false;
    private Transform _oldPosition;
    
    // Start is called before the first frame update
    public void Start()
    {
        _archers = GetComponent<Archer>();
        gameObject.GetComponent<CircleCollider2D>().radius = _archers.AttackRange;
        _isMoving = true;
        _oldPosition = targetPosition;
    }

    // Update is called once per frame
    public void Update()
    {
        
        if (_isMoving)
        {
            _archers.Move(gameObject.transform, targetPosition);
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

            if (other.gameObject.GetComponent<Melee>())
            {
                _archers.Attack(other.gameObject.GetComponent<Melee>());
            }

            if (other.gameObject.GetComponent<Tank>())
            {
                _archers.Attack(other.gameObject.GetComponent<Tank>());
            }

            if (other.gameObject.GetComponent<Archer>())
            {
                _archers.Attack(other.gameObject.GetComponent<Archer>());
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        targetPosition = _oldPosition;
        _isMoving = true;
    }
}
