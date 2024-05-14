using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{


    public int totalEnemyCount;
    public bool playerLive;
    public bool bossDeath;
    public int enemyDeaths;
   

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        //ensures there id only one gamemanger class ata time
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

    [SerializeField] private GameObject pickupEffectdisplayDisplay;
    public bool pickupEffect = false;

    TextMeshProUGUI pKEffectText;

    //public Text valText;
    TextMeshProUGUI scoreText;

    TextMeshProUGUI stageText;

    TextMeshProUGUI enemykillsText;

    TextMeshProUGUI currentenemiesText;

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
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");


        //the value of score is used to show the score
        scoreText.text ="Score : " +GameManager.Instance.score.ToString();
        stageText.text ="Stage : "+ GameManager.Instance.stage.ToString();
        enemykillsText.text ="Enemies defeated : " + GameManager.Instance.kills.ToString();
        currentenemiesText.text ="Current enemies: " + enemylist.Length.ToString();
        pKEffectText.text ="Pickup effect: " +GameManager.Instance.pickupEffect.ToString();
        //Debug.Log(scoreText.text);
        
       

       NextStage();
    }
    
    public void NextStage()
    {
          
        
        //once the boss is defeated we go to stage 2
        if (GameManager.Instance.bossDeath ==true)
        {
            //Victory
            GameManager.Instance.stage = 3;
        }
        
    }

    
    public void PlayerSpawn()
    {
        playerLive=true;
        //Debug.Log("Player is alive");
        //Debug.Log(playerLive);


    }
    public void PlayerDeath()
    {
        //the player has died so objects shoudl stop moving
        playerLive = false;
        
        //Debug.Log("Player is dead");
        //Debug.Log(playerLive);


    }
    public void BossSpawn()
    {
        bossDeath = false;
        

    }
    public void BossDeath()
    {
        bossDeath=true;

    }
   


}

