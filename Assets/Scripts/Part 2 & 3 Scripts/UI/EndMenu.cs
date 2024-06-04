using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{

    
    

    private void Start()
    {
       
        
    }

    void Update()
    {
        


    }
    
    
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

   
    public void ReloadLevel()
    {
        LevelManager.Instance.FromGameoverToLevel1();
        //Loads level1
        
    }
    

}
