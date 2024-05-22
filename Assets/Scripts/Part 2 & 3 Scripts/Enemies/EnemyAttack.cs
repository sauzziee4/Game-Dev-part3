using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //used for the when the player collides with the enemy

    public int attackDamage = 10;
    
    //the player position
    public Transform player;
    public PlayerHealth playerHealth;
    public bool canAttack = false;

    public GameManager gm;


    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            
            
            //if the enemy collides with the player the canattack method is called 
            //
            CanAttackPlayer();
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            
            //if the enemy collides with another enemy it destroys itself
            Destroy(this.gameObject);
            //gm.EnemyDeath();

        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
           //if the enemy collides with an obstacles it destroys itself
            Destroy(this.gameObject);    

        }
        if (collision.gameObject.CompareTag("Pickup"))
        {
            //if the enemy collides with a pickup it destoys itself
            Destroy(this.gameObject);

        }
        
      
    }




    private void Awake()
    {
        //assigns the object with the playe rtag to the playerObject variable
        GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");
        foreach (var pl in playerObject)
        {
            if (pl.GetComponent < PlayerHealth>())
            {
                player = pl.transform;
                playerHealth = pl.GetComponent<PlayerHealth>();
            }
        }
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();


    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack== true)
        {
            AttackPlayer();
        }
        


        
        
    }
    //checks if the enemy can attack the player
    //at the moment this method does not do much 
    public bool CanAttackPlayer()
    {
        //if the player is not invincible the enemy can attack the player
        if(PickUpManager.invincible==false)
        {
            canAttack = true;

        }
        //if the player is invincible the enemy can not attack the player and the enmy is destoyed
        if (PickUpManager.invincible == true)
        {
            Destroy(this.gameObject);
            canAttack= false;

        }
        
       


        return canAttack;
    }

    //the player is attacked and takes damage
    private void AttackPlayer()
    {
        playerHealth.Takedamage(attackDamage);


    }
}
