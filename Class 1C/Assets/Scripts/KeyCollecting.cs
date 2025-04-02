using UnityEngine;

public class KeyCollecting : MonoBehaviour
{
    bool doorKey = false;
    public GameObject textKey;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") || other.CompareTag("doorKey"))
        {
            if (other.CompareTag("doorKey"))
            {
                doorKey = true;
            }

            textKey.SetActive(true);
            Invoke("ShowText", 3);
            other.gameObject.SetActive(false);
        }

        if(other.CompareTag("Door") && doorKey==true)
        {
            other.transform.Rotate(0, 90, 0);
            doorKey = false;
        }
    }

    void ShowText()
    {
        textKey.SetActive(false);
    }
}
