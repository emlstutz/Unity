using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


//Dieses Script ist dafür zuständig, die UI zu updaten und das Inventory zu speichern
public class InventorySystem : MonoBehaviour
{
    //List storing all the GameObjects of the different Items
    public List<GameObject> inventory = new List<GameObject>();

    //List storing all the Sprites of the different Items
    public List<Image> _slots = new List<Image>();

    //The new Inventory Slot Game Object we will add
    public GameObject inventoryImagePrefab;

    //The Transform (location) of the panel that our Image Game Objects are children of (needed for Instantiate() )
    public Transform inventoryPanel; // Drag your UI panel here

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    //The method gets called whenever we add a new object in the Object we collide with 
    public void UpdateInventory()
    {
        //Instantiate creates a clone from a reference Gameobject at a designated Position (transform, vector3). In this case it is our InventoryPanel 
        //One the Canvas. Panels are useful because they can help structure UI and make positions relative to each other.
        GameObject newImage = Instantiate(inventoryImagePrefab, inventoryPanel);

        //Here we add the Image of our Gameobject to the List that saves the Graphics
        _slots.Add(newImage.GetComponent<Image>());

        // Loop through each item in the inventory and assign its corresponding sprite to the UI image, ensuring the visual representation matches the stored data.
        // The sprite is retrieved from the AddToInventory component of the collected item and applied to the UI slot in this method.
        for (int i = 0; i < inventory.Count; i++)
        {
            //Bit of a hack job here, since the Original Prefab has an alpha of 0 I change the color so it becomes visible. Better, to expand upon: fill the first 
            //entry with the right image.
            _slots[i].color = Color.white; 
            _slots[i].sprite = inventory[i].GetComponent<AddToInventory>()._sprite;

        }
    }
}
