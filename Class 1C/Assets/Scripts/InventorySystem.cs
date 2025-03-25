using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public Dictionary<GameObject, Sprite> visualInventory = new Dictionary<GameObject, Sprite>();
    [SerializeField] Image _img;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (visualInventory.Count != 0)
        {
            foreach (KeyValuePair<GameObject, Sprite> keyValue in visualInventory)
            {
                Sprite value = keyValue.Value;
                _img.sprite = value;
            }
        }
    }
}
