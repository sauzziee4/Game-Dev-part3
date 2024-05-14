using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public static bool PauseMenu;
    // Start is called before the first frame update

    
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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("escape has been presses");
            //if it is false it becomes true, if it is true it becomes false
            gameIsPaused = !gameIsPaused;
            PauseGame();

        }


    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            PauseMenu = true;

        
        }
        else
        {
            Time.timeScale = 1;
            PauseMenu = false;
        }
    }
}
