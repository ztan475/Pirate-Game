using UnityEngine;
using UnityEngine.InputSystem;
public class Clicker : MonoBehaviour
{
    public Camera m_Camera;

    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider != null)
            {
                if (hit.collider.transform.tag == "Node")
                {
                    // hit.transform.GetComponent<Node>().Test();
                    hit.transform.GetComponent<Node>().OpenShop();
                }
                else
                {
                    Debug.Log(hit.transform.tag);
                }
            }
            
            
        }
    }
}