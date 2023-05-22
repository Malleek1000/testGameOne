using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerController : MonoBehaviour
{
   
   // amogus
    
    public float speed;
    public float jumpower;
    public Rigidbody2D myPhysics;





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
            myPhysics.AddForce(Vector2.up * speed * Time.deltaTime);
        }










    }
}
