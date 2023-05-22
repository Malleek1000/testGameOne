using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myplayercontroller : MonoBehaviour
{
    
    public float speed;
    public float jumpPower;
    public Rigidbody2D myPhysics;

    //amogus
    // Start is called before the first frame update
    void Start()
    {
        
    // Update is called once per frame
    void Update()
    {

       if(Input.GetKey(KeyCode.A))
        {
            myPhysics.AddForce(Vector2.left * speed * Time.deltaTime);
        } 
    }
}
