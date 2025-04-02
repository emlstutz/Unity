using UnityEngine;

public class FollowState : StateMachineBehaviour
{
    private Transform playerTransform;

    // Event function
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        animator.GetComponent<Renderer>().material.color = Color.red;
    }

    // Event function
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 targetDirection = playerTransform.position - animator.transform.position;
        targetDirection.y = 0; // disregard positional difference on y-axis
        Vector3 viewDirection = Vector3.RotateTowards(animator.transform.forward, targetDirection, 1f, 0f);
        animator.transform.rotation = Quaternion.LookRotation(viewDirection);

        if (!SeePlayer(animator))
        {
            animator.SetInteger("CameraState", 2);
        }
    }

    private bool SeePlayer(Animator animator)
    {
        RaycastHit hitinfo;
        if (Physics.Raycast(animator.transform.position, animator.transform.forward, out hitinfo))
        {
            if (hitinfo.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
