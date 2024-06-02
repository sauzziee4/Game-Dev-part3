using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{

    public SpawnManager Instance;

    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public GameObject enemyPrefab5;
    public GameObject enemyPrefab6;
    public Transform[] spawnPoints;
    public bool spawnEnemies = true;
    public GameObject Boss1;
    public GameObject Boss2;
    public Vector3[] spawnCoordinates = new Vector3[3];
    float enemyID;
    


    public List<GameObject> level1Obstacles;
    public List<GameObject> level2Obstacles;

    private List<GameObject> currentObstacles;
    private List<Transform> currentSpawnPoints=new List<Transform>();
    public GameObject obstacleToSpawn;

    private string currentLevelName = "Level1";

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnBoss2Spawned.AddListener(SpawnBoss2);
        GameManager.Instance.OnBoss1Spawned.AddListener(SpawnBoss1);
        //UpdateCurrentLevel();
        Coroutine EnGene =StartCoroutine(SpawnEnemiesRoutine());
        


        //UpdateCurrentLevel();

    }
    
    private IEnumerator SpawnEnemiesRoutine()
    {
        while (spawnEnemies ==true)
        {
            GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("spawnPointTag");
            GameObject spawnPoint = spawnPointObjects[Random.Range(0, spawnPoints.Length)];

            if (currentLevelName =="Level1")
            {
                int Enemytype = Random.Range(1, 4);
                enemyID = Random.Range(0, 4);
                if (enemyID == 0)
                {
                    Instantiate(enemyPrefab1, spawnPoint.transform.position, Quaternion.identity);

                }
                if (enemyID == 1)
                {
                    Instantiate(enemyPrefab2, spawnPoint.transform.position, Quaternion.identity);

                }
                if (enemyID == 2)
                {
                    Instantiate(enemyPrefab3, spawnPoint.transform.position, Quaternion.identity);

                }
                if(enemyID == 3)
                {
                    Instantiate(enemyPrefab4, spawnPoint.transform.position, Quaternion.identity);


                }
                if (enemyID == 4)
                {
                    Instantiate(enemyPrefab5, spawnPoint.transform.position, Quaternion.identity);

                }

            }
            if (currentLevelName =="Level2")
            {
                int Enemytype = Random.Range(1, 4);
                enemyID = Random.Range(0, 4);
                if (enemyID == 0)
                {
                    Instantiate(enemyPrefab1, spawnPoint.transform.position, Quaternion.identity);

                }
                if (enemyID == 1)
                {
                    Instantiate(enemyPrefab2, spawnPoint.transform.position, Quaternion.identity);

                }
                if (enemyID == 2)
                {
                    Instantiate(enemyPrefab3, spawnPoint.transform.position, Quaternion.identity);

                }
                if (enemyID == 3)
                {
                    Instantiate(enemyPrefab4, spawnPoint.transform.position, Quaternion.identity);


                }
                if (enemyID == 4)
                {
                    Instantiate(enemyPrefab5, spawnPoint.transform.position, Quaternion.identity);

                }

            }

            yield return new WaitForSeconds(1f);
        }
    }
    
    private void SpawnBoss1()
    {
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("spawnPointTag");
        GameObject spawnPoint = spawnPointObjects[Random.Range(0, spawnPoints.Length)];
        spawnEnemies = false;
        
        Quaternion boss = Quaternion.Euler(0, 90, 0);
        Instantiate(Boss1, spawnPoint.transform.position, boss);

    }
    private void SpawnBoss2()
    {
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("spawnPointTag");
        GameObject spawnPoint = spawnPointObjects[Random.Range(0, spawnPoints.Length)];
        spawnEnemies = false;
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Quaternion boss = Quaternion.Euler(0, 90, 0);
        Instantiate(Boss2, spawnPoint.transform.position, boss);

    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
   
   
    private void SpawnEnemy()
    {
        
       // if(LevelManager.Instance.currentLevelName!= "GameOver")
       // {
            //currentLevelName = LevelManager.Instance.currentLevelName;
            //Debug.Log(currentLevelName);

            //gets the spawnpoints
            




            //GameObject obstacleToSpawn = null;
            //if we are in level1 we load level1obstacles but first we randomly choose one of the level one obstacles
            //if (currentLevelName =="Level1")
            //{
               // GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("spawnPointTag");
               // GameObject spawnPoint = spawnPointObjects[Random.Range(0, spawnPoints.Length)];


                //int Enemytype = Random.Range(1, 4);
                //enemyID = Random.Range(0, 2);
                //if (enemyID == 0)
             //   {
              //      Debug.Log("spawning first enemy type");
             //       Instantiate(enemyPrefab1,spawnPoint.transform.position, Quaternion.identity);

              //  }
             //   if (enemyID == 1)
              //  {
                //    Debug.Log("spawning second enemy type");
               //     Instantiate(enemyPrefab2, spawnPoint.transform.position, Quaternion.identity);
        //
               // }
            //    if (enemyID == 2)
                {
                 //   Instantiate(enemyPrefab3, spawnPoint.transform.position, Quaternion.identity);
                   // Debug.Log("spawning third enemy type");

                }





            ///}
           // if (currentLevelName =="Level2")
            //{

            //}
            //switch (currentLevelName)
            //{
                //case "Level1":
                    //obstacleToSpawn = level1Obstacles[Random.Range(0, level1Obstacles.Count)];
                    //break;
               // case "Level2":
                  //  obstacleToSpawn = level2Obstacles[Random.Range(0, level2Obstacles.Count)];
                 //   break;

            //}
            //choose a random spawnpoint
            //GameObject spawnPoint = spawnPointObjects[Random.Range(0, spawnPoints.Length)];

            //Instantiate(obstacleToSpawn, Pos1, Quaternion.identity);

       // }
       // else
        //{
            //Debug.Log("the game is over");
        //}
        
        
        


       
    }
}
