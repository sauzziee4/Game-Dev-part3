using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneRate : MonoBehaviour
{
    //For the player
    GameObject[] player = null;
    float playerZ;

    //used to assign the enemy objects
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    
    //the enemy are put in a list
    public GameObject[] enemylist = null;

    //used to randomly spawn enemies
    float enemyID;

    //positions used for spawning
    float xPosID;
    float xPosE;
    float zPosE;
    float yPosE;



    //used to keep track of the enemies
    
    public float enemyMax;
    public float stage2Enemymax;

    public GameManager gm;

    //for the boss
    public GameObject Boss;
    bool BossActive = false;
    float bossXID;

    //used to assign the picups
    public GameObject pickup1;
    public GameObject pickup2;
    public GameObject pickup3;

    //the picups are placed in a list
    public GameObject[] pickuplist = null;

    public float pickupMax;
    float pickupID;

    
    


    //used so the objects dont spawn to close or to far from the player
    float zMax;
    float zMin;

    public float fixUpdateCount;

    // Start is called before the first frame update
    void Start()
    {
        

        player = GameObject.FindGameObjectsWithTag("Player");
        Coroutine EnGene = StartCoroutine(EnemySpawn2());
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

        //when the boss spawns the number of enemies that are spawned is reduced by four
        stage2Enemymax = enemyMax - 4;
        StartCoroutine(PickupSpawn());

    }


    // Update is called once per frame
    void Update()
    {
        //all enemies are added to the enenmy list
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");

        //all picups are added to the pickup list
        pickuplist = GameObject.FindGameObjectsWithTag("Pickup");

        playerZ = player[0].GetComponent<Transform>().position.z;

        //the minimum distance an object can spawn
        zMin = playerZ + 20;

        //the maximum distance an object can spawn
        zMax = playerZ + 40;


        
        //if we are in stage 1 enemy spawning starts
        
        
            StartCoroutine(EnemySpawn2());

        

        //if we are in stage 2 the maximum amount of enemies is adjusted
        
        
            


        
        
       


    }
    private void FixedUpdate()
    {
        //used for spawning th eboss
        fixUpdateCount++;
        if (fixUpdateCount == 6000)
        {
            StartCoroutine(SpawnBoss());
            

        }
    }

    IEnumerator PickupSpawn()
    {
        //while the list length is less then the maximum amount of picups
        while (pickuplist.Length < pickupMax)
        {
            //used for the z position of the pickup
            zPosE = Random.Range(zMin, zMax);

            //used to select which of the three lanes a pickup will spawn
            xPosID = Random.Range(0, 3);
            if (xPosID == 0)
            {
                xPosE = -3f;

            }
            if (xPosID == 1)
            {
                xPosE = 0f;
            }
            else if (xPosID == 2)
            {
                xPosE = 3f;
            }
            yPosE = 1;

            //used to random choose the pickup that will spawn
            pickupID = Random.Range(0, 3);
            if (pickupID == 0)
            {
                Instantiate(pickup1, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);

            }
            if (pickupID == 1)
            {
                Instantiate(pickup2, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);

            }
            if (pickupID == 2)
            {
                Instantiate(pickup3, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);

            }
            pickuplist = GameObject.FindGameObjectsWithTag("Pickup");


        }
        // ensures that there is a time delay between each pickup being spawned
        yield return new WaitForSeconds(10);

    }

    //used to spawn enemies
    IEnumerator EnemySpawn2()
    {
        // ensures there are not more enemies then the maximum
        while (enemylist.Length < enemyMax)
        {


            //used for the z position of the enemies
            zPosE = Random.Range(zMin, zMax);

            //used to select which of the three lanes an enemy will spawn
            xPosID = Random.Range(0, 3);
            if (xPosID == 0)
            {
                xPosE = -3f;

            }
            if (xPosID == 1)
            {
                xPosE = 0f;
            }
            else if (xPosID == 2)
            {
                xPosE = 3f;
            }
            yPosE = 1;

            //used to random choose the enemy that will spawn
            enemyID = Random.Range(0, 5);
            if (enemyID == 0)
            {
                yPosE = 0.5f;
                
                Instantiate(Enemy1, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
                
            }
            if (enemyID == 1)
            {
                //this enemy is only allowed to spawn in the two of the three lanes
                xPosID = Random.Range(0, 2);
                if (xPosID == 0)
                {
                    xPosE = -3f;

                }
                if (xPosID == 1)
                {
                    xPosE = 3f;
                }
                //the enemy needs to be rotated when it spawns
                Quaternion enemyRot = Quaternion.Euler(0, 180, 0);
                Instantiate(Enemy2, new Vector3(xPosE, yPosE, zPosE), enemyRot);
                

            }
            if (enemyID == 2)
            {

                //the enemy needs to be rotated when it spawns, 
                Quaternion enemyRot = Quaternion.Euler(0, 180, 0);
                Instantiate(Enemy3, new Vector3(xPosE, yPosE, zPosE), enemyRot);
                //e3count++;

            }
            if (enemyID == 3)
            {
                Instantiate(Enemy4, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
                
            }
            if (enemyID == 4)
            {
                //the enemy needs to be rotated when it spawns
                Quaternion enemyRot = Quaternion.Euler(0, 180, 0);
                Instantiate(Enemy5, new Vector3(xPosE, yPosE, zPosE), enemyRot);

            }
           
           
            yield return new WaitForSeconds(0.1f);


            //ensures the enemies are added to the enemylist
            enemylist = GameObject.FindGameObjectsWithTag("Enemy");

            
            


        }

        yield return new WaitForSeconds(0.1f);

    }



    IEnumerator SpawnBoss()
    {
        //at the moment there will only be one boss active at a time
        while (BossActive == false)
        {
            //the boss spawns in between the lanes
            bossXID = Random.Range(0, 2);
            if (bossXID == 0)
            {
                xPosE = -1;
            }
            if (bossXID == 1)
            {
                xPosE = 1;
            }

            zPosE = Random.Range(zMin, zMax);
            yPosE = 1;

            //the boss need to be rotated
            Quaternion boss = Quaternion.Euler(0, 90, 0);
            Instantiate(Boss, new Vector3(xPosE, yPosE, zPosE),boss);

            //the gamemanager is told that a boss has spawned
            
            
            //exits the while loop
            BossActive = true;

            
            
        }


        yield return new WaitForSeconds(5);

    }


}

