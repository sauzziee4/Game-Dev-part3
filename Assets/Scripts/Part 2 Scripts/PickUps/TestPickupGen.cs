using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class TestPickupGen : MonoBehaviour
{
    public GameObject pickup1;
    public GameObject pickup2;
    public GameObject pickup3;

    public GameObject[] pickuplist = null;

    //the x,y and z positon
    float xPosP;
    float zPosP;
    float yPosP;
    float pickupID;
    float xPPosID;

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
        pickuplist= GameObject.FindGameObjectsWithTag("Pickup");

    }
    IEnumerator PickupSpawn()
    {
        while (pickuplist.Length < pickupMax)
        {

            xPPosID = Random.Range(0, 3);
            if(xPPosID==0)
            {
                xPosP = -3f;
            }
            if(xPPosID==1)
            {
                xPosP = 0f;
            }
            if (xPPosID==2)
            {
                xPosP = 3f;
            }
            pickupID = Random.Range(0, 3);
            if(pickupID==0)
            {
                Instantiate(pickup1, new Vector3(xPosP, yPosP, zPosP), Quaternion.identity);

            }
            if (pickupID==1)
            {
                Instantiate(pickup2, new Vector3(xPosP, yPosP, zPosP), Quaternion.identity);

            }
            if (pickupID ==2)
            {
                Instantiate(pickup3, new Vector3(xPosP, yPosP, zPosP), Quaternion.identity);

            }
            //xPosID = Random.Range(0, 3);

            //we assign the values
            xPosP = 3;
            yPosP = 1;
            zPosP = 0;

            
            yield return new WaitForSeconds(0.1f);
            pickupCount++;


        }
            



    }
}
