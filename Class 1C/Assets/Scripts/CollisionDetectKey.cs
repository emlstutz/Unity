using UnityEngine;

public class CollisionDetectKey : MonoBehaviour
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
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<InventoryCreation>().backpack.Add(gameObject);
            gameObject.SetActive(false);
        }
        else
        {

        }
    }
    /*recognize which key it is
     *create the inventory
     *add to inventory
     show the inventory*/

}
