using UnityEngine;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class playerInventory : MonoBehaviour
{
    public List<GameObject> inventory = new List<GameObject>();
    public MainPlayerActions playerCont;
    public bool isInteracting = false;
    public bool canInteractWith = false;

    private void Awake()
    {
        playerCont = new MainPlayerActions();
    }

    private void OnEnable()
    {
        playerCont.Player.Interact.performed += Interaction;
        playerCont.Player.Interact.Enable();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public void Interaction(InputAction.CallbackContext context)
    {
        if (context.started && canInteractWith && !isInteracting)
        {
            isInteracting = true;
            Debug.Log("Interacting! But set Interaction to false again via another function!");

        }
    }


}