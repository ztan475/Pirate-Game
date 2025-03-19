using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node : MonoBehaviour
{
    public bool hasTower;

    private void Start()
    {
        hasTower = false;
    }

    public void OpenShop()
    {
        if (!hasTower)
        {
            UIManager.Instance.OpenShop();
            UIManager.Instance.SetCurrentNodePos(gameObject.transform.position);
            UIManager.Instance.SetNode(this);
        }
        else
        {
            Debug.Log("Sell or upgrade option");
        }
        
    }
}
