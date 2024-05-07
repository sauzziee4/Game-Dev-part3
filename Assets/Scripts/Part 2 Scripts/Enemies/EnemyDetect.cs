using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetect : MonoBehaviour
{

    public GameManager gm;
    //there is an empty gameobject attached to the back of the enemy if another enemy hit this box the other enemy is destroyed
    private void OnTriggerEnter(Collider other)
    {
         if (other.gameObject.CompareTag("Enemy"))
        {
            
            Debug.Log("Hit the back of an enemy");
            Destroy(other.gameObject);
            
        }
        

        
    }



    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
