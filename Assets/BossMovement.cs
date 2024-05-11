using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float _speed = 2f;
     public bool ChangeMov = false;
    GameObject[] enemy2List = null;
    float i;
    public float movementDifference;
    float bossZ;
    float bossX;
    float bossXTemp;
    float EnemyX;
    bool moveRight = false;
    bool moveLeft = false;
    bool potCol=false;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        enemy2List = GameObject.FindGameObjectsWithTag("Enemy");


        
        if (potCol==false)
        {
            Debug.Log("potcal is false and we are going into Movment check");
            MovementCheck();

        }
        if( moveRight==true)
        {
            Debug.Log("In update, moveright is" + moveRight);
            MoveRight();
            //MovementChange(bossXTemp);
        }
        if ( moveLeft==true)
        {
            Debug.Log("In update moveleft is"+moveLeft);
            MoveLeft();
        }
            

        
       

        
        

        
    }
    void MovementCheck()
    {
        Debug.Log("In movment check");
        bossZ= GetComponent<Transform>().position.z;
        bossX= GetComponent<Transform>().position.x;
        movementDifference = 2;
        //transform.Translate(Vector3.back* _speed* Time.deltaTime);
        
        //goes through the enemy list
        for(int i = 0; i < enemy2List.Length; i++)
        {
            
            //if an enemys x coordinate is the same as the bosses x coordinate we enter loop
            if (enemy2List[i].transform.position.x ==bossX )
            {
                //Debug.Log(" an enemy has the same x as the boss");
                //Debug.Log("boss info");
                //Debug.Log("boss z is"+bossZ);
               
                //Debug.Log("Enemy z is"+enemy2List[i].transform.position.z);
                
                //if the enemys z position is within 3 int of the boses z positonj we enter if
                if (bossZ -enemy2List[i].transform.position.z <movementDifference )
                {
                    Debug.Log("We are in movment check and are going to call movment change");
                    //we tell the boss to change movment as it is about to collide
                    bossXTemp = bossX;
                    MovementChange(bossXTemp);
                    potCol = true;
                }
                
                
                
            }


        }
        // if the boss did not need to change move we can have the boss move normally
        if(potCol==false)
        {
            NormalMovement();
        }


        
    }
    void NormalMovement()
    {
        Debug.Log("Normal movement");
        transform.position += new Vector3(0, 0, -1) * _speed * Time.deltaTime;

    }
    void MovementChange(float bossXTemp)
    {
        Debug.Log("in movement change");
        bossX = GetComponent<Transform>().position.x;
        if (bossXTemp==-3)
        {
            MoveRight();
            
            
        }
        if (bossXTemp==0)
        {
            potCol = false;
        }
        if (bossXTemp==3)
        {
            Debug.Log("bossXTemp is" + bossXTemp);
            //MoveLeft();

        }
        //if(bossX==0)
        //{
            //NormalMovement();


        //}

        
            
        
        

    }
    private void MoveRight()
    {
        moveRight = true;
        Debug.Log("Moving right");
        transform.position += new Vector3(3, 0, -6) * Time.deltaTime;
        bossX= GetComponent<Transform>().position.x;
        if (bossX>0)
        {
            potCol = false;
            moveRight = false;
           
        }


    }
    void MoveLeft()
    {
        moveLeft= true;
        Debug.Log("Moving left");
        transform.position += new Vector3(-3, 0, -6) * Time.deltaTime;
        bossX = GetComponent<Transform>().position.x;
        if (bossX == 0)
        {
            potCol = false;
            moveLeft= false;
        }

    }
    void MiddleLane()
    {
       



    }
}
