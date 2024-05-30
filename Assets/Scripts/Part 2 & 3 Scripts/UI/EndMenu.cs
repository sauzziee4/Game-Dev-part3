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
        //if the current level is the gameoverscene, we call the updatescoretext method
        if (LevelManager.Instance.currentLevelName=="GameOver")
        {
            UpdateScoreText();
        }


    }
    private void UpdateScoreText()
    {
        //responsible for displaying the score 
        endScoreText.text = "Score: " + GameManager.Instance.GetObstaclesPassedScore().ToString();
        //levelsBeatenText.text = "Levels Beaten :" + GameManager.Instance.GetLevelsBeaten().ToString();

    }
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

   
    public void ReloadLevel()
    {
        //Loads level1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }

}
