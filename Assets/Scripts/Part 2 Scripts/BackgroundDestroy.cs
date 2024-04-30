using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDestroy : MonoBehaviour
{
    GameObject[] player = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.z < player[0].GetComponent<Transform>().position.z)
        {

            Destroy(gameObject);
        }
            

    }
}
