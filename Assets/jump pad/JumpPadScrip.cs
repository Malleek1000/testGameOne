using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPadScrip : MonoBehaviour
{

    public GameObject JumpPadForce;
    public float multiplier;      



    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        Rigidbody2D collisionRB = collision.attachedRigidbody;
        if (collisionRB != null)
        {
            collisionRB.AddForce(JumpPadForce.transform.localPosition * multiplier);
            //Debug.Log("here");
        }       



    }








} 
