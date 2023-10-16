using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bugscript : MonoBehaviour
{

    public float speed = 6.0f;
    public Rigidbody2D myRB;
    public float jumpForce = 600.0f;
    public float mobJumpForce = 300.0f; // jump off mobs multiplyer
    public float maxSpeed = 4.0f;
    public Animator myAnimator;
    private int state = 1; // 1 = idle, 2 = walking
    public bool isFacingLeft = true;
    private bool spriteFacingLeft;
    public bool can_jump = true;
    private bool is_dead = false;
    private bool dead_setup = true;
    private float dead_timer = 0.0f;
    public float dead_delay = 3.0f;
    public string game_over_scene_name;

    // Start is called before the first frame update
    void Start()
    {
        spriteFacingLeft = isFacingLeft;
    }

    // Update is called once per frame
    void Update()
    {

        if (!is_dead)
        {
            if (Input.GetKey(KeyCode.A))
            {
                myRB.AddForce(Vector2.left * speed);

            }

            if (Input.GetKey(KeyCode.D))
            {
                myRB.AddForce(Vector2.right * speed);

            }

            if (Input.GetKeyDown(KeyCode.W) && can_jump)
            {
                Jump(jumpForce);


            }


            //don't go faster than the max speed
            float currentSpeed = myRB.velocity.x;
            currentSpeed = Mathf.Clamp(currentSpeed, -1.0f * maxSpeed, maxSpeed);
            myRB.velocity = new Vector2(currentSpeed, myRB.velocity.y);
            //frog

            //change the animation if walking or idle
            if (myAnimator)
            {
                myAnimator.ResetTrigger("walking");
                myAnimator.ResetTrigger("standing");
            }
            
            if (Mathf.Abs(currentSpeed) > 0.01f)
            //if (currentSpeed != 0.0f)
            {
                if (state == 1) //state 1 = idle
                {
                    if (myAnimator)
                    {
                        myAnimator.SetTrigger("walking");
                    }
                        
                    state = 2;
                }
            }
            else
            {
                if (state == 2) //state 2 = walking
                {
                    if (myAnimator)
                    {
                        myAnimator.SetTrigger("standing");
                    }
                        
                    state = 1;
                }
            }

            //flip sprite to face direction
            if (currentSpeed > 0.0f && spriteFacingLeft)
            {
                //myRenderer.flipX = !myRenderer.flipX;
                transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                spriteFacingLeft = !spriteFacingLeft;
            }
            else if (currentSpeed < 0.0f && !spriteFacingLeft)
            {
                //myRenderer.flipX = !myRenderer.flipX;
                transform.localScale = new Vector3(transform.localScale.x * -1.0f, transform.localScale.y, transform.localScale.z);
                spriteFacingLeft = !spriteFacingLeft;
            }
        }
        else
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
            dead_timer += Time.deltaTime;
            if (dead_timer >= dead_delay)
            {
                SceneManager.LoadScene(game_over_scene_name);

            }
        }
    }

    public void Jump(float power)
    {
        myRB.AddForce(Vector2.up * power);
        can_jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        can_jump = true;
        if (collision.tag == "enemy" && !is_dead)
        {
            Debug.Log("jump on enemy, killing enemy");
            collision.GetComponent<mobScript>().takeDamage();
            if (Input.GetKey(KeyCode.W) || Input.GetKeyDown(KeyCode.W))
            {
                Jump(mobJumpForce);
            }
            Jump(jumpForce);
        } else
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Debug.Log("collision with enemy");
            if (!collision.gameObject.GetComponent<mobScript>().is_dead)
            {
                Debug.Log("enemy not dead killing player");
                is_dead = true;
            }
            
        }
    }

}

//hello
//hello to you to