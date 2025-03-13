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

    private void OnCollisionEnter(Collision collision)
    {
        // Write a condition that asks if the player tag is Player, then it should Do the debug.log()
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("I collided");
            gameObject.SetActive(false);
        }

        else
        {

        }
    }
}
