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
    public int ObstaclePassed { get; private set; }



    public static GameManager Instance { get; private set; }

    void Awake()
    {
        //ensures there id only one gamemanger class at a time
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
        stage = 1;
    }
    private void OnEnable()
    {
        EventManager.Instance.OnObstaclePassed += HandleObstaclePassed;
        EventManager.Instance.OnPickup1Activated += HandlePickup1Activated;
        EventManager.Instance.OnPickup2Activated += HandlePickup2Activated;
        EventManager.Instance.OnPickup3Activated += HandlePickup3Activated;
        EventManager.Instance.OnBossSpawned += HandleBossSpawned;
        EventManager.Instance.OnBossBeaten += HandleBossBeaten;



    }
    private void OnDisable()
    {
        EventManager.Instance.OnObstaclePassed -= HandleObstaclePassed;
        EventManager.Instance.OnPickup1Activated -= HandlePickup1Activated;
        EventManager.Instance.OnPickup2Activated -= HandlePickup2Activated;
        EventManager.Instance.OnPickup3Activated -= HandlePickup3Activated;
        EventManager.Instance.OnBossSpawned -= HandleBossSpawned;
        EventManager.Instance.OnBossBeaten -= HandleBossBeaten;

    }
    private void HandleObstaclePassed()
    {
        ObstaclePassed++;

    }
    private void HandlePickup1Activated()
    {
        Debug.Log("Pickup 1 activated ");

    }
    private void HandlePickup2Activated()
    {
        Debug.Log("Pickup 2 activated ");

    }
    private void HandlePickup3Activated()
    {
        Debug.Log("Pickup 3 activated ");


    }
    private void HandleBossSpawned()
    {
        Debug.Log("Boss spawned ");

    }
    private void HandleBossBeaten()
    {
        Debug.Log("Boss beaten ");

    }


    //shows the score
    [SerializeField] private GameObject scoreDisplay;
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

    TextMeshProUGUI scoreText;

    TextMeshProUGUI stageText;

    TextMeshProUGUI enemykillsText;

    TextMeshProUGUI currentenemiesText;

    //used to get the current amount of enemies
    public GameObject[] enemylist = null;
    void Start()
    {
        scoreText = scoreDisplay.GetComponent<TextMeshProUGUI>();
        stageText=  stageDisplay.GetComponent<TextMeshProUGUI>();
        currentenemiesText= currentEnemiesDisplay.GetComponent<TextMeshProUGUI>();
        enemykillsText =enemyKillsDisplay.GetComponent<TextMeshProUGUI>();
        pKEffectText= pickupEffectdisplayDisplay.GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //ensure the list accounts for enemies dieing and spawning
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");


        
        scoreText.text ="Score : " +GameManager.Instance.score.ToString();
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

