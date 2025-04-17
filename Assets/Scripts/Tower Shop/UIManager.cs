using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    // [SerializeField] private GameObject shopUI;

    private Node currentNode;
    private Vector3 currentNodePos;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // CloseShop();
    }

    public Vector3 GetCurrentNodePos()
    {
        return currentNodePos;
    }

    public void SetCurrentNodePos(Vector3 newNodePos)
    {
        currentNodePos = newNodePos;
    }

    public void SetNode(Node newNode)
    {
        currentNode = newNode;
    }

    public Node GetNode()
    {
        return currentNode;
    }

    public void OpenShop()
    {
        currentNode.shopUI.SetActive(true);
        // shopUI.SetActive(true);
    }

    public void CloseShop()
    {
        if (currentNode != null)
        {
            if(currentNode.shopUI.activeSelf == true)
            {
                currentNode.shopUI.SetActive(false);
            }
        }
        
        // shopUI.SetActive(false);
    }
}
