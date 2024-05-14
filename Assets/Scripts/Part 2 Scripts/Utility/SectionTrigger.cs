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
    int platformCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        //chooese a random section to generate
        secNum = Random.Range(0, 3);
        if (other.gameObject.CompareTag("Trigger"))
        {
            if (platformCount == 0)
            {
                //the first platform is generated further away as the sarting plafrom is bigger so the enemies dont fall off the map when spawning
                Instantiate(roadSection, new Vector3(0, 0, 40), Quaternion.identity);
                platformCount++;

            }
            else
            {
                //the platforms get spawned
                Instantiate(roadSection, new Vector3(0, 0, 40), Quaternion.identity);
                platformCount++;

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
        
    }
}
