using UnityEditor.SceneManagement;
using UnityEngine;

public class keyDoorRising : MonoBehaviour
{
    public string keyname;
    public playerInventory playerInv;

    void Start()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            playerInv.inventory.Add(gameObject);
            playerInv.inventory[playerInv.inventory.Count - 1].name = keyname;

            //playerInv.inventory.Remove(keyname);

            Debug.Log("Key Collected!" + keyname);
        }
    }
    void Update()
    {
        
    }

}
