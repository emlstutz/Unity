using Mono.Cecil;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

public class PatrolState : StateMachineBehaviour
{
    public float rotationSpeed = 0;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Renderer renderer = animator.gameObject.GetComponent<Renderer>();

        if (renderer != null)
        {
            renderer.material.color = Color.green;
        }

    }
   

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.Rotate(0, 45 * Time.deltaTime * rotationSpeed, 0);
    }

  public void PlayerSee()
    {

    }
    

    


}
    