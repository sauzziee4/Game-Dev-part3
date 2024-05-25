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

    public GameObject pauseMenu;

    public float menuNum = 0;
    
    private TextMeshProUGUI scoreText;
    

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

        //PauseMenuReference();
        pauseMenu = GameObject.FindGameObjectWithTag("Level1PausePanel");
        Debug.LogWarning("Pause panel initialized.");
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);
            
            Debug.LogWarning("Pause panel state: " + pauseMenu.activeSelf);
        }

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
    private void PauseMenuReference()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("Level1PausePanel");

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
            scoreText.text = "Obstacles Passed: " + GameManager.Instance.GetObstaclesPassedScore().ToString();
            
            Debug.Log("Score text updated: " + scoreText.text); // Log the updated text value
        }
        else
        {
            Debug.LogWarning("Score text is null");
            
        }

    }
    public void TogglePauseMenu()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("Level1PausePanel");
        
        if (pauseMenu == null)
        {
            PauseMenuReference();
            Debug.LogWarning("Pause panel is null.");

        }

        bool isActive = pauseMenu.activeSelf;

        if (pauseMenu != null)
        {

            Debug.LogWarning("Created Pause panel.");
            Debug.Log(isActive);
            
            if (isActive==false)
            {
                HidePauseMenu();
            }
            else if(isActive==true)
            {
                ShowPauseMenu();
            }

        }
        else
        {
            Debug.LogWarning("Pause panel is null, cannot toggle active state.");

        }
       
    }

    






    public void ShowPauseMenu()
    {
        
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(true);
           
            

        }
        
        
    }

    public void HidePauseMenu()
    {
        if (pauseMenu == null)
        {
            PauseMenuReference();

        }
        if (pauseMenu != null)
        {
            pauseMenu.SetActive(false);

        }
        
    }

    public void HideInitialPauseMenu()
    {
        bool isActive = pauseMenu.activeSelf;
        pauseMenu.SetActive(false);


    }
    



}