using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]  GameObject menuD;
    
    public GameManager gm;

    
    // Start is called before the first frame update


    private void Awake()
    {
        
       

    }
    void Start()
    {
        //on start the pause menu is not activated
        menuD.SetActive(false);
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();


    }
    
    // Update is called once per frame
    void Update()
    {
        //if pause control tells main menu the pausemenu is true then the pause menu is activated
        if (PauseControl.PauseMenu==true )
        {
            menuD.SetActive(true);
        }
        else
        {
            menuD.SetActive(false);
        }

        
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void ReloadLevel()
    {
        
        //Loads level1
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        menuD.SetActive(false);
        
    }
}

