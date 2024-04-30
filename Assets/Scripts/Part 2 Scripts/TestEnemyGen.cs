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

    //
    //GameObject[] boss = null;
    public GameObject Boss;
    public bool BossActive = false;

    

    float zMax;
    public float zMin;

    public float enemyMax;
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



        //If the player has moved past the starting position the enmies spawn normally
        if (position[0].GetComponent<Transform>().position.z < playerZ)
        {
            zMin = playerZ + 20;
            zMax = playerZ + 40;
            //Debug.Log("player has moved");

        }
        //if the player is in the starting position the enemies spawn closer, this is so the enmies dont spawn to far in front of the player before the levels have started to generate
        else
        {
            zMin = playerZ + 10;
            zMax = playerZ + 20;
            //Debug.Log("player spawned");


        }
        
        //compares the actual amount of enemies to the local enemycount varaible
        if(gm.totalEnemyCount < enemyCount)
        {
            enemyCount = gm.totalEnemyCount;
            StartCoroutine(EnemySpawn());

        }

        if(GameManager.Instance.score> 40)
        {
            StartCoroutine(SpawnBoss());
            

        }

    }
    IEnumerator EnemySpawn()
    {
       new WaitForSeconds(5);

        while (enemyCount < enemyMax)
        {

            xPosE = Random.Range(-10, 10);
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
            xPosE = Random.Range(-10, 10);
            zPosE = Random.Range(zMin, zMax);
            yPosE=1.5f;
            Instantiate(Boss, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
            BossActive = true;
            Debug.Log("boss spawneed");
        }
        

       




        yield return new WaitForSeconds(5);

    }
    
    

      
        


}
