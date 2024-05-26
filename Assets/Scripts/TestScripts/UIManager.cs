using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEditor;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject pause;

    public float menuNum = 0;
    
    private TextMeshProUGUI scoreText;
    private TextMeshProUGUI levelsBeatenText;


    private CanvasGroup pausePanelCanvasGroup;
    private bool isPausePanelVisible = false;
    

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateScoreTextReference();

        // Subscribe to GameManager events
        GameManager.Instance.OnObstaclePassed.AddListener(UpdateScore);
        GameManager.Instance.OnBossBeaten.AddListener(UpdateLevelsBeaten);

        GameObject pausePanel = GameObject.FindGameObjectWithTag("Level1PausePanel");
        pausePanelCanvasGroup = pausePanel.GetComponent<CanvasGroup>();

        //TogglePauseMenu();


    }
    private void UpdateScoreTextReference()
    {
        GameObject scoreObject = GameObject.FindGameObjectWithTag("Level1Score");
        if (scoreObject != null)
        {
            scoreText = scoreObject.GetComponent<TextMeshProUGUI>();
            if (scoreText != null)
            {
                Debug.Log("Score text found: " + scoreText.gameObject.name);
            }
            else
            {
                Debug.LogWarning("Score text component not found on GameObject with tag: ScoreText");
            }
        }
        else
        {
            Debug.LogWarning("Score text GameObject not found with tag: ScoreText");
        }

    }
    public void UpdateLevelsBeatenTextReference()
    {
        
        GameObject levelsBeatenObject = GameObject.FindGameObjectWithTag("Level1LevelsBeaten");
        levelsBeatenText=levelsBeatenObject.GetComponent<TextMeshProUGUI>();

    }
    public void UpdateLevelsBeaten()
    {
        GameObject levelsBeatenObject = GameObject.FindGameObjectWithTag("Level1LevelsBeaten");
        levelsBeatenText = levelsBeatenObject.GetComponent<TextMeshProUGUI>();
        levelsBeatenText.text = "Levels Beaten :" + GameManager.Instance.GetLevelsBeaten().ToString();
    }
   

    public void Startgame()
    {

        SceneManager.LoadScene("Level1");
    }

    public void Initialize()
    {
        // Initialize UI elements if needed
    }

    public void UpdateScore()
    {
        UpdateScoreTextReference();


        if (scoreText.text != null)
        {
            Debug.Log("lets see if work" +GameManager.Instance.GetObstaclesPassedScore().ToString());
            scoreText.text = "Score: " + GameManager.Instance.GetObstaclesPassedScore().ToString();
            
            Debug.Log("Score text updated: " + scoreText.text); // Log the updated text value
        }
        else
        {
            Debug.LogWarning("Score text is null");
            
        }

    }
    public void TogglePausePanel()
    {
        GameObject pausePanel = GameObject.FindGameObjectWithTag("Level1PausePanel");
        pausePanelCanvasGroup = pausePanel.GetComponent<CanvasGroup>();
        if (pausePanelCanvasGroup == null)
        {
            Debug.LogWarning("Pause panel CanvasGroup is null, cannot toggle visibility.");
            return;
        }

        isPausePanelVisible = !isPausePanelVisible;
        if (isPausePanelVisible)
        {
            ShowPauseMenu();
        }
        else
        {
            HidePauseMenu();
        }
    }

    public void ShowPauseMenu()
    {
        if (pausePanelCanvasGroup != null)
        {
            pausePanelCanvasGroup.alpha = 1f;
            pausePanelCanvasGroup.interactable = true;
            pausePanelCanvasGroup.blocksRaycasts = true;
            Debug.Log("Pause menu shown.");
        }
        else
        {
            Debug.LogWarning("Pause panel CanvasGroup is null, cannot show pause menu.");
        }
    }

    public void HidePauseMenu()
    {
        if (pausePanelCanvasGroup != null)
        {
            pausePanelCanvasGroup.alpha = 0f;
            pausePanelCanvasGroup.interactable = false;
            pausePanelCanvasGroup.blocksRaycasts = false;
            Debug.Log("Pause menu hidden.");
        }
        else
        {
            Debug.LogWarning("Pause panel CanvasGroup is null, cannot hide pause menu.");
        }
    }

   
    



}