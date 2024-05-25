using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    //in the hierarchy the game manager is on an empty object which is nested under the player


    
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
        
        stage = 1;
    }
    

    //shows the score
    
     public int score = 0;

    //shows the stage
    [SerializeField] private GameObject stageDisplay;
    public int stage = 0;

    //shows how many enemies we have killed
    [SerializeField] private GameObject enemyKillsDisplay;
    public int kills = 0;
    
    //shows how many enemies are alive
    [SerializeField] private GameObject currentEnemiesDisplay;
    public int currentEnemies = 0;

    //shows where the player is affected by a picup
    [SerializeField] private GameObject pickupEffectdisplayDisplay;
    public bool pickupEffect = false;

    //the text elements
    TextMeshProUGUI pKEffectText;

    

    TextMeshProUGUI stageText;

    TextMeshProUGUI enemykillsText;

    TextMeshProUGUI currentenemiesText;

    //used to get the current amount of enemies
    public GameObject[] enemylist = null;
    void Start()
    {
        
        stageText=  stageDisplay.GetComponent<TextMeshProUGUI>();
        currentenemiesText= currentEnemiesDisplay.GetComponent<TextMeshProUGUI>();
        enemykillsText =enemyKillsDisplay.GetComponent<TextMeshProUGUI>();
        pKEffectText= pickupEffectdisplayDisplay.GetComponent<TextMeshProUGUI>();


        UIManager.Instance.Initialize();
        LevelManager.Instance.Initialize();
        InputManager.Instance.Initialize();

    }
    private void OnEnable()
    {
        EventManager.Instance.OnObstaclePassed += HandleObstaclePassed;
        EventManager.Instance.OnPickup1Activated += HandlePickup1Activated;
        EventManager.Instance.OnPickup1Activated += HandlePickup2Activated;
        EventManager.Instance.OnPickup1Activated += HandlePickup3Activated;
        EventManager.Instance.OnBossSpawned += HandleBossSpawned;
        EventManager.Instance.OnBossBeaten += HandleBossBeaten;
    }
    private void OnDisable()
    {
        EventManager.Instance.OnObstaclePassed -= HandleObstaclePassed;
        EventManager.Instance.OnPickup2Activated -= HandlePickup2Activated;
        EventManager.Instance.OnPickup3Activated -= HandlePickup2Activated;
        EventManager.Instance.OnBossSpawned -= HandleBossSpawned;
        EventManager.Instance.OnBossBeaten -= HandleBossBeaten;
    }

    private void HandleObstaclePassed()
    {
        IncreaseScore(10);
        
        
    }
    public void IncreaseScore(int amount)
    {
        score += amount;
        UIManager.Instance.UpdateScore(score);
    }

    private void HandlePickup1Activated()
    {
        Debug.Log("Pick-Up Activated!");
    }
    private void HandlePickup2Activated()
    {
        Debug.Log("Pick-Up Activated!");
    }
    private void HandlePickup3Activated()
    {
        Debug.Log("Pick-Up Activated!");
    }

    private void HandleBossSpawned()
    {
        Debug.Log("Boss Spawned!");
    }

    private void HandleBossBeaten()
    {
        
        
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
        UIManager.Instance.ShowPauseMenu();
        EventManager.TriggerEvent("OnGamePaused");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        UIManager.Instance.HidePauseMenu();
        EventManager.TriggerEvent("OnGameResumed");
    }



    // Update is called once per frame
    void Update()
    {
        //ensure the list accounts for enemies dieing and spawning
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");


        
        
        stageText.text ="Stage : "+ GameManager.Instance.stage.ToString();
        enemykillsText.text ="Enemies defeated : " + GameManager.Instance.kills.ToString();
        currentenemiesText.text ="Current enemies: " + enemylist.Length.ToString();
        pKEffectText.text ="Pickup effect: " +GameManager.Instance.pickupEffect.ToString();
        
        
       

       NextStage();
    }
    
    public void NextStage()
    {
          
        
        //once the boss is defeated we go to stage 3
        if (GameManager.Instance.bossDeath ==true)
        {
            //Victory
            GameManager.Instance.stage = 3;
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

