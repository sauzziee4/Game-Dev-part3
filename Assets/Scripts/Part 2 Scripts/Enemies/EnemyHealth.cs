using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health = 100;
    public int damageTaken = 50;
    
    
    public GameManager gm;
    


    private void Awake()
    {
        health = 100;
        
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if the enemy is behind the player the score in gamemanger is increased by the kill reward, the the gamemanager is alos told that an enemy has died
        
        // If the enemy falls off the map it is destroyed
        if ((GetComponent<Transform>().position.y <= -25))
        {
            gm.EnemyDeath();
            Destroy(gameObject);
        }


            // If the enemy falls off the map it is destroyed





    }
    //serves no purpose at the moment
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            // It might be GameManager.Instance.Score += KillReward
            //GameManager.Instance.score += KillReward;
            
        }

    }
    
}
