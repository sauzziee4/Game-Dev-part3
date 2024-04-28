using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // collision with enemy player dies
        if (collision.gameObject.CompareTag("Enemy"))
        {
                Die();
        }
        
    }
    private void Die()
    {
        //makes it look like the player is died by making them invisble and disabling movement
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<PlayerMovement>().enabled = false;

        //If the player is dead the next scene which is the end screen is loaded
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }

    
}
