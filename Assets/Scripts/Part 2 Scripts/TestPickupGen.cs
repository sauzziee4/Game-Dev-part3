using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TestPickupGen : MonoBehaviour
{
    public GameObject pickup;

    float xPosP;
    float zPosP;
    float yPosP;

    public float pickupCount;
    public float pickupMax;




    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(PickupSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator PickupSpawn()
    {
        while (pickupCount < pickupMax)
        {
            //xPosID = Random.Range(0, 3);

            xPosP = 3;
            yPosP = 1;
            zPosP = 0;

            Instantiate(pickup, new Vector3(xPosP, yPosP, zPosP), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            pickupCount++;


        }
            



    }
}
