using UnityEngine;

public class BeachBallScript : MonoBehaviour, IInteractable
{
    Rigidbody rb;
    public float powerPunch = 10f;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Interact()
    {
        rb.AddForce(Vector3.forward * powerPunch);
    }

}
