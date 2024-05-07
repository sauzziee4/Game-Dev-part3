using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemyGen : MonoBehaviour
{
    //For the player
    GameObject[] player = null;
    float playerZ;

    //for the enemy
    public GameObject Enemy;
    //Enemy positions
    float xPosEID;


    float xPosE;
    float zPosE;
    float yPosE;

    public float enemyCount;
    public float enemyMax;


   

    public GameManager gm;
    

    
    //for the boss
    public GameObject Boss;
    public bool BossActive = false;
    


    float zMax;
    public float zMin;


    //public Vector3[] spawns;
    
    private Vector3 posti;
    //a hash map, 
    private HashSet<Vector3> positions;

    public bool creatingEnemy = false;

    public int i;



    GameObject[] enemylist = null;

    // Start is called before the first frame update
    void Start()
    {
        //boss = GameObject.FindGameObjectsWithTag("Boss");
        
        player = GameObject.FindGameObjectsWithTag("Player");

        

        Coroutine EnGene = StartCoroutine(EnemySpawn());

        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //position = GameObject.FindGameObjectsWithTag("utility");
        //Coroutine PiGen = StartCoroutine(PickUp());
       

    }
    private void Awake()
    {
        positions = new HashSet<Vector3>();

    }

    // Update is called once per frame
    void Update()
    {
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");

        playerZ = player[0].GetComponent<Transform>().position.z;


            zMin = playerZ + 10;
            zMax = playerZ + 20;
            //Debug.Log("player spawned");

        //compares the actual amount of enemies to the local enemycount varaible
        
        
            
            StartCoroutine(EnemySpawn());

        

        if(GameManager.Instance.stage==2)
        {
            StartCoroutine(SpawnBoss());
            

        }

        
        

    }
    public void EnemyCount()
    {
        
        


    }
    IEnumerator EnemySpawn()
    {
       new WaitForSeconds(5);
        


        while (enemylist.Length < enemyMax)
        {
            //Debug.Log(enemylist.Length);

            //basic spawning between three lanes
            xPosEID = Random.Range(0, 3);
            if (xPosEID == 0)
            {
                xPosE = -3f;

            }
            if (xPosEID == 1)
            {
                xPosE = 0f;
            }
            else if (xPosEID == 2)
            {
                xPosE = 3f;
            }
            zPosE = Random.Range(zMin, zMax);
            //Debug.Log(xPosE);

            //Debug.Log(xPosEID);
            posti = new Vector3(xPosE, 1, zPosE);
            
            //if the position crated is not in the map then that postiton is used to generate a enemy
            if (!positions.Contains(posti))
            {
                Instantiate(Enemy, posti, Quaternion.identity);

               //Debug.Log(posti.ToString());

                yield return new WaitForSeconds(0.1f);
                enemyCount++;
                //Debug.Log(enemyCount);
                //when an enemy has spawned the gamemaster it notified
                gm.EnemySpawn();

                positions.Add(posti);
                enemylist = GameObject.FindGameObjectsWithTag("Enemy");
                enemyCount =enemylist.Length;

            }
            //Debug.Log(xPosE);

        }
        Debug.Log(enemylist.Length);
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
