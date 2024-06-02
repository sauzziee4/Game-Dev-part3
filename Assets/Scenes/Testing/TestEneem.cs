using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEneem : MonoBehaviour
{
    public GameObject enemyPrefab1;
    public GameObject enemyPrefab2;
    public bool spawnState = true;
    private Coroutine spawnCoroutine;
    public float spawnInterval = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
        


    }
    public void StartSpawning()
    {

        if (spawnCoroutine == null)
        {
            spawnCoroutine = StartCoroutine(SpawnEnemies());
        }
    }
    public void StopSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;

        }
    }
    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);

        }
    }
    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab1, new Vector3(-3, 1, 29), Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(SpawnEnemies());

    }
    
}
