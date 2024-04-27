using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Generator : MonoBehaviour
{

    //GameObject[] player = null;
    //float playerZ;
    
    //float zMax;
    //public float zMin;



    //used for the obstacles
    public GameObject chair;
    public GameObject stool;
    public GameObject couch;
    public float EnemyMax;
    float xPosE;
    float zPosE;
    float yPosE;
    float enemyCount;
    float enemyID;

    //used for the pickup
    public GameObject pickup1;
    public GameObject pickup2;
    public GameObject pickup3;
    public int PickMax;
    float xPosP;
    float zPosP;
    float pickCount;
    float pickupID;
    
   
    // Start is called before the first frame update
    void Start()

    {
        //player = GameObject.FindGameObjectsWithTag("Player");
        Coroutine EnGen = StartCoroutine(EnemyDrop());
        Coroutine PiGen = StartCoroutine(PickUp());
        //zMin = 0;
        //zMax = 0;

    }

    private void Update()
    {
        //playerZ = player[0].GetComponent<Transform>().position.z;
       // zMin = playerZ + 20;
        //zMax = playerZ + 40;
       // Debug.Log(zMin);
       // Debug.Log(zMax);


    }

    //Generates the pickups
    IEnumerator PickUp() 
    {
        while (pickCount < PickMax)
        {
            //Generates the postions within the ranges
            xPosP = Random.Range(-5, 6);
            zPosP = Random.Range(-28, 9);

            
            pickupID = Random.Range(1, 4);
            if (pickupID ==1)
            {
                Quaternion targetP = Quaternion.Euler(0, 0, 90);
                Instantiate(pickup1, new Vector3(xPosP, 3f, zPosP), targetP);
                


            }
            else if (pickupID ==2)
            {

                
                Instantiate(pickup2, new Vector3(xPosP, 3f, zPosP), Quaternion.identity);

            }
            else if (pickupID ==3)
            {

                
                Instantiate(pickup3, new Vector3(xPosP, 3f, zPosP), Quaternion.identity);

            }
            yield return new WaitForSeconds(0.1f);
            pickCount++;

            
        }
        
        
    }
    
    //Generates the enemies
    IEnumerator EnemyDrop()
    {
        //genertaes the enemy
        while (enemyCount < EnemyMax)
        {
            //Generates the postions within the ranges
            xPosE = Random.Range(-5, 6);
            zPosE = Random.Range(0, 5);
            enemyID = Random.Range(1, 4);

            //Generates a chair obstacle
            if (enemyID == 1)
            {
                yPosE = 1.35f;
                Instantiate(chair, new Vector3(xPosE, 1.25f, zPosE), Quaternion.identity);

            }
            //Generates a stool obstacle
            else if (enemyID == 2)
            {
                Quaternion targetE = Quaternion.Euler(-180, 0, 0);
                yPosE = 0.7f;
                Instantiate(stool, new Vector3(xPosE, yPosE, zPosE), targetE);

            }
            //Generates a couch obstacle
            else if (enemyID == 3)
            {
                Quaternion targetE = Quaternion.Euler(0, -90, 90);
                yPosE = 1f;
                Instantiate(couch, new Vector3(xPosE, yPosE, zPosE), targetE);

            }

            yield return new WaitForSeconds(0.1f);
            enemyCount++;
        }

    }

  
}

