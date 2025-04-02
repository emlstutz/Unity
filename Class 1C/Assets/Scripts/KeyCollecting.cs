using UnityEngine;
using UnityEngine.UI;

public class KeyCollecting : MonoBehaviour
{
    bool greenKeyCollected = false;
    public GameObject textKey;

    //images
    public GameObject image1;
    public GameObject image2;
    public GameObject image3;
    public GameObject image4;
    private int colorTrack=0;

    Color colorName;

    void ShowMessage(Collider other)
    {
        textKey.SetActive(true);
        Invoke("ShowText", 3);
        other.gameObject.SetActive(false);
    }

    void SetColor()
    {
        colorTrack++;

        if (colorTrack == 1) 
        {
            image1.GetComponent<Image>().color = colorName;
        }
        if (colorTrack == 2)
        {
            image2.GetComponent<Image>().color = colorName;
        }
        if (colorTrack == 3)
        {
            image3.GetComponent<Image>().color = colorName;
        }
        if (colorTrack == 4)
        {
            image4.GetComponent<Image>().color = colorName;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
            if (other.CompareTag("greenKey"))
            {
                greenKeyCollected = true;

                colorName = Color.green;
                SetColor();

                ShowMessage(other);
            }

            if (other.CompareTag("redKey"))
            {
            colorName = Color.red;
            SetColor();
            ShowMessage(other);
            }
            if (other.CompareTag("yellowKey"))
            {
            colorName = Color.yellow;
            SetColor();
            ShowMessage(other);
            }
            if (other.CompareTag("purpleKey"))
            {
            colorName = Color.cyan;
            SetColor();
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
