using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluMovement : MonoBehaviour {

    Rigidbody2D rb;
    public float speed;
    float speedShifter;
    float verticalPush;
    Vector2 force;
    bool goingUp;

    void Start()
    {
        //Adds a random extra speed boost to spread out the cells.
        speedShifter = Random.Range(-20, 20);
        speed += speedShifter;

        //Find the body of the cell and pushes it in a solid direction.
        rb = GetComponent<Rigidbody2D>();

        force = new Vector2(speed, verticalPush);
        rb.AddForce(force);

        //Adds some rotation for flavor
        rb.rotation = Random.Range(-20, 21);

        if (rb.rotation > 0)
        {
            goingUp = true;
        }
        else
        {
            goingUp = false;
        }
    }

    //Makes sure speeds maintained
    void Update()
    {
        if (this.gameObject.transform.position.y >= 9)
        {
            rb.velocity = new Vector2(rb.velocity.x, -.5f);
            goingUp = false;
        }

        if (this.gameObject.transform.position.y <= -9)
        {
            rb.velocity = new Vector2(rb.velocity.x, .5f);
            goingUp = true;
        }

        //Adds force based on direction in needs to go in.
        if (goingUp)
        {
            rb.AddForce(new Vector2(0, verticalPush + 1f));
        }
        else
        {
            rb.AddForce(new Vector2(0, verticalPush - 1f));
        }
    }


    //Sets the force of the object
    public void setForce(float newSpeed)
    {
        speed = newSpeed;
        verticalPush = -verticalPush;
    }
}
