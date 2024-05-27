using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public SpawnManager Instance;

    public GameObject[] enemyPrefab1;
    public GameObject[] enemyPrefab2;
    public GameObject[] enemyPrefab3;
    public Transform[] spawnPoints;
    public bool spawnEnemies = true;
    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnBossSpawned.AddListener(SpawnBoss);

        StartCoroutine(SpawnEnemiesRoutine());

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
        if (spawnPoints.Length==0)
        {
            Debug.LogWarning("No spawn points set in SpawnManager.");
            return;
            
        }

        int spawnIndex = Random.Range(0, spawnPoints.Length);
        int enemyType = Random.Range(1, 4); // Randomly select enemy type 1, 2, or 3

        GameObject enemyPrefab = null;

        switch (enemyType)
        {
            case 1:
                enemyPrefab = enemyPrefab1[Random.Range(0, enemyPrefab1.Length)];
                break;
            case 2:
                enemyPrefab = enemyPrefab2[Random.Range(0, enemyPrefab2.Length)];
                break;
            case 3:
                enemyPrefab = enemyPrefab3[Random.Range(0, enemyPrefab3.Length)];
                break;
            default:
                Debug.LogWarning("Invalid enemy type.");
                break;
        }

        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
        //Debug.Log("Enemy spawned at " + spawnPoints[spawnIndex].position);
    }
}
