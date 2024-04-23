using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject scoreDisplay;
    int score = 0;  

    //public Text valText;
    TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = scoreDisplay.GetComponent<TextMeshProUGUI>();
        scoreText.text = Pointsmanager.Instance.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = Pointsmanager.Instance.value.ToString();
        
        GoToNextScene();
    }


    public void GoToNextScene()
    {
        

        if (Pointsmanager.Instance.value >= 40)
           

        {
            Debug.Log("Victory");
            //SceneManager.LoadSceneAsync("Level 2");
        }
    }

}

