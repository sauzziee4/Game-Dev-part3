using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    //in the hierarchy the game manager is on an empty object which is nested under the player

    public UnityEvent OnObstaclePassed;
    


    private int obstaclesPassedScore = 0;

    public bool playerLive;
    public bool bossDeath;
    
   

    public static GameManager Instance { get; private set; }

     private void Awake()
    {
        //ensures there id only one gamemanger class at a time
        if (Instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this) 
        {
            Debug.Log("hello");
            Destroy(gameObject);
        }
        
        //stage = 1;
    }
    public void IncrementObstaclesPassedScore()
    {
        obstaclesPassedScore++;
        Debug.Log("Obstacles Passed: " + obstaclesPassedScore);

        OnObstaclePassed.Invoke();
    }


    //shows the score

    public int score = 0;

    //shows the stage
    //[Serialize
    public GameObject[] enemylist = null;
    void Start()
    {
        if (OnObstaclePassed == null) OnObstaclePassed = new UnityEvent();
        

        //stageText=  stageDisplay.GetComponent<TextMeshProUGUI>();
        //currentenemiesText= currentEnemiesDisplay.GetComponent<TextMeshProUGUI>();
        //enemykillsText =enemyKillsDisplay.GetComponent<TextMeshProUGUI>();
        //pKEffectText= pickupEffectdisplayDisplay.GetComponent<TextMeshProUGUI>();


        //UIManager.Instance.Initialize();
        //LevelManager.Instance.Initialize();
        //InputManager.Instance.Initialize();

    }
    public int GetObstaclesPassedScore()
    {
        return obstaclesPassedScore;
    }



    public void RestartGame()
    {
        Time.timeScale = 1f;
        EventManager.TriggerEvent("OnGameRestart");
        LevelManager.Instance.RestartLevel();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        UIManager.Instance.TogglePausePanel();
        EventManager.TriggerEvent("OnGamePaused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        UIManager.Instance.TogglePausePanel ();
        EventManager.TriggerEvent("OnGameResumed");
    }



    // Update is called once per frame
    void Update()
    {
        //ensure the list accounts for enemies dieing and spawning
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");


        
        
        //stageText.text ="Stage : "+ GameManager.Instance.stage.ToString();
        //enemykillsText.text ="Enemies defeated : " + GameManager.Instance.kills.ToString();
        //currentenemiesText.text ="Current enemies: " + enemylist.Length.ToString();
        //pKEffectText.text ="Pickup effect: " +GameManager.Instance.pickupEffect.ToString();
        
        
       

       NextStage();
    }
    
    public void NextStage()
    {
          
        
        //once the boss is defeated we go to stage 3
        if (GameManager.Instance.bossDeath ==true)
        {
            //Victory
            //GameManager.Instance.stage = 3;
        }
        
    }

    //used so the scripts know the player is aalive
    public void PlayerSpawn()
    {
        playerLive=true;
        


    }
    public void PlayerDeath()
    {
        //the player has died so objects stop moving
        playerLive = false;
        
        


    }
    //used to move to the next stage once the boss has died
    public void BossSpawn()
    {
        bossDeath = false;
        

    }
    public void BossDeath()
    {
        bossDeath=true;

    }
   


}

