using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public int attackDamage = 10;
    public float attackCooldown = 1.5f;
    public Transform player;
    public PlayerHealth playerHealth;
    public bool canAttack = false;


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("playercollison");
            

            CanAttackPlayer();
        }


    }




    private void Awake()
    {
        GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");
        foreach (var pl in playerObject)
        {
            if (pl.GetComponent < PlayerHealth>())
            {
                player = pl.transform;
                playerHealth = pl.GetComponent<PlayerHealth>();
            }
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canAttack== true)
        {
            AttackPlayer();
        }
        


        
        
    }

    public bool CanAttackPlayer()
    {
        canAttack = true;
       


        return canAttack;
    }

    private void AttackPlayer()
    {
        playerHealth.Takedamage(attackDamage);


    }
}
