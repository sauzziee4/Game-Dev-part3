using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{

    //the player does not move forward the objects move toward them
    public GameManager gm;
    
    

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        


    }

    // Update is called once per frame
    void Update()
    {

        //If the player is died or the game is paused then the objects do not move
        if(gm.playerLive==false || PauseControl.gameIsPaused == true) 
        {
    
        }
        //if the player collected the pickcup which increses speed the objects increase in speed for 5 seconds, the 5 seconds is handled in the pickup manager
        if (PickUpManager.speedUp ==true)
        {
            
            transform.position += new Vector3(0, 0, -6) * Time.deltaTime;

        }
        //if the player has not collected the speedup and the player is alive then the object move normally
        if(PickUpManager.speedUp==false & gm.playerLive==true)
        {
            Debug.Log("normal speed");
            transform.position += new Vector3(0, 0, -4) * Time.deltaTime;

        }
       
    }
    



}
