using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int health = 100;
    public int damageTaken = 50;
    public int KillReward = 5;
    GameObject[] player = null;
    public GameManager gm;
    


    private void Awake()
    {
        health = 100;
        player = GameObject.FindGameObjectsWithTag("Player");
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
        if (GetComponent<Transform>().position.z < player[0].GetComponent<Transform>().position.z)
        {
            GameManager.Instance.score += KillReward;
            gm.EnemyDeath();
            
            // the gameobject is destroyed
            Destroy(gameObject);



        }


         
        
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
