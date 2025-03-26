using UnityEngine;

public class risingDoorMechanic : MonoBehaviour
{
    public playerInventory playerInv;
    private bool isLocked = true;
    private bool isOpened = false;
    public Transform player;
    public string doorName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isLocked = true;
        isOpened = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isLocked && playerInv.name == doorName) //Reference inventory instead of the keyDoorRise
        {
            UnlockDoor();
        }
        else
        {
            Debug.Log("Door is Locked");
        }
    }

    public void UnlockDoor()
    {
            Debug.Log("Is Unlocked!");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
