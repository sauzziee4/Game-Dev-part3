using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TestBoss : MonoBehaviour 
{
    //even tho the script has test in the name this is the script used for the boss
    
    public bool awake = false;

    //player position
    float playerZ;
    float playerX;
    
    //the z position of the obstacles that the boss spawns
    float obstacleZ;

    GameObject[] player = null;
    

    public GameObject obstacle;

    //the bosses position
    float bossZ;

    //counting the obstacles
    float obstacleCount;
    

    public bool createObstacle = false;

    public GameManager gm;


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

            if (createObstacle == false)
            {
                createObstacle = true;
                StartCoroutine(ObstacleSpawn());
            }
            

        
        if ((GetComponent<Transform>().position.y <= -25))
        {
            gm.BossDeath();
            Destroy(gameObject);
        }


    }
    //The boss simply moves forward
    void Movement()
    {
        transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
    }
   
    
    //used to spwawn oibstacles in front of the player
    IEnumerator ObstacleSpawn()
    {

            //fetches the players position
            playerZ = player[0].GetComponent<Transform>().position.z;
            playerX = player[0].GetComponent<Transform>().position.x;
            
            bossZ = GetComponent<Transform>().position.z;

            //spawns the obstacle 5 feet in front of the player
            obstacleZ = playerZ + 5F;
            
            //Debug.Log("in obstacle spawn");
            Instantiate(obstacle,new Vector3(playerX,1,obstacleZ), Quaternion.identity);
            obstacleCount++;
            yield return new WaitForSeconds(2);
            createObstacle = false;
            new WaitForSeconds(5);
            
    }
}
