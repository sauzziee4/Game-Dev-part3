using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{


    public int totalEnemyCount;
    


    public static GameManager Instance { get; private set; }

    void Awake()
    {
        //ensures there id only one gamemanger class ata time
        if (Instance == null) { Instance = this; } else if (Instance != this) { Destroy(this); }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private GameObject scoreDisplay;
     public int score = 0;  

    //public Text valText;
    TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = scoreDisplay.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()

    {
        //the value of score is used to show the score
        scoreText.text = GameManager.Instance.score.ToString();
        //Debug.Log(scoreText.text);
        

        GoToNextScene();
    }


    //simply shows if you have won
    public void GoToNextScene()
    {
        

        if (GameManager.Instance.score >= 40)
           

        {
            Debug.Log("Victory");
            //SceneManager.LoadSceneAsync("Level 2");
        }
    }

    //handles an enemy being spawned, if an enemy is spawned the enemy count is increased by 1
    public void EnemySpawn()
    {
        totalEnemyCount += 1;
        Debug.Log("There are" + totalEnemyCount);
        Debug.Log("1 enemy has spawned");


    }
    //handles the enemy being killed, if an enemy dies the enemy count is reduced by 1
    public void EnemyDeath()
    {
        totalEnemyCount = totalEnemyCount - 1;
        Debug.Log("There are" + totalEnemyCount);
        Debug.Log("1 enemy has died");



    }


}

