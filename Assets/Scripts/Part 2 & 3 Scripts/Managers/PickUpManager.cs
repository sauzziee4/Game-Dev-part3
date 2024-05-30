using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PickUpManager : MonoBehaviour
{
    //manages the pickups
    public static PickUpManager Instance {  get; private set; }

    public GameObject[] pickupPrefab1;
    public GameObject[] pickupPrefab2;
    public GameObject[] pickupPrefab3;
    public Transform[] spawnPoints;




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
    private void Start()
    {
        StartCoroutine(SpawnPickupRoutine());
        // Subscribe to GameManager events
        GameManager.Instance.OnPickup1Activated.AddListener(OnPickup1Activated);
        GameManager.Instance.OnPickup2Activated.AddListener(OnPickup2Activated);
        GameManager.Instance.OnPickup3Activated.AddListener(OnPickup3Activated);
    }
    private void Update()
    {
       
        
        
    }
    //used to set a delay between spawning pickups
    private IEnumerator SpawnPickupRoutine()
    {
        while(true)
        {
            SpawnPickups();
            //a ten sceond delay
            yield return new WaitForSeconds(10f);
        }
    }
    private void SpawnPickups()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);//choses a random spawnpoint
        int PickupType = Random.Range(1, 4); // Randomly select enemy type 1, 2, or 3

        GameObject PickupPrefab = null;

        // switch statement using the previous random to choose a random pickupprefab within the list of that pickupprefab
        switch (PickupType)
        {
            case 1:
                PickupPrefab = pickupPrefab1[Random.Range(0, pickupPrefab1.Length)];
                break;
            case 2:
                PickupPrefab = pickupPrefab2[Random.Range(0, pickupPrefab2.Length)];
                break;
            case 3:
                PickupPrefab = pickupPrefab3[Random.Range(0, pickupPrefab3.Length)];
                break;
            default:
                Debug.LogWarning("Invalid enemy type.");
                break;
        }
        Instantiate(PickupPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);


    }

    //the event for the first pickup is not implemented yet
    private void OnPickup1Activated()
    {

    }
    //for the second pickup
    private void OnPickup2Activated()
    {
        StartCoroutine(Pickup2());

    }
    //for the third pickup
    private void OnPickup3Activated()
    {
        StartCoroutine(Pickup3());

    }
    //the couroutine for the speed up
    public IEnumerator Pickup2()
    {
        Debug.Log("pickup 2 is activated");
        
        speedUp = true;
        yield return new WaitForSeconds(5);
        //after 5 seconds the pickup effect stops
        speedUp = false;
        
        
    }
    //the couroutine for the invincible powerup
    public IEnumerator Pickup3()
    {
        Debug.Log("pickup 3 is activated");

        invincible = true;
        yield return new WaitForSeconds(5);
        //after 5 seconds the pickup effect stops
        invincible = false;
        

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
    


}
