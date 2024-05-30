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
    public UnityEvent OnPickup1Activated;
    public UnityEvent OnPickup2Activated;
    public UnityEvent OnPickup3Activated;
    public UnityEvent OnBossSpawned;
    public UnityEvent OnBossBeaten;
    




    private int obstaclesPassedScore = 0;
    private int levelsBeaten = 0;

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
            //Debug.Log("hello");
            Destroy(gameObject);
        }
        
        //stage = 1;
    }
    public void IncrementObstaclesPassedScore()
    {
        obstaclesPassedScore++;
        //Debug.Log("Obstacles Passed: " + obstaclesPassedScore);

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
        if (OnPickup1Activated == null) OnPickup1Activated = new UnityEvent();
        if(OnPickup2Activated == null) OnPickup2Activated = new UnityEvent();
        if(OnPickup3Activated == null) OnPickup3Activated = new UnityEvent();
        if (OnBossSpawned == null) OnBossSpawned = new UnityEvent();
        if(OnBossBeaten == null) OnBossBeaten = new UnityEvent();
        

        


        //UIManager.Instance.Initialize();
        //LevelManager.Instance.Initialize();
        //InputManager.Instance.Initialize();

    }
    public int GetObstaclesPassedScore()
    {
        return obstaclesPassedScore;
    }
    public int GetLevelsBeaten()
    {
        return levelsBeaten;

    }
    public void ActivatePickup1()
    {
        OnPickup1Activated.Invoke();

    }
    public void ActivatePickup2()
    {
        OnPickup2Activated.Invoke();

    }
    public void ActivatePickup3()
    {
        OnPickup3Activated.Invoke();

    }
    public void SpawnBoss()
    {
        OnBossSpawned.Invoke();

    }
    public void DefeatBoss()
    {
        levelsBeaten++;
        OnBossBeaten.Invoke();

    }



    public void RestartGame()
    {
        Time.timeScale = 1f;
        
        LevelManager.Instance.RestartLevel();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        UIManager.Instance.TogglePausePanel();
        
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        UIManager.Instance.TogglePausePanel ();
        
    }



    // Update is called once per frame
    void Update()
    {
        //ensure the list accounts for enemies dieing and spawning
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");



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

