using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    [SerializeField]
    private float horizontalInput;
    private float verticalInput;
    private Vector3 movedirection;
    private Rigidbody objRb;
    public float speed;
    public float speed2 = 2f;
    public Vector3 jump;
    public float jumpForce;
    private const float Gravity = -9.18f;
    [SerializeField]
    private float gravityScaleMultiplier = 50;

    //3 lanes
    private int desiredLane = 1; //0: left 1: middle 2: right
    public float laneDistance = 4; //distance between two lanes


    private bool IsGrounded()
    {
        //will now allow for the user to double jump
        return Mathf.Approximately(objRb.velocity.y, 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        objRb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        movedirection = new Vector3 (horizontalInput, 0);

        transform.position += transform.forward * (speed2 * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            objRb.AddForce(jump * jumpForce, ForceMode.Impulse);
        }

        //Gather inputs on which lane we shopuld be 
        if(Input.GetKeyDown(KeyCode.D))
        {
            desiredLane++;
            if(desiredLane == 3)
            {
                desiredLane = 2;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.A))
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        //Calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = targetPosition;

    }

    private void FixedUpdate()
    {
        objRb.velocity = movedirection * speed * Time.fixedDeltaTime;

        objRb.AddForce(Gravity * gravityScaleMultiplier * Vector3.up, ForceMode.Acceleration);
    }
}
