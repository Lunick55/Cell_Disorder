using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDestroyer : MonoBehaviour {

    GameObject health;
    public GameObject RedBloodParticle;
    public GameObject WhiteBloodParticle;
    public GameObject TParticle;
    public GameObject HIVParticle;
    public GameObject FluParticle;

    void Start()
    {
        health = GameObject.Find("Health");
    }

    //Destroys Game Object
    void OnMouseDown()
    {
        if (gameObject.tag == "T Cell")
        {
           Instantiate(TParticle, this.transform.position, this.transform.rotation);
            health.GetComponent<healthScript>().subtractHealth(6);
        }

        if (gameObject.tag == "White Blood Cell")
        {
            Instantiate(WhiteBloodParticle, this.transform.position, this.transform.rotation);
            health.GetComponent<healthScript>().subtractHealth(6);
        }

        if (gameObject.tag == "Red Blood Cell")
        {
            Instantiate(RedBloodParticle, this.transform.position, this.transform.rotation);
        }

        if (gameObject.tag == "HIV Cell")
        {
            Instantiate(HIVParticle, this.transform.position, this.transform.rotation);
        }

        if (gameObject.tag == "Flu Cell")
        {
           Instantiate(FluParticle, this.transform.position, this.transform.rotation);
        }

        Destroy(this.gameObject);
    }
}
