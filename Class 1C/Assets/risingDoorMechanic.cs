using Unity.VisualScripting;
using UnityEngine;

public class risingDoorMechanic : MonoBehaviour
{
    public playerInventory playerInv;
    public string doorKeyName;
    private bool isLocked = true;
    private bool isOpened = false;
    private float detectionRangeCollider = 2f;
    private Animator mAnimator;

    private void Start()
    {
        mAnimator = GetComponent<Animator>();
        isLocked = true;
        isOpened = false;

        SphereCollider sphereCollider = gameObject.AddComponent<SphereCollider>();
        sphereCollider.radius = detectionRangeCollider;
        sphereCollider.isTrigger = true; // Enable trigger mode for detection
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isLocked && !isOpened && other.CompareTag("Player"))
        {
            if (CorrectKey(doorKeyName))
            {
                UnlockDoor();
                Debug.Log("Door Unlocked");
                isLocked = false;

            }
            else
            {
                Debug.Log("Door Locked");
            }
        }
    }

    private bool CorrectKey(string keyRequired)
    {
        foreach (GameObject key in playerInv.inventory)
        {
            if (key.name == keyRequired)
            {
                return true;
            }
        }
        return false;
    }

    private void UnlockDoor()
    {
        Debug.Log("This Function Works!!");
        if (mAnimator != null)
        {
            isOpened = true;
            mAnimator.SetTrigger("openDoor01");
        }
    }


}