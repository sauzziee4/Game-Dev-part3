using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossdetector : MonoBehaviour
{
    GameObject[] boss = null;
    float bossx;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectsWithTag("Boss");

    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
