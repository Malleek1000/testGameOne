using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myplayercontroller : MonoBehaviour
{
   
   // amogus
    
    public float speed;
    public float jumpower;
    public Rigidbody2D myPhysics;


    public float maxSpeed;
    public Animator myAnimator;
    public int state; // 1 =, 2 = walking 

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        if (Input.GetKey(KeyCode.A))
        {
            myPhysics.AddForce(Vector2.left * speed * Time.deltaTime);
        }



        if (Input.GetKey(KeyCode.D))
        {
            myPhysics.AddForce(Vector2.right * speed * Time.deltaTime);
        }


        //Jump code
        if (Input.GetKey(KeyCode.W))
        {
            myPhysics.AddForce(Vector2.up * jumpower * Time.deltaTime);
        }


        //dont go faster than max speed
        float currentSpeed = myPhysics.velocity.x;
        currentSpeed = Mathf.Clamp(currentSpeed, -1.0F * maxSpeed, maxSpeed);
        myPhysics.velocity = new Vector2(currentSpeed, myPhysics.velocity.y);
        
        
        
        

            
    
        
        
        
        
     
    













    }
}
