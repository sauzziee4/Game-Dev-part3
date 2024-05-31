using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerHealth : MonoBehaviour
{
    // used for the players health
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject player;
    public GameManager gm;
    

   
    private void Awake()
    {
        
        currentHealth = maxHealth;
        
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        gm.PlayerSpawn();
        

    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= -25) // If the player falls off the map they die
        {
            Debug.Log("Player fell off the map" + player.transform.position.y);
            Takedamage(20);
            

        }
        
    }

    public void Takedamage(int dam)
    {
        currentHealth -= dam;
        //Debug.Log($"{currentHealth}");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health stays within bounds

        if (currentHealth <=0) 
        {
            //if the players health is 0 they are destoyed and the game manager is notified
            currentHealth = 0;
            //calls the die method
            Die();
            //gm.PlayerDeath();

            //Destroy(gameObject);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);




        }

    }
    //tells the levelmanager to do the playerdied method which loads the game over scene
    private void Die()
    {
       int score=GameManager.Instance.GetObstaclesPassedScore();
        string playerID = PlayerID.Instance.PlayerId;
        CloudSavemanager.SaveData(score, playerID);
        LevelManager.Instance.PlayerDied();
    }
    
}
