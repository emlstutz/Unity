using UnityEngine;
using UnityEngine.UIElements;

public class PatrolState : StateMachineBehaviour
{
    public float cameraRotationSpeed;
    public float rayMaxDirection;
     

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //animator.GetComponent<Renderer>().material.color = Color.green;
        Renderer[] childRenderers = animator.GetComponentsInChildren<Renderer>();

        foreach (Renderer renderer in childRenderers)
        {
            renderer.material.color = Color.green; // Change color of all child objects
        }

        //base.OnStateEnter(animator, stateInfo, layerIndex);
    }
   public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Debug.DrawRay(animator.transform.position, animator.transform.forward * rayMaxDirection);
        //base.OnStateUpdate(animator, stateInfo, layerIndex);
        animator.transform.Rotate(0, 45 * Time.deltaTime * cameraRotationSpeed, 0);

        if (SeePlayer(animator))
        {
            Debug.Log("This works");
            animator.SetInteger("CameraState", 1);
        }

    }

    private bool SeePlayer(Animator animator)
    {
        if (Physics.Raycast(animator.transform.position, animator.transform.forward * rayMaxDirection, out RaycastHit hitinfo))
        {
            if (hitinfo.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}