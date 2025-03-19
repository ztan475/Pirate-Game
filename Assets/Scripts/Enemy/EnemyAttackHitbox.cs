using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> unitsHit()
    {
        List<GameObject> unitsInRange = new List<GameObject>();
        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        Collider2D[] hitColliders = Physics2D.OverlapBoxAll(boxCollider.transform.position, boxCollider.size, 0f);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Ally")
            {
                unitsInRange.Add(hitCollider.gameObject);
            }
        }

        return unitsInRange;
    }
}
