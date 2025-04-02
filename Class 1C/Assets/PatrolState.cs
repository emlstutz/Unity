using UnityEngine;

public class PatrolState : StateMachineBehaviour
{
    [SerializeField] float rotationSpeed;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       Renderer rend =  animator.gameObject.GetComponent<Renderer>();
        rend.material.color = Color.green;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);

        if (SeePlayer(animator))
        {
            animator.SetInteger(name: "CameraState", 1);
        }
    }
    private bool SeePlayer(Animator animator)
    {
        if (Physics.Raycast(origin: animator.transform.position, direction: animator.transform.forward, out RaycastHit hitinfo))
        {
            if (hitinfo.transform.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
