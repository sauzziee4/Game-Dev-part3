using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("playercollison");

            //if the enemy collides with the player the canattack method is called 
            //could just use the attack method
            //CanAttackPlayer();
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
