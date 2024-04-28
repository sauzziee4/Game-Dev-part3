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
    

      
        


}
