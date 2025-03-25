using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//This Solution is called Event-based programming. We could do this another way, too, using similar steps that we used in the CoinCollision Script. 
//To challenge yourself, you could try recreating this in that way. A simple version of this can also be found in the Attack Script (Disabled on the Enemy) and the
//PlayerHealth Script (disabled on the Player)

public class HpDoDamage : MonoBehaviour
{
    //This declares a UnityEvent Object with the name m_Attacked. It is not created yet, we do that in the Start Method. 
    //Events transport messages to a Listener which then executes something (usually a Method) the moment the Event happened.
    //In this specific case our Event transports also an Integer value (Variable), because we will substract damage from our Player.
    //In the Unity Editor your will find Attacked (Int32) under your script. Here you can add the listeners that react to this Event and the method that will be 
    //executed.
    public UnityEvent<int> m_Attacked;

    //The Integer Variable with the name _damage. Here it doesn't have a value asigned yet, we will du this later, in the listener (that is attatched to the Player - the HpTakeDamage Script)
    public int _damage;

    public void Awake()
    {

    }

    void Start()
    {
        //Here we check if the Event was already created, if not then we create it right now! We do not execture it yet, that means it doesn't send a message
        //to our listener on the Player yet and it won't take damage here.
        if (m_Attacked == null)
            m_Attacked = new UnityEvent<int>();
    }

    

    void Update()
    {

    }


    public void OnCollisionEnter(Collision collision)
    {
        //Here we INVOKE the Event, so in this moment, it sends out the value of the _damage variable to the Player. 
        m_Attacked.Invoke(_damage);
    }
}
