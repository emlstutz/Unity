using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    public string stringName; 
    public void attack()
    {
        stringName = "Message"; 
        Debug.Log(stringName);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;
        if (collidedObject.CompareTag("Player") == true)
        {
            this.gameObject.SetActive(false);
        }
    }

 
}
