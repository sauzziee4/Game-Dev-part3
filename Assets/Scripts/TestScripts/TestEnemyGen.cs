using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyGen : MonoBehaviour
{

    GameObject[] player = null;
    float playerZ;
    public GameObject Enemy;

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
        Coroutine EnGene = StartCoroutine(EnemySpawn());
        //Coroutine PiGen = StartCoroutine(PickUp());
        zMin = 10;
        zMax = 20;

    }

    // Update is called once per frame
    void Update()
    {
        playerZ = player[0].GetComponent<Transform>().position.z;
        zMin = playerZ + 10;
        zMax = playerZ + 20;
        //Debug.Log(zMin);
        //Debug.Log(zMax);
        //if (enemyCount<enemyMax)
        //{
            //StartCoroutine(EnemySpawn());
        //}

    }
    IEnumerator EnemySpawn()
    {
       new WaitForSeconds(5);

        while (enemyCount < enemyMax)
        {

            xPosE = Random.Range(-5, 6);
            zPosE = Random.Range(zMin, zMax);
            Debug.Log(enemyCount);
            Debug.Log(enemyMax);

            Instantiate(Enemy, new Vector3(xPosE, 1, zPosE), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount++;





        }
        



    }

      
        


}
