using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void Initialize()
    {
        // Initialize UI elements if needed
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           

            if (Time.timeScale==0f)
            {
                //tells the gamemanager to resume the game
                GameManager.Instance.ResumeGame();

            }
            else
            {
               //tells the gamemanager to pause the game
                GameManager.Instance.PauseGame();

            }
            
        }

        // Add more input handling as needed
        
    }

   
}
