using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI endScoreText;
    [SerializeField] TextMeshProUGUI levelsBeatenText;
    

    private void Start()
    {
        levelsBeatenText.text = string.Empty;
        endScoreText.text = string.Empty;
        UpdateScoreText();
        
    }

    void Update()
    {
        //levelsBeatenText.text ="Levels Beaten :" + GameManager.Instance.GetLevelsBeaten().ToString();
        //endScoreText.text = "Score: " + GameManager.Instance.GetObstaclesPassedScore().ToString();
        if (LevelManager.Instance.currentLevelName=="GameOver")
        {
            UpdateScoreText();
        }


    }
    private void UpdateScoreText()
    {
        endScoreText.text = "Score: " + GameManager.Instance.GetObstaclesPassedScore().ToString();
        //levelsBeatenText.text = "Levels Beaten :" + GameManager.Instance.GetLevelsBeaten().ToString();

    }
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    public void ShowScore()
    {
        levelsBeatenText.text = "Levels Beaten :" + GameManager.Instance.GetLevelsBeaten().ToString();
        endScoreText.text = "Score: " + GameManager.Instance.GetObstaclesPassedScore().ToString();

    }
    public void ReloadLevel()
    {
        //Loads level1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }

}
