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
    public GameObject Enemy1;
    
    public GameObject Enemy2;
    
    public GameObject Enemy3;
    
    public GameObject Enemy4;
    


    GameObject[] enemylist = null;
    GameObject[] enemy1List = null;


    float enemyID;

    //Enemy positions
    float xPosID;
    float xPosE;
    float zPosE;
    float yPosE;

    public float xLane1;
    public float xLane2;
    public float xLane3;


    public float enemyCount;
    public float enemyMax;
    public float stage2Enemymax;


   

    public GameManager gm;
    

    
    //for the boss
    public GameObject Boss;
     bool BossActive = false;
    


    float zMax;
    float zMin;


    //public Vector3[] spawns;
    
    private Vector3 posti;
    //a hash map, 
    private HashSet<Vector3> positions;

    



    


    public float fixUpdateCount;

    // Start is called before the first frame update
    void Start()
    {
        //boss = GameObject.FindGameObjectsWithTag("Boss");
        
        player = GameObject.FindGameObjectsWithTag("Player");
        Coroutine EnGene = StartCoroutine(EnemySpawn2());
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        stage2Enemymax = enemyMax - 2;
       
    }
    private void Awake()
    {
        positions = new HashSet<Vector3>();

    }

    // Update is called once per frame
    void Update()
    {
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");
        
        for (int i = 0; i < enemylist.Length; i++)
        {
            if (enemylist[i].transform.position.x == -3)
            {
                xLane1++;

            }
            if (enemylist[i].transform.position.x == 0)
            {
                xLane2++;
            }
            if (enemylist[i].transform.position.x == 3)
            {

                xLane3++;
            }
            if (enemylist[i].name=="Enemy1 (clone)")
            {
                Debug.Log("hello");
            }
        }
           
        

        playerZ = player[0].GetComponent<Transform>().position.z;


        zMin = playerZ + 10;
        zMax = playerZ + 20;
            

        //compares the actual amount of enemies to the local enemycount varaible
        
        if(GameManager.Instance.stage==1)
        {
            StartCoroutine(EnemySpawn2());

        }
         
        if(GameManager.Instance.stage==2)
        {
            enemyMax = stage2Enemymax;
            StartCoroutine(EnemySpawn2());
            StartCoroutine(SpawnBoss());
            
        }

        
    }
    private void FixedUpdate()
    {
        fixUpdateCount++;
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

            enemyID = Random.Range(0, 4);

            if (enemyID == 0)
            {
                
                Instantiate(Enemy1, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
                //e1Count++;
            }
            if (enemyID == 1)
            {
              
                
               
                Instantiate(Enemy2, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
                //e2Count++;

            }
            if (enemyID == 2)
            {
                yPosE = 2;
                //posti = new Vector3(xPosE, 2, zPosE);
                Instantiate(Enemy3, new Vector3(xPosE,yPosE,zPosE), Quaternion.identity);
                //e3count++;

            }
            if (enemyID == 3)
            {
                Instantiate(Enemy4, new Vector3(xPosE, yPosE, zPosE), Quaternion.identity);
                //e4Count++;
            }
            yield return new WaitForSeconds(0.1f);
            enemyCount++;
            //Debug.Log(enemyCount);
            //when an enemy has spawned the gamemaster it notified
            gm.EnemySpawn();

            
            enemylist = GameObject.FindGameObjectsWithTag("Enemy");
            enemyCount = enemylist.Length;


        }




        yield return new WaitForSeconds(0.1f);

    }
    
    
    
       
        


       
        

          
                
              

                


            //}
            //Debug.Log(xPosE);

        
        
    
    IEnumerator SpawnBoss()
    {
        while(BossActive==false)
        {
            xPosE = -3f;
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
