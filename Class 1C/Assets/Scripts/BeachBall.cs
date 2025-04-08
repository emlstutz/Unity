using UnityEngine;

/// <summary>
/// A beach ball to kick around a little
/// </summary>

public class BeachBall : MonoBehaviour, IInteractable
{
    private Rigidbody rb;

    // Event function
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// When interacting: Kick the ball upwards with a small offset
    /// </summary>
    public void Interact()
    {
        Vector3 direction = Quaternion.AngleAxis(Random.Range(-10f, 10f), Vector3.forward) * Vector3.up * 20;
        rb.AddForce(direction, ForceMode.VelocityChange);
    }
}
