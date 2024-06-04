using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PickUpManager : MonoBehaviour
{
    //manages the pickups
    public static PickUpManager Instance {  get; private set; }

    public GameObject pickupPrefab1;
    public GameObject pickupPrefab2;
    public GameObject pickupPrefab3;
    public Transform[] spawnPoints;




    public static bool speedUp;
    public static bool invincible;
    //pickup 3
    public static bool pk3;
    //pickup4
    public static bool pk4;
    public float pickupID;
    


    [Header("Audio clips")]
    public AudioClip speedBuffClip;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
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
        if (LevelManager.Instance.currentLevelName=="GameOver")
        {
            StopCoroutine(SpawnPickupRoutine());
        }
        
       
        
        
    }
    //used to set a delay between spawning pickups
    private IEnumerator SpawnPickupRoutine()
    {
        while(true)
        {
            Vector3 spawningSpot = hardcodedSpawnPoints[Random.Range(0, hardcodedSpawnPoints.Length)];

            pickupID=Random.Range(0, 3);
            InstantiatePickup(pickupID, spawningSpot);
            
            //a ten sceond delay
            yield return new WaitForSeconds(10f);
        }
    }
    private void InstantiatePickup(float pickupID, Vector3 position)
    {
        if (pickupID==0)
        {
            Instantiate(pickupPrefab1, position, Quaternion.identity);

        }
        if (pickupID == 1)
        {
            Instantiate(pickupPrefab2, position, Quaternion.identity);

        }
        if(pickupID == 2)
        {
            Instantiate(pickupPrefab3, position, Quaternion.identity);

        }

    }
    
    public Vector3[] hardcodedSpawnPoints = new Vector3[3]
    {
         new Vector3(-3f, 1f, 29.2f),
         new Vector3(0f, 1f, 29.2f),
         new Vector3(3f, 1f, 29.2f)
     };

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
