using UnityEngine;
using UnityEngine.AI;

public class cctv_State_Machine : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform target;
    public Animator _animator;
    enum State { 
        Idle,
        Search,
        Lock,
        Attack
    }
    private State Current_State = State.Idle;
    void Start()
    {
        _animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
        

    }
    // Update is called once per frame
    void Update()
    {
        Handle_States();
        agent.SetDestination(target.position);
    }

    private void Handle_States() { 
        switch (Current_State)
        {
            case State.Idle:
                Idle_Action();
                break;
            case State.Search:
                Search_Action(); 
                break;
                
            case State.Lock:
                Lock_Action();
                break;
            case State.Attack:
                 Attack_Action();
                break;
        }
    
    }

    private void Idle_Action() {
    
    }
    private void Search_Action() { 
    
    }
    private void Lock_Action() {
    
    }
    private void Attack_Action() { 
    
    }

}
