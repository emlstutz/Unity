using UnityEngine;
using System.Collections.Generic;

public class InventoryScript : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>(); 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory.Add(gameObject);
        inventory[0].name = "New Player";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
