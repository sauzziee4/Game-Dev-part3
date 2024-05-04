using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Debug.Log("pause control is live");
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

        
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
