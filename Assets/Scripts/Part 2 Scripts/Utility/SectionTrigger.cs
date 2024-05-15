using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SectionTrigger : MonoBehaviour
{
    //used to spawn new platforms
    
    public GameObject roadSection;
    public int secNum;
    

    private void OnTriggerEnter(Collider other)
    {
        //chooese a random section to generate
        secNum = Random.Range(0, 3);
        if (other.gameObject.CompareTag("Trigger"))
        {
            
            //where the platform is spawned
           Instantiate(roadSection, new Vector3(0, 0, 39), Quaternion.identity);
                
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
