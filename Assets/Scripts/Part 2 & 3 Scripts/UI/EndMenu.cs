using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    //[SerializeField] TextMeshProUGUI endScoreText;
    

    private void Start()
    {
        //endScoreText.text = "";
    }

     void Update()
    {
        //uses the score from level 1 for the end score
        //endScoreText.text = "Score : " + GameManager.Instance.score.ToString();
        

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReloadLevel()
    {
        //Loads level1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

}
