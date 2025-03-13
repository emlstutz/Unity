using TMPro;
using UnityEngine;

public class HpTakeDamage : MonoBehaviour
{
    public int playerHealth = 100;
    [SerializeField] TextMeshProUGUI _healthToText;
    [SerializeField] AudioSource _hurt;

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

    public void takeDamage (int dmg)
    {
        if (playerHealth > 0)
        {
           playerHealth -= dmg;
           _hurt.Play();
            changeColor(); 
        }

    }

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
