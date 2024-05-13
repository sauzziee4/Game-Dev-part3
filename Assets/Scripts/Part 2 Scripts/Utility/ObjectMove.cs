using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public GameManager gm;
    
    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        


    }

    // Update is called once per frame
    void Update()
    {

        //If the player is died and obstacles should not move then the objects dont move
        if(gm.playerLive==false || PauseControl.gameIsPaused == true) 
        {
    
        }
        if (PickUpManager.speedUp ==true)
        {
            Debug.Log("fast speed");
            transform.position += new Vector3(0, 0, -6) * Time.deltaTime;

        }
        if(PickUpManager.speedUp==false)
        {
            Debug.Log("normal speed");
            transform.position += new Vector3(0, 0, -4) * Time.deltaTime;

        }
        else
        {
            //Debug.Log("normal speed");
            
            //needs to be -4 for acttual game
            //transform.position += new Vector3(0, 0, -4) * Time.deltaTime;

        }
        
            

        



    }
    



}
