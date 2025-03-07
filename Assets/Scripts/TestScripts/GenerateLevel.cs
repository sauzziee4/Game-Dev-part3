using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{


    public GameObject[] section;
    public int zPos = 20;
    public bool creatingSection = false;
    public int secNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this is so that there is a delay
        if (creatingSection== false)
        {
            creatingSection = true;
            StartCoroutine(GenerateSection());
        }
        
    }
    //generates a new section
    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 20;
        yield return new WaitForSeconds(2);
        creatingSection= false;

    }
}
