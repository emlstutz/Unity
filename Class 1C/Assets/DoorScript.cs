using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{
    public Animator animor;

    private bool isOpen = false;

    void Start()
    {
        //animor = GetComponent<Animator>();
    }

    public void Interact()
    {
        Debug.Log("It works");
        DoorState();
    }

    public void DoorState()
    {
        isOpen = !isOpen;

        // Set the parameter based on the door state
        animor.SetInteger("DoorOpen", isOpen ? 1 : 0);
    }
}
