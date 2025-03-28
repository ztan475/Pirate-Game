using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRange(float range)
    {
        BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(range * 2, range * 2);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponentInParent<Unit>().UnitDetected(collision.gameObject.tag);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        PlayerUnit playerUnit = GetComponentInParent<PlayerUnit>();
        EnemyUnit enemyUnit = GetComponentInParent<EnemyUnit>();

        if (enemyUnit != null)
        {
            enemyUnit.UnitExit(collision.gameObject.tag);
        }
        else
        {
            playerUnit.UnitExit(collision.gameObject.tag);
        }
    }

}
