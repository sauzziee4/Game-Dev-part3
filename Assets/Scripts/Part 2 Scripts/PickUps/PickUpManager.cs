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
        //if(speedPIckUP==true)
        //{
            Debug.Log("picup2 two has been hit");
            //StartCoroutine(Pickup2());

        //}
        if (pk3 == true)
        {
            Debug.Log("pickup3 has been hit");
            StartCoroutine (Pickup3());

        }
    }
    public IEnumerator Pickup2()
    {
        speedUp = true;
        yield return new WaitForSeconds(5);
        speedUp = false;
        //the code for the second pickup will go in here
        //yield return new WaitForSeconds(1f);
    }
    public IEnumerator Pickup3()
    {
        //the code for the third pickup woill go in here
        yield return new WaitForSeconds(1f);
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
        playerControl.IncreaseJump();
        yield return new WaitForSeconds(5);
        playerControl.ResetJump();

    }
    public void SpeedIncrese()
    {
        StartCoroutine(Pickup2());
    }
  

}
