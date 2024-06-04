using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{

    public static SpawnManager Instance;

    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject enemyPrefab4;
    public GameObject enemyPrefab5;
    public GameObject enemyPrefab6;
    
    public bool spawnEnemies = true;
    public GameObject Boss1;
    public GameObject Boss2;
    
    float enemyID;
    

    public int bossSpawnDelay = 10;
    


    private string currentLevelName = "Level1";

    // Start is called before the first frame update
    void Start()
    {
        //InitializeSpawnPoints();
        GameManager.Instance.OnBoss2Spawned.AddListener(StartBossSpawnDelay);
        GameManager.Instance.OnBoss1Spawned.AddListener(StartBossSpawnDelay);
        //UpdateCurrentLevel();
        Coroutine EnGene =StartCoroutine(SpawnEnemiesRoutine());

        LevelManager.Instance.OnNextLevelLoad.AddListener(NextlevelEnemiesSpawn);



        

    }
    public void NextlevelEnemiesSpawn()
    {
        spawnEnemies = true; 
        StopAllCoroutines(); // Ensure any previous coroutine is stopped
         // Reinitialize spawn points in case of scene reload
        StartCoroutine(SpawnEnemiesRoutine());
    }
    private void GameOverStopSpawning()
    {
        spawnEnemies = false;
        StopCoroutine(SpawnEnemiesRoutine());
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
        while (spawnEnemies)
        {
            if (hardcodedSpawnPoints.Length == 0)
            {
                Debug.LogError("No hardcoded spawn points available. Aborting enemy spawn routine.");
                yield break; // Exit the coroutine if no spawn points are defined
            }

            Debug.Log("There are: " + hardcodedSpawnPoints.Length + " hardcoded spawn points");

            Vector3 spawningSpot = hardcodedSpawnPoints[Random.Range(0, hardcodedSpawnPoints.Length)];
            Debug.Log("Selected spawn point position: " + spawningSpot);

            if (currentLevelName == "Level1")
            {
                enemyID = Random.Range(0, 5);
                InstantiateEnemy(enemyID, spawningSpot);
            }
            else if (currentLevelName == "Level2")
            {
                enemyID = Random.Range(0, 5);
                InstantiateEnemy(enemyID, spawningSpot);
            }

            yield return new WaitForSeconds(1f);
        }
    }
    private void InstantiateEnemy(float enemyID, Vector3 position)
    {
        Debug.Log("Spawning enemy ID: " + enemyID + " at position: " + position);
        if (enemyID == 0)
        {
            Instantiate(enemyPrefab1, position, Quaternion.identity);
        }
        else if (enemyID == 1)
        {
            Instantiate(enemyPrefab2, position, Quaternion.identity);
        }
        else if (enemyID == 2)
        {
            Instantiate(enemyPrefab3, position, Quaternion.identity);
        }
        else if (enemyID == 3)
        {
            Instantiate(enemyPrefab4, position, Quaternion.identity);
        }
        else if (enemyID == 4)
        {
            Instantiate(enemyPrefab5, position, Quaternion.identity);
        }
    }
    public Vector3[] hardcodedSpawnPoints = new Vector3[3]
    {
         new Vector3(-3f, 0.54f, 29.2f),
         new Vector3(0f, 0.54f, 29.2f),
         new Vector3(3f, 0.54f, 29.2f)
    };

    private void SpawnBoss1()
    {
        Vector3 spawningSpot = hardcodedSpawnPoints[Random.Range(0, hardcodedSpawnPoints.Length)];
        Debug.Log("in boss spawn method");
        
        
        
        Quaternion boss = Quaternion.Euler(0, 90, 0);
        Instantiate(Boss1, spawningSpot, boss);
        StartCoroutine(EndBossAfterDelay());

    }
    private void SpawnBoss2()
    {
        Vector3 spawningSpot = hardcodedSpawnPoints[Random.Range(0, hardcodedSpawnPoints.Length)];


        Quaternion boss = Quaternion.Euler(0, 90, 0);
        Instantiate(Boss2, spawningSpot, boss);
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
        if (LevelManager.Instance.currentLevelName=="GameOver")
        {
            GameOverStopSpawning();
        }
        
        
        
    }
   
   
    
}
