using UnityEngine;

public class AddToInventory : MonoBehaviour
{
    public Sprite _sprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //We add the Game Object this current script is attatched to to our List in the InventorySystem Script attatched to the Player
            collision.gameObject.GetComponent<InventorySystem>().inventory.Add(gameObject);

            //Call the UpdateInventory() method inside the InventorySystem Script attatched to the player
            collision.gameObject.GetComponent<InventorySystem>().UpdateInventory();

            gameObject.SetActive(false);    
        }
    }
}
