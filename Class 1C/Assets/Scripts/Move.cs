using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] float mouseSensitivity = 2f;
    [SerializeField] float jumpHeight = 3f;
    [SerializeField] Animator animator;

    // Private variables
    private bool isMoving = false;
    private bool jumping = false;
    private float yRot;
    private Rigidbody rigidBody;
    private Vector3 jump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {

        // Handle mouse look (rotation)
        yRot += Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yRot, transform.localEulerAngles.z);

        // Check for movement input
        isMoving = false;

        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.5f)
        {
            rigidBody.linearVelocity += transform.right * Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
            isMoving = true;
        }
        if (Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5f)
        {
            rigidBody.linearVelocity += transform.forward * Input.GetAxisRaw("Vertical") * speed * Time.deltaTime;
            isMoving = true;
        }
        if (Input.GetKey(KeyCode.Space) && jumping == false)
        {
            Debug.Log("Im jumping");
            rigidBody.AddForce(jump * jumpHeight, ForceMode.Impulse);
            jumping = true;
        }


        // TODO Get Input and see if N was pressed

        if (Input.GetKey(KeyCode.N))
        {
            //this.pressedN = true;
            //animator.SetBool("pressedN", true);


            // TODO: Change the Text inside our TextMeshPro TextField to any new text
            // Hint: We are working with Children of a GameObject Parent, use the Scripting Reference!

            // First Step: We need to get the other GameObject which contains the Text 

            // We could technically create a new GameObject Text with TextMeshPro and a new Text inside and destroy the old one 
            // BUT IT PRODUCES DATA TRASH SO NO

            // We need to get the TextMeshPro Component inside the GameObject that contains the Text


            // and then change the Text inside there. 

        }


    }

    private void OnCollisionStay()
    {
        jumping = false;
    }
}


