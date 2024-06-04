using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDestroy : MonoBehaviour
{
    //if an object is behind the player by a certain distance they are destroyed
    GameObject[] player = null;

    float playerZ;
    float objectZ;
    float zDistance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        //the object z
        objectZ = GetComponent<Transform>().position.z;

        //the players z
        playerZ = player[0].GetComponent<Transform>().position.z;

        //the distance between the player and the object
        

        if (transform.position.z<=-30f)
        {
            Destroy(gameObject);

        }
        //if that distance is greater then 30 the object is destroyed
        
       
            

    }
}
