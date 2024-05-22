using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public static bool PauseMenu;
    

    
    void Start()
    {
        
    }
    private void Awake()
    {
        //does this reset the score on a new game
        

    }

    // Update is called once per frame
    void Update()
    {
        //if the player presses escape the game pauses or unpauses
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           ;
            //if it is false it becomes true, if it is true it becomes false
            gameIsPaused = !gameIsPaused;
            PauseGame();

        }


    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            //the time scale is set to 0 which pauses the game and the pausemenu is true
            Time.timeScale = 0f;
            PauseMenu = true;

        
        }
        else
        {
            //the time scale is set to 1 which unpauses the game
            Time.timeScale = 1;
            PauseMenu = false;
        }
    }
}
