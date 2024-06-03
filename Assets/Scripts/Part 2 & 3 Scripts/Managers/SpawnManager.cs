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
    public GameObject[] enemylist = null;

    public int bossSpawnDelay = 10;
    



    public List<GameObject> level1Obstacles;
    public List<GameObject> level2Obstacles;

    private List<GameObject> currentObstacles;
    private List<Transform> currentSpawnPoints=new List<Transform>();
    public GameObject obstacleToSpawn;

    private string currentLevelName = "Level1";

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnBoss2Spawned.AddListener(StartBossSpawnDelay);
        GameManager.Instance.OnBoss1Spawned.AddListener(StartBossSpawnDelay);
        //UpdateCurrentLevel();
        Coroutine EnGene =StartCoroutine(SpawnEnemiesRoutine());
        


        //UpdateCurrentLevel();

    }
    
    private void StartBossSpawnDelay()
    {
        Debug.Log("in start spawndelay metrhod");
        spawnEnemies = false;
        
        
        StartCoroutine(BossSpawnDelay());
        
        
    }
    public IEnumerator BossSpawnDelay()
    {
        Debug.Log("in spawn delay coroutine");
        yield return new WaitForSeconds(bossSpawnDelay);
        
        
        if (currentLevelName == "Level1")
        {
           Debug.Log("abou to enter boss spawn method");
           SpawnBoss1();

        }
        if (currentLevelName == "Level2")
        {
             SpawnBoss2();
        }
        

        
       
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
        Debug.Log("in boss spawn method");
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("spawnPointTag");
        GameObject spawnPoint = spawnPointObjects[Random.Range(0, spawnPoints.Length)];
        
        
        Quaternion boss = Quaternion.Euler(0, 90, 0);
        Instantiate(Boss1, spawnPoint.transform.position, boss);
        StartCoroutine(EndBossAfterDelay());

    }
    private void SpawnBoss2()
    {
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("spawnPointTag");
        GameObject spawnPoint = spawnPointObjects[Random.Range(0, spawnPoints.Length)];
        
        
        Quaternion boss = Quaternion.Euler(0, 90, 0);
        Instantiate(Boss2, spawnPoint.transform.position, boss);
        StartCoroutine(EndBossAfterDelay());

    }
    private IEnumerator EndBossAfterDelay()
    {
        Debug.Log("in boss aftyer delay");
        yield return new WaitForSeconds(bossSpawnDelay);
        DestroyBoss();
    }
    private void DestroyBoss()
    {
        Debug.Log("In boss destroy method");
        GameObject boss = GameObject.FindGameObjectWithTag("Boss");
        if (boss != null)
        {
            Destroy(boss);
            GameManager.Instance.DefeatBoss();
        }
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
   
   
    
}
