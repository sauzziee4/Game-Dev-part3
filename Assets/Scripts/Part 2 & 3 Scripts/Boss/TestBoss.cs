using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEditor.Experimental.GraphView.GraphView;

public class TestBoss : MonoBehaviour 
{
    //even tho the script has test in the name this is the script used for the boss
    
    public bool awake = false;

    //player position
    float playerZ;
    float playerX;
    
    //the z position of the obstacles that the boss spawns
    float obstacleZ;

     public GameObject[] player = null;
    

    public GameObject obstacle;

    //the bosses position
    float bossZ;

    //counting the obstacles
    float obstacleCount;
    

    public bool createObstacle = false;

    public GameManager gm;

    public float throwInterval = 2f;
    private float throwTimer = 0f;
    public Transform throwPoint;


    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectsWithTag("Player");
       

    }
    private void Awake()
    {
        
        awake = true;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");

    }
    

    // Update is called once per frame
    void Update()
    {
        Movement();

        throwTimer =+Time.deltaTime;
        if (throwTimer>= throwInterval)
        {
            ThrowProjectileAtPlayer();
            throwTimer = 0f;
        }

            if (createObstacle == false)
            {
                createObstacle = true;
                StartCoroutine(ObstacleSpawn());
            }
            

        
        


    }

    private void ThrowProjectileAtPlayer()
    {
        Debug.Log("in new obstacle spawn");
        Instantiate(obstacle,throwPoint.position,throwPoint.rotation);
       

    }
    //The boss simply moves forward
    void Movement()
    {
        playerX = player[0].GetComponent<Transform>().position.x;
        Vector3 bossPosition =transform.position;
        
        //transform.position += new Vector3(0, 0, -4) * Time.deltaTime;
        bossPosition.x =playerX;
        transform.position =bossPosition;
        
    }
   
    
    //used to spwawn oibstacles in front of the player
    IEnumerator ObstacleSpawn()
    {

            //fetches the players position
            
            
            bossZ = GetComponent<Transform>().position.z;

            //spawns the obstacle 5 feet in front of the player
            obstacleZ = playerZ + 5F;
            
            //Debug.Log("in old obstacle spawn");
            Instantiate(obstacle,throwPoint.position, Quaternion.identity);
            obstacleCount++;
            yield return new WaitForSeconds(2);
            createObstacle = false;
            new WaitForSeconds(5);
            
    }
}
