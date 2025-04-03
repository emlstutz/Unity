using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(CompareTag("Player") == true)
        {
            List<GameObject> localInventory = collision.gameObject.GetComponent<InventorySystem>().inventory;
            int inventoryLength = localInventory.Count;

            for (int i = 0; i < inventoryLength; i++)
            {
                if (localInventory[i].tag == "KeyRed")
                {
                    gameObject.SetActive(false);
                    Debug.Log("collided");
                }
            }
        }
    }
}
