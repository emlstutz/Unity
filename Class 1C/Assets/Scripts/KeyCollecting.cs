using UnityEngine;

public class KeyCollecting : MonoBehaviour
{
    bool greenKeyCollected = false;
    public GameObject textKey;

    //images
    public GameObject redKey;
    public GameObject greenKey;
    public GameObject yellowKey;
    public GameObject purpleKey;

    void ShowMessage(Collider other)
    {
        textKey.SetActive(true);
        Invoke("ShowText", 3);
        other.gameObject.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("greenKey"))
            {
                greenKeyCollected = true;
                greenKey.SetActive(true);

                ShowMessage(other);
            }

            if (other.CompareTag("redKey"))
            {
                redKey.SetActive(true);
                ShowMessage(other);
            }
            if (other.CompareTag("yellowKey"))
            {
                yellowKey.SetActive(true);
                ShowMessage(other);
            }
            if (other.CompareTag("purpleKey"))
            {
                purpleKey.SetActive(true);
                ShowMessage(other);
            }

        if (other.CompareTag("Door") && greenKeyCollected == true)
        {
            other.transform.Rotate(0, 90, 0);
            greenKeyCollected = false;
        }
    }

    void ShowText()
    {
        textKey.SetActive(false);
    }
}
