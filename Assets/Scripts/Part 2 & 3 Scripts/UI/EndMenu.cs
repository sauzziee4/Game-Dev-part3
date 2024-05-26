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
        //endScoreText.text = "";
    }

     void Update()
    {
        levelsBeatenText.text ="Levels Beaten :" + GameManager.Instance.GetLevelsBeaten().ToString();
        endScoreText.text = "Score: " + GameManager.Instance.GetObstaclesPassedScore().ToString();


    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReloadLevel()
    {
        //Loads level1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }

}
