using UnityEngine;

public class DemoObjective : MonoBehaviour
{

    [SerializeField] Transform nextTarget;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Detected");
        collision.gameObject.GetComponent<DemoTargeting>().SetTarget(nextTarget);
    }
}
