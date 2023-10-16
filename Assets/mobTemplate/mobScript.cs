using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mobScript : MonoBehaviour
{

    public float speed =2.4f;
    public Rigidbody2D myRB;
    public float maxSpeed = 3.0f;
    public Transform leftWaypoint;
    public Transform rightWaypoint;
    public bool direction = true;
    public SpriteRenderer mySR;
    public bool is_dead = false;
    public float dead_delay = 0.2f;
    private float dead_timer = 0.0f;
    private bool dead_setup = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // add forces to make the mob move
        if (direction) // check which way we are moving
        { // moving right
            myRB.AddForce(Vector2.right * speed);
        } else
        { // moving left
            myRB.AddForce(Vector2.left * speed);
        }

        //don't go faster than the max speed
        float currentSpeed = myRB.velocity.x;
        currentSpeed = Mathf.Clamp(currentSpeed, -1.0f * maxSpeed, maxSpeed);
        myRB.velocity = new Vector2(currentSpeed, myRB.velocity.y);

        // check if we have reached the waypoint
        if (direction) // check if moving left or right
        { // moving to the right
            if (transform.position.x > rightWaypoint.position.x) //checking if we have reached the waypoint
            {
                direction = !direction; // change direction
                //mySR.flipX = !mySR.flipX; // flip the sprite
                transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
            }
        } else
        { // moving to the left
            if (transform.position.x < leftWaypoint.position.x) //checking if we have reached the waypoint
            {
                direction = !direction;
                //mySR.flipX = !mySR.flipX;
                transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
            }
        }

        if (is_dead)
        {
            dead_timer += Time.deltaTime;
            if (dead_timer >= dead_delay)
            {
                if (dead_setup)
                {
                    dead_setup = false;
                    GetComponent<BoxCollider2D>().enabled = false;
                    myRB.freezeRotation = false;
                    myRB.AddForce(new Vector2(Random.Range(-0.5f, 0.5f), Random.Range(100.5f, 300.5f)));
                    myRB.AddTorque(Random.Range(-100.0f, 100.0f));
                }
                transform.localScale *= 0.999f;
                
            }
            
        }

    }

    public void takeDamage()
    {
        is_dead = true;
        
        
        Destroy(transform.parent.gameObject, 2.0f);
    }

}
