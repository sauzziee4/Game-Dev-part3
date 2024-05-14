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
    public float enemyCount;
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
        //boss = GameObject.FindGameObjectsWithTag("Boss");

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
        if (GameManager.Instance.stage == 1)
        {
            StartCoroutine(EnemySpawn2());

        }

        //if we are in stage 2 the maximum amount of enemies is adjusted
        if (GameManager.Instance.stage == 2)
        {
            enemyMax = stage2Enemymax;
            StartCoroutine(EnemySpawn2());


        }
        
       


    }
    private void FixedUpdate()
    {
        //used for spawning th eboss
        fixUpdateCount++;
        if (fixUpdateCount == 6000)
        {
            StartCoroutine(SpawnBoss());
            GameManager.Instance.stage = 2;

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

        yield return new WaitForSeconds(10);

    }


    IEnumerator EnemySpawn2()
    {
        while (enemylist.Length < enemyMax)
        {


            //These values are not dependent on the type of enemy
            zPosE = Random.Range(zMin, zMax);
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

            enemyID = Random.Range(0, 5);

            if (enemyID == 0)
            {
                yPosE = 0.5f;
                //table best y is 1
                Instantiate(Enemy1, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
                //e1Count++;
            }
            if (enemyID == 1)
            {
                xPosID = Random.Range(0, 2);
                if (xPosID == 0)
                {
                    xPosE = -3f;

                }
                if (xPosID == 1)
                {
                    xPosE = 3f;
                }
                //bed  best y is 1
                Quaternion bed = Quaternion.Euler(0, 180, 0);
                Instantiate(Enemy2, new Vector3(xPosE, yPosE, zPosE), bed);
                //e2Count++;

            }
            if (enemyID == 2)
            {

                //posti = new Vector3(xPosE, 2, zPosE);
                Quaternion bed = Quaternion.Euler(0, 180, 0);
                Instantiate(Enemy3, new Vector3(xPosE, yPosE, zPosE), bed);
                //e3count++;

            }
            if (enemyID == 3)
            {
                Instantiate(Enemy4, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
                //e4Count++;
            }
            if (enemyID == 4)
            {
                Quaternion armchair = Quaternion.Euler(0, 180, 0);
                Instantiate(Enemy5, new Vector3(xPosE, yPosE, zPosE), armchair);

            }
           
           
            yield return new WaitForSeconds(0.1f);



            enemylist = GameObject.FindGameObjectsWithTag("Enemy");
            enemyCount = enemylist.Length;


        }

        yield return new WaitForSeconds(0.1f);

    }



    IEnumerator SpawnBoss()
    {
        while (BossActive == false)
        {
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
            Quaternion boss = Quaternion.Euler(0, 90, 0);
            Instantiate(Boss, new Vector3(xPosE, yPosE, zPosE),boss);

            BossActive = true;
            gm.BossSpawn();
            //Debug.Log("boss spawneed");
        }


        yield return new WaitForSeconds(5);

    }


}

