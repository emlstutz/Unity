using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public Dictionary<GameObject, Sprite> visualInventory = new Dictionary<GameObject, Sprite>();
    [SerializeField] Image _img;
    public Image _inventorySlot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject item in inventory)
        {
            _img.sprite = item.GetComponent<AddToInventory>()._sprite;
        }
        /*This solution works with adding a Sprite to a Key Value pair of Game Object and Sprite. You could expand upon this by adding more 
         * slots or by getting the name of the saved Sprite and and the tag of the key to see which Key it is.
        if (visualInventory.Count != 0)
        {
            foreach (KeyValuePair<GameObject, Sprite> keyValue in visualInventory)
            {
                Sprite value = keyValue.Value;
                _img.sprite = value;
            }

        }*/
    }
}
