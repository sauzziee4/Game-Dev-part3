using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public GameObject player;
    public GameManager gm;

   
    private void Awake()
    {
        
        currentHealth = maxHealth;

    }

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y <= -25) // If the player falls off the map
        {
            Debug.Log("Player fell off the map" + player.transform.position.y);
            Takedamage(20);
            


        }
        
    }

    public void Takedamage(int dam)
    {
        currentHealth -= dam;
        Debug.Log($"{currentHealth}");
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);  // Ensure health stays within bounds

        if (currentHealth <=0) 
        {
            currentHealth = 0;
            Die();


            Debug.Log("Player died");

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
