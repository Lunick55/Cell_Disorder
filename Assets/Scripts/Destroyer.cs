using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

    GameObject health;

    public int HIVDamage;
    public int WhiteBloodCellHeal;
    public int FluCellDamage;

    void Start()
    {
        health = GameObject.Find("Health");
    }
    //Destroys everything it comes into contact with it
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "White Blood Cell")
        {
            health.GetComponent<healthScript>().addHealth(WhiteBloodCellHeal);
        }

        if (col.tag == "HIV Cell") 
		{
            health.GetComponent<healthScript>().subtractHealth(HIVDamage);
		}

        if (col.tag == "Flu Cell")
        {
            health.GetComponent<healthScript>().subtractHealth(FluCellDamage);
        }

        Destroy(col.gameObject);
    }
}
