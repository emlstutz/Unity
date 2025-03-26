using System.Reflection;
using UnityEngine;

public class DoorMechanic : MonoBehaviour
{
    public playerinventory playerInv;
    private bool isLocked = true;
    private bool isOpened = false;
    public key_collectable keycollect;
    public Transform player;
    public string keyname;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isLocked = true;
        isOpened = false;

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (playerInv.Inventory.Contains(gameObject))
        {


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
