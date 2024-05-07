using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyGen : MonoBehaviour
{

    GameObject[] player = null;
    float playerZ;
    public GameObject Enemy;

    public GameManager gm;
    GameObject[] position = null;

    
    
    public GameObject Boss;
    public bool BossActive = false;
    

    

    float zMax;
    public float zMin;

    public float enemyMax;

    //Enemy positions
    float xPosEID;
    float xPosE;

    float zPosE;
    float yPosE;
     public float enemyCount;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //boss = GameObject.FindGameObjectsWithTag("Boss");
        
        player = GameObject.FindGameObjectsWithTag("Player");

        position = GameObject.FindGameObjectsWithTag("Utility");

        Coroutine EnGene = StartCoroutine(EnemySpawn());

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //position = GameObject.FindGameObjectsWithTag("utility");
        //Coroutine PiGen = StartCoroutine(PickUp());


    }

    // Update is called once per frame
    void Update()
    {
        playerZ = player[0].GetComponent<Transform>().position.z;



       
           

       
        
            zMin = playerZ + 10;
            zMax = playerZ + 20;
            //Debug.Log("player spawned");


        
        
        //compares the actual amount of enemies to the local enemycount varaible
        if(gm.totalEnemyCount < enemyCount)
        {
            enemyCount = gm.totalEnemyCount;
            StartCoroutine(EnemySpawn());

        }

        if(GameManager.Instance.stage==2)
        {
            StartCoroutine(SpawnBoss());
            

        }

    }
    IEnumerator EnemySpawn()
    {
       new WaitForSeconds(5);

        while (enemyCount < enemyMax)
        {

            //basic spawning between three lanes
            xPosEID = Random.Range(0, 3);
            if (xPosEID == 0)
            {
                xPosE = -3;

            }
            if (xPosEID == 1)
            {
                xPosE = 0;
            }
            else
            {
                xPosE = 3;
            }
            zPosE = Random.Range(zMin, zMax);
            //Debug.Log(enemyCount);
            //Debug.Log(enemyMax);

            Instantiate(Enemy, new Vector3(xPosE, 1, zPosE), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount++;
            //when an enemy has spawned the gamemaster it notified
            gm.EnemySpawn();
            
         

        }
        
    }
    IEnumerator SpawnBoss()
    {
        while(BossActive==false)
        {
            xPosE = 0f;
            zPosE = Random.Range(zMin, zMax);
            yPosE=1.5f;
            Instantiate(Boss, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
            BossActive = true;
            gm.BossSpawn();
            //Debug.Log("boss spawneed");
        }
        

       




        yield return new WaitForSeconds(5);

    }
    
    

      
        


}
