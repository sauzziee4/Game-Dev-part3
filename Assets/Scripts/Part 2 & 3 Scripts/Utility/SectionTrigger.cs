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

    public GameObject endPlatform;
    public bool bossbeaten = false;
    public float endPlatformCount = 0;
    

    private void OnTriggerEnter(Collider other)
    {
        //chooese a random section to generate
        secNum = Random.Range(0, 3);
        if (other.gameObject.CompareTag("Trigger"))
        {

            
            //where the platform is spawned
            if (bossbeaten==false)
            {
                Instantiate(roadSection, new Vector3(0, 0, 39), Quaternion.identity);

            }
            if (bossbeaten==true)
            {
                Debug.Log("should spawn endplatform");
                Instantiate(endPlatform, new Vector3(0, 0, 39), Quaternion.identity);
                enabled = false;
                Debug.Log("should be disablend after this messgae");
                endPlatformCount++;


            }
                
        }

        

    }
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnBossBeaten.AddListener(LoadEndPlatform);
             //GameManager.Instance.OnPickup1Activated.AddListener(OnPickup1Activated);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LoadEndPlatform()
    {
        bossbeaten=true;

    }
}
