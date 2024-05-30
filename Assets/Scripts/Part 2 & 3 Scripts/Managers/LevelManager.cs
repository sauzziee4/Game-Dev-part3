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
    //unsure if this is needed
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    //restarts the level
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
        //if the current level is level1 then it loads level 2
        if (currentLevelName == Level1Name)
        {
            LoadSecondLevel();
        }
        else
        {
            LoadFirstLevel();
        }
    }
    //loads the gameover scen when the player dies
    public void PlayerDied()
    {
        currentLevelName = "GameOver";
        SceneManager.LoadScene("GameOver");

    }
}
