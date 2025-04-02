using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class NewMovementScript : MonoBehaviour
{

    [Header("Movement")]
    public float movementSpeed;

    public Transform orientation;

    private Vector2 moveInput;

    float horizontalInput;

    Vector3 moveDirection;
    Rigidbody rb;

    // Inputs
    private MainPlayerActions playerInput;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float jumpMultiplier;
    bool readyToJump;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;


    }


    void Awake()
    {
        playerInput = new MainPlayerActions();
    }

    private void OnEnable()
    {
        playerInput.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Move.canceled += ctx => moveInput = Vector2.zero;
        playerInput.Player.Jump.performed += Jump;
        playerInput.Player.Jump.canceled -= Jump;

        playerInput.Player.Move.Enable();
        playerInput.Player.Jump.Enable();


    }
    private void OnDisable()
    {
        playerInput.Player.Move.Disable();
        playerInput.Player.Jump.Disable();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float movementX = moveInput.x * Time.deltaTime;
        float movementY = moveInput.y * Time.deltaTime;

        moveDirection = orientation.forward * movementY + orientation.right * movementX;

        if (grounded)
            rb.AddForce(moveDirection.normalized * movementSpeed * moveInput.magnitude * 10f, ForceMode.Force);
        else if (!grounded)
            rb.AddForce(moveDirection.normalized * movementSpeed * moveInput.magnitude * 10f * jumpMultiplier, ForceMode.Force);

    }


    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        SpeedControl();

        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }


    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitVel = flatVel.normalized * movementSpeed;
            rb.linearVelocity = new Vector3(limitVel.x, rb.linearVelocity.y, limitVel.z);
        }
    }


    private void Jump(InputAction.CallbackContext context)
    {
        if (readyToJump && grounded)
        {
            readyToJump = false;

            ActuallyJump();

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void ActuallyJump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true;
    }


}