using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthScript : MonoBehaviour {

    public int health;

    public Image healthImage;
    public Text healthText;

    public Sprite healthy;
    public Sprite sick1;
    public Sprite sick2;
    public Sprite dead;

     void Start()
    {
        healthImage.sprite = healthy;
        healthText.text = health.ToString();
    }

    //Public function call to add an inputted health value
    public void addHealth(int val)
    {
        health += val;

        if (health >= 18)
        {
            health = 18;
        }

        updateHealthUI();
    }

    //Public function call to subtract an inputted health value
    public void subtractHealth(int val)
    {
        health -= val;

        updateHealthUI();

        if (health <= 0)
        {
            GameObject.Find("InfoManager").GetComponent<SceneManagerScript>().goToEnd();
        }
    }

    void updateHealthUI()
    {
        //Updates Text field
        if (health > 9)
        {
            healthText.text = health.ToString();
        }
        else
        {
            healthText.text = " " + health.ToString();
        }

        //Updates image field
        if (health >= 18)
        {
            healthImage.sprite = healthy;
        }
        else if (health < 18 && health > 9)
        {
            healthImage.sprite = sick1;
        }
        else if (health <= 9 && health > 0)
        {
            healthImage.sprite = sick2;
        }
        else if (health <= 0)
        {
            healthImage.sprite = dead;
        }
    }
}
