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
            // RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            RaycastHit2D[] hit2 = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            foreach(RaycastHit2D unit in hit2)
            {
                if (unit.collider != null)
                {
                    if (unit.collider.transform.tag == "Node")
                    {
                        // hit.transform.GetComponent<Node>().Test();
                        UIManager.Instance.CloseShop();
                        unit.transform.GetComponent<Node>().OpenShop();
                    }
                    else
                    {
                        Debug.Log(unit.transform.tag);
                    }
                }
            }
            
            
            
        }
    }
}