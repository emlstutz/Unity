using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class SimplePlayerMovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float jumpForce = 10f;
    public Camera playerCamera;

    private Rigidbody rb;
    private Vector2 moveInput;
    private Vector2 lookInput;
    private bool isGrounded;

    private InputAction attack;
    private InputAction move;
    private InputAction look;
    private InputAction jump;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;

        attack = InputSystem.actions.FindAction("Attack");
        attack.performed += Attack_performed;
        move = InputSystem.actions.FindAction("Move");
        move.performed += Move_performed;
        move.canceled += Move_canceled;
        look = InputSystem.actions.FindAction("Look");
        look.performed += Look_performed;
        jump = InputSystem.actions.FindAction("Jump");
        jump.performed += Jump_performed;
        FunctionName();
    }



    private void Move_performed(InputAction.CallbackContext obj)
    {
        moveInput = move.ReadValue<Vector2>();
    }

    private void Move_canceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    private void Look_performed(InputAction.CallbackContext context)
    {
        lookInput = look.ReadValue<Vector2>();
    }

    private void Jump_performed(InputAction.CallbackContext context)
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void Attack_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Attacked");
    }

    private void OnEnable()
    {
        move.Enable();
        attack.Enable();
        jump.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
        attack.Disable();
        jump.Disable();
    }

    private void Update()
    {
        Vector3 movement = new Vector3(moveInput.x, 0, moveInput.y);
        movement = playerCamera.transform.TransformDirection(movement);
        movement.y = 0f;

        Debug.DrawRay(transform.position, movement * 10);

        rb.MovePosition(transform.position + movement * moveSpeed * Time.deltaTime);

        if (movement != Vector3.zero)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, movement, moveSpeed * Time.deltaTime * Mathf.Deg2Rad, 0.0001f);
            transform.forward = newDirection;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public void FunctionName ()
    {
        Debug.Log("Performed FunctionName");
    }
}
