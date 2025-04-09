using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    InputAction interact;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = InputSystem.actions.FindAction("Interact");
        interact.performed += OnEPressed;
        interact.Enable();
    }

    private void OnEPressed(InputAction.CallbackContext context)
    {
        Physics.Raycast(origin: this.transform, direction: Vector3.forward, )
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
