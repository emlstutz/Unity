using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class NewRotateCamera : MonoBehaviour
{

    public Transform orientation;
    private Rigidbody rb;

    private Vector2 lookInput;

    // Inputs
    private MainPlayerActions playerInput;

    public float sensX;
    public float sensY;

    float xRotation;
    float yRotation;



    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();

    }


    void Awake()
    {
        playerInput = new MainPlayerActions();
    }

    private void OnEnable()
    {
        playerInput.Player.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>();
        playerInput.Player.Look.canceled += ctx => lookInput = Vector2.zero;
        playerInput.Player.Look.Enable();


    }
    private void OnDisable()
    {
        playerInput.Player.Look.Disable();
    }


    void Update()
    {
        float mouseX = lookInput.x * Time.deltaTime * sensX;
        float mouseY = lookInput.y * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;


        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0f);
    }


}