using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Mouse Look Settings")]
    public float mouseSensitivity = 100f;
    public Transform cameraTransform;
    public Vector3 cameraOffset = new Vector3(0f, 2f, -4f); // 1st person (0,0,0), 3rd person (0,2,-4)

    private float xRotation = 0f;

    [Header("Movement Settings")]
    public float speed = 5f;
    private Rigidbody rb;

    public Transform orientationRay;
    public float maxRayDistance = 10f;
    public MainControls ms;
    private IInteractable currentInteractable;


    private void Awake()
    {
        ms = new MainControls();
    }

    private void OnEnable()
    {
        ms.Player.Interact.performed += Interact;
        ms.Player.Interact.Enable();
    }

    private void OnDisable()
    {
        ms.Player.Interact.performed -= Interact;
        ms.Player.Interact.Disable();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // Prevent unwanted physics rotation
        Cursor.lockState = CursorLockMode.Locked; // Lock cursor for better control
    }
    
    void Update()
    {
        HandleMouseLook();
        HandleMovement();
        UpdateCameraPosition();

        //RayCast
        Vector3 origin = orientationRay.position; // elevate slightly to simulate eye-level if needed
        Vector3 direction = orientationRay.forward;

        if (Physics.Raycast(origin, direction, out RaycastHit hit, maxRayDistance))
        {
            Debug.DrawRay(origin, direction * maxRayDistance, Color.yellow);
            currentInteractable = hit.collider.GetComponent<IInteractable>();
        }
        else
        {
            currentInteractable = null;
        }
    }

    public void Interact(InputAction.CallbackContext context)
    {
        if (currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }


    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevents flipping

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        rb.linearVelocity = new Vector3(move.x * speed, rb.linearVelocity.y, move.z * speed);
    }

    void UpdateCameraPosition()
    {
        cameraTransform.position = transform.position + transform.TransformDirection(cameraOffset);
    }
}