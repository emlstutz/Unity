using UnityEngine;
using UnityEngine.InputSystem;

public class key_collectable : MonoBehaviour
    
{
    public string keyname;
    public playerinventory playerInv;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
                gameObject.SetActive(false);
                playerInv.Inventory.Add(gameObject);
                playerInv.Inventory[playerInv.Inventory.Count - 1].name = keyname;
                Debug.Log("key collected" + keyname);

        }

       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
