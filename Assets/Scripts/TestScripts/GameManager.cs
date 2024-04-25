using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{


    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; } else if (Instance != this) { Destroy(this); }
        DontDestroyOnLoad(gameObject);
    }

    [SerializeField] private GameObject scoreDisplay;
     public int score = 0;  

    //public Text valText;
    TextMeshProUGUI scoreText;
    void Start()
    {
        scoreText = scoreDisplay.GetComponent<TextMeshProUGUI>();
        scoreText.text = PointsManager.Instance.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = GameManager.Instance.score.ToString();
        //Debug.Log(scoreText.text);
        

        GoToNextScene();
    }


    public void GoToNextScene()
    {
        

        if (PointsManager.Instance.value >= 40)
           

        {
            Debug.Log("Victory");
            //SceneManager.LoadSceneAsync("Level 2");
        }
    }

}

