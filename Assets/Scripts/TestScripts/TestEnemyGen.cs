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
    //public int start = -7;
    
    // Start is called before the first frame update
    void Start()
    {
        //zMin = 10;
        //zMax = 20;
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

        if (position[0].GetComponent<Transform>().position.z < playerZ)
        {
            zMin = playerZ + 20;
            zMax = playerZ + 40;
            //Debug.Log("player has moved");

        }
        else
        {
            zMin = playerZ + 10;
            zMax = playerZ + 20;
            //Debug.Log("player spawned");


        }
        
        //zMin = playerZ + 20;
        //zMax = playerZ + 40;
        //Debug.Log(zMin);
        //Debug.Log(zMax);
        //if (enemyCount<enemyMax)
        //{
            //StartCoroutine(EnemySpawn());
        //}
        if(gm.enemyCounting< enemyCount)
        {
            enemyCount = gm.enemyCounting;
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
            gm.EnemySpawn();
            





        }
        



    }
    

      
        


}
