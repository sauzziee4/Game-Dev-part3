using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public string Level1Name = "Level1";
    public string Level2Name = "Level2";

    public string currentLevelName;

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

    
    public void Initialize()
    {
        // Initialize UI elements if needed
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Start()
    {
        LoadFirstLevel();
    }

    public void LoadFirstLevel()
    {
        currentLevelName = Level1Name;
        SceneManager.LoadScene(Level1Name);
    }

    public void LoadSecondLevel()
    {
        currentLevelName = Level2Name;
        SceneManager.LoadScene(Level2Name);
    }

    public void LoadNextLevel()
    {
        if (currentLevelName == Level1Name)
        {
            LoadSecondLevel();
        }
        else
        {
            LoadFirstLevel();
        }
    }
    public void PlayerDied()
    {
        currentLevelName = "GameOver";
        SceneManager.LoadScene("GameOver");

    }
}
