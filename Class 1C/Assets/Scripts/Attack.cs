using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] int number;
    public int damage = 10;
    private int playerHealth;

    //TODO 
    /* Detect Collision 
     * Cool Down between Attacks 
     * Taking HP From the Player 
     *  (public) health variable in the Player
     *  (public) variable for Damage in the Enemy 
     * Health Bar to Show Health
     * (Enemy Health)
     * Play Sound on hit 
     * Visual Feedback with Blood or Particle System
     */


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().health -= damage;
            Debug.Log (playerHealth.ToString ());
        }

        /*if (collision.gameObject.CompareTag("Player"))
        {

        }*/
    }

    public int MethodName ()
    {
        return 5;
    }
}
