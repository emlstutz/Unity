using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //OnCollisionEnter is the method from Unity that gets exectured when two objects Collide. For more Information check out the Unity Scripting Manual. 
    
    private void OnCollisionEnter(Collision collision)
    {
        // Write a condition that asks if the player tag is Player. If that statement is true it should Do the debug.log()
        // collision.gameObject.tag means First we get the Information that Our Coin (GameObject) collided with another GameObject. All things that are attatched 
        // To a collision data are basically information about the GameObjects and its GameComponents. Since the tag is a property of the GameObject we can get it by
        // adding .tag . In Unity C# we can get almost all GameComponents and properties of a GameObject by writing GameObject. and then either a property (variable) 
        // like tag or gameObject.GetComponent<COMPONENTNAME>(); example: gameObject.GetComponent<Rigidbody>(); 
        // We can then get Properties (Variables) of this Component. Those are partly!! the same Variables you see in the Unity Editor. Example:  gameObject.GetComponent<Rigidbody>().mass
        // This way you can get almost any piece of information or change and adress any part of the GameObject.

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("I collided");
            //This disables the Coin so it won't be active in the Scene anymore, although it will still exist. 
            gameObject.SetActive(false);

            //Let's add a UI and count our coins! This line of Code is responsible for our Updated Counter Number to Show up on the Screen

        }

        else
        {

        }
    }
}
