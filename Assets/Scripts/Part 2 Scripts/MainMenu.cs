using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]  GameObject menuD;
    TextMeshProUGUI menuSDText;
    public GameManager gm;

    
    // Start is called before the first frame update


    private void Awake()
    {
        //does this reset the score on a new game
       

    }
    void Start()
    {
        menuD.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();


    }
    
    // Update is called once per frame
    void Update()
    {
        if (PauseControl.PauseMenu==true )
        {
            menuD.SetActive(true);
        }
        else
        {
            menuD.SetActive(false);
        }

        
    }
    //not implmented
    public void QuitGame()
    {
        Application.Quit();
    }
    //does not work
    public void ReloadLevel()
    {
        Time.timeScale = 1f;
        PauseControl.gameIsPaused = false;
        //Loads level1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Time.timeScale = 1f;
        //PauseControl.gameIsPaused=false;
    }
}

