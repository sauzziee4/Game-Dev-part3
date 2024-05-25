using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject pauseMenu;



    //public GameObject ScoreDisplay;

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
    




    public void ShowPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public void HidePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    

    
}