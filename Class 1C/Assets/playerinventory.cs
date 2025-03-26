using UnityEngine;
using System.Collections.Generic;


public class playerinventory : MonoBehaviour
{
    public List<GameObject> Inventory = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        Inventory.Add(gameObject);
        Inventory[0].name = "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
