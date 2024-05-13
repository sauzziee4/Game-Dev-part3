using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PickUpManager : MonoBehaviour
{
    public static PickUpManager Instance {  get; private set; }
    public static bool checkPower { get; set; }
    public float duration = 5f;
    // public PowerUpEffects powerUpEffect;

    //pickup 2
    
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
        Debug.Log(checkPower + "checkPower");
        if (checkPower)
        { 
            StartCoroutine(SpeedRoutine());
        
        }
        

        //}
        if (pk3 == true)
        {
            Debug.Log("pickup3 has been hit");
            StartCoroutine (Pickup3());

        }
    }
    public IEnumerator Pickup2()
    {
        GameManager.Instance.pickupEffect = true;
        speedUp = true;
        yield return new WaitForSeconds(5);
        speedUp = false;
        GameManager.Instance.pickupEffect = false;
        //the code for the second pickup will go in here
        //yield return new WaitForSeconds(1f);
    }
    public IEnumerator Pickup3()
    {
        GameManager.Instance.pickupEffect = true;
        invincible = true;
        yield return new WaitForSeconds(5);
        invincible = false;
        GameManager.Instance.pickupEffect = false;

    }
    


    //This is old code from when Muhmmed uploaded his pickup scripts
    public IEnumerator SpeedRoutine()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player").gameObject;


        // Pre-Routine Setup
        float elapsedTime = 0f;
        // Activate the PowerUp on the Player
        Debug.unityLogger.Log("Boost Power Up Activated.");

        // Routine
        while (elapsedTime < duration)
        {
            //SoundManager.Instance.Play(speedBuffClip);
            elapsedTime += Time.deltaTime;
            Debug.unityLogger.Log("Power Up Active.");
            //powerUpEffect.ApplyEffect(player);
            yield return null;
        }

        // Post-Routine Cleanup
        DeactivateSpeedBoost(player);
      
        Debug.Log("After effect");
        
        //yield return new WaitForSeconds(2f);
        
        Debug.Log("Removing effect");
        DeactivateSpeedBoost(player);
    }

    public void ActivateSpeedBoost()
    { 
        SpeedRoutine();
    
    }

    void DeactivateSpeedBoost(GameObject player)
    {
        
        //powerUpEffect.RemoveEffect(player);

    }

    public void JumpBoost(PlayerControl2 playerControl)
    {
        StartCoroutine(JumpBoostCoroutine(playerControl));
    }

    private IEnumerator JumpBoostCoroutine(PlayerControl2 playerControl)
    {
        GameManager.Instance.pickupEffect = true;
        playerControl.IncreaseJump();
        yield return new WaitForSeconds(5);
        playerControl.ResetJump();
        GameManager.Instance.pickupEffect = false;

    }
    public void SpeedIncrese()
    {
        StartCoroutine(Pickup2());
    }
    public void InvincibleMethod()
    {
        StartCoroutine(Pickup3());
        
    }


}
