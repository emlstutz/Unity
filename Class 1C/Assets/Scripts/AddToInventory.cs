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
            collision.gameObject.GetComponent<InventorySystem>().inventory.Add(gameObject);
            collision.gameObject.GetComponent<InventorySystem>().visualInventory.Add(gameObject, _sprite);
            gameObject.SetActive(false);    
        }
    }
}
