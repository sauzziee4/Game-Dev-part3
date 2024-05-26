using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PickUpManager : MonoBehaviour
{
    //manages the pickups
    public static PickUpManager Instance {  get; private set; }
    
    
    

    
    public static bool speedUp;
    public static bool invincible;
    //pickup 3
    public static bool pk3;
    //pickup4
    public static bool pk4;
    


    [Header("Audio clips")]
    public AudioClip speedBuffClip;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
       
        
        
    }
    //the couroutine for the speed up
    public IEnumerator Pickup2()
    {
        //GameManager.Instance.pickupEffect = true;
        speedUp = true;
        yield return new WaitForSeconds(5);
        //after 5 seconds the pickup effect stops
        speedUp = false;
        //GameManager.Instance.pickupEffect = false;
        
    }
    //the couroutine for the invincible powerup
    public IEnumerator Pickup3()
    {
        //GameManager.Instance.pickupEffect = true;
        invincible = true;
        yield return new WaitForSeconds(5);
        //after 5 seconds the pickup effect stops
        invincible = false;
        //GameManager.Instance.pickupEffect = false;

    }
    
    //used for the jump boost pickup
    public void JumpBoost(PlayerControl2 playerControl)
    {
        //calls the couroutine
        StartCoroutine(JumpBoostCoroutine(playerControl));
    }

    //the couroutine for the jump boost
    private IEnumerator JumpBoostCoroutine(PlayerControl2 playerControl)
    {
        //GameManager.Instance.pickupEffect = true;
        playerControl.IncreaseJump();
        yield return new WaitForSeconds(5);
        //after 5 seconds the pickup effect stops
        playerControl.ResetJump();
        //GameManager.Instance.pickupEffect = false;

    }
    public void SpeedIncrese()
    {
        //calls the couroutine
        StartCoroutine(Pickup2());
    }
    public void InvincibleMethod()
    {
        //calls the couroutine
        StartCoroutine(Pickup3());
        
    }


}
