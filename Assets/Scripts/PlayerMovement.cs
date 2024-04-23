using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    public float movementSpeed = 6f;
    public float jumpForce = 5f;

    //used for the pickup
    float speedAdjustmentCount = 0;
    float speedAdjustment = 3;
    float exampleCount = 0;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //gets the horizontal and veritcal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity =new Vector3 (horizontalInput* movementSpeed,rb.velocity.y, verticalInput* movementSpeed);
        //horizontalInput handles moving left and right

        //Handles the jumping
        if(Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3 (rb.velocity.x,jumpForce,rb.velocity.z);
        }
//if a player pickups a catnip pickup they increase in speed
        if (ItemCollector.collectibles > speedAdjustmentCount)
        {
            Debug.Log("entering speed increase");
            movementSpeed = movementSpeed + speedAdjustment;
           
            speedAdjustmentCount++;
            //new WaitForSecondsRealtime(40f);
            while (exampleCount<6)
            {
                exampleCount++;
            }
            movementSpeed = 6f;
            Debug.Log("exiting speed increase");

        }
        

    }
}

