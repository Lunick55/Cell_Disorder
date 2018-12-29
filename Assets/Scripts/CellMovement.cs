using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellMovement : MonoBehaviour {

    Rigidbody2D rb;
	public float speed;
    float verticalPush;
    Vector2 force;
	public GameObject HIVCell;//Maybe remove this later. See below
	bool bounce;
	public int bounceAmount;
	Animator anim;

    public GameObject WhiteBloodParticle;
    public GameObject HIVParticle;

    void Start()
    {
		bounce = false;
        //Find the body of the cell and pushes it in a solid direction.
        rb = GetComponent<Rigidbody2D>();

		if (gameObject.tag == "HIV Cell") 
		{
			anim = GetComponent<Animator> ();
			anim.SetBool ("infect", true);
		}

        //Adds a random Y variable to its direction
        verticalPush = Random.Range(-40, 41);
        force = new Vector2 (speed, verticalPush);
        rb.AddForce(force);

        //Adds some rotation for flavor
        rb.rotation = Random.Range(-20, 21);
    }

    //Makes sure speeds maintained
    void Update()
    {
		if (bounce == true) 
		{
			setForce (0);
			rb.AddForce (force);
			bounce = false;
		}	
    }

    //Sets the force of the object
    public void setForce(float newSpeed)
    {
        speed = newSpeed;
		verticalPush = -verticalPush / bounceAmount;
		force = new Vector2 (speed, verticalPush);
		verticalPush = verticalPush * bounceAmount;
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "HIV Cell" && gameObject.tag == "T Cell") 
		{
			//Hi. I'm below. Make this a resource grab instead?
			Instantiate(HIVCell, gameObject.transform.position, Quaternion.identity);

			Destroy (gameObject);
		}

        if (col.gameObject.tag == "HIV Cell" && gameObject.tag == "White Blood Cell")
        {
            Instantiate(HIVParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
            Destroy(col.gameObject);

            Instantiate(WhiteBloodParticle, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
        bounce = true;

		return;
	}

	public void InfectEnd()
	{
		anim.SetBool ("infect", false);
	}
}
