using TMPro;
using UnityEngine;

public class HpTakeDamage : MonoBehaviour
{
    public int playerHealth = 100;

    //Here we declare an Object named _healthToText which we reference to our TextMeshPro in the Unity Editor on the Canvas (the health text we made)
    [SerializeField] TextMeshProUGUI _healthToText;
    public AudioSource _hurt;

    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hurt = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _healthToText.text = playerHealth.ToString();
    }

    //This is the Method that gets Invoked the moment the Event sends out a message with the damage amount which is received inside the parameter (variable of the
    //method int dmg. It substracts the damage and calls the changeColor() method. We also play a sound. :3c
    public void takeDamage (int dmg)
    {
        if (playerHealth > 0)
        {
           playerHealth -= dmg;
           _hurt.Play();
            changeColor(); 
        }

    }

    //Here we change the color of the text based on how much health the player has
    public void changeColor()
    {
        if (playerHealth <= 50 && playerHealth > 20)
        {
            _healthToText.faceColor = Color.yellow;
        }
        else if (playerHealth <= 20)
        {
            _healthToText.faceColor = Color.red;
        }
    }
}
