using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{

    public SpawnManager Instance;

    public GameObject[] enemyPrefab1;
    public GameObject[] enemyPrefab2;
    public GameObject[] enemyPrefab3;
    public Transform[] spawnPoints;
    public bool spawnEnemies = true;
    public GameObject Boss;

    public List<GameObject> level1Obstacles;
    public List<GameObject> level2Obstacles;

    private List<GameObject> currentObstacles;
    private List<Transform> currentSpawnPoints=new List<Transform>();

    private string currentLevelName = "Level1";

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnBossSpawned.AddListener(SpawnBoss);
        //UpdateCurrentLevel();
        StartCoroutine(SpawnEnemiesRoutine());

        //UpdateCurrentLevel();
        
    }
    
    private IEnumerator SpawnEnemiesRoutine()
    {
        while (spawnEnemies ==true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }
    
    private void SpawnBoss()
    {
        spawnEnemies = false;
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Quaternion boss = Quaternion.Euler(0, 90, 0);
        Instantiate(Boss, spawnPoints[spawnIndex].position, boss);

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
        if (LevelManager.Instance.currentLevelName != currentLevelName)
        {
            Debug.Log("in the udate");
            //UpdateCurrentLevel();
        }
        
        
    }
   
   
    private void SpawnEnemy()
    {
        
        
        currentLevelName = LevelManager.Instance.currentLevelName;
        Debug.Log(currentLevelName);

        //gets the spawnpoints
        GameObject[] spawnPointObjects = GameObject.FindGameObjectsWithTag("spawnPointTag");

        

        if (spawnPointObjects.Length== 0)
        {
            Debug.LogWarning("No spawn points set in SpawnManager.");
            return;

        }
        GameObject obstacleToSpawn = null;
        switch (currentLevelName)
        {
            case "Level1":
                obstacleToSpawn= level1Obstacles[Random.Range(0,level1Obstacles.Count)];
                break;
            case "Level2":
                obstacleToSpawn = level2Obstacles[Random.Range(0,level2Obstacles.Count)];
                break;

        }
        //choose a random spawnpoint
        GameObject spawnPoint = spawnPointObjects[Random.Range(0, spawnPoints.Length)];

        Instantiate(obstacleToSpawn,spawnPoint.transform.position,Quaternion.identity);


       
    }
}
