using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class TestBoss : MonoBehaviour 
{
    public float _speed = 0.2f;

    float Spawnz;
    float Spawnx;
    public bool awake = false;

    float playerZ;
    float playerX;
    float playerY;
    float obstacleZ;

    GameObject[] player = null;
    float distanceDifferent;

    public GameObject obstacle;

    float bossZ;
    float obstacleCount;
    float obstacleMax = 5f;

    public bool createObstacle = false;

    public GameManager gm;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

    }
    private void Awake()
    {
        Spawnx=GetComponent<Transform>().position.x;
        Spawnz=GetComponent<Transform>().position.z;
        awake = true;
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //GameObject[] playerObject = GameObject.FindGameObjectsWithTag("Player");



    }

    // Update is called once per frame
    void Update()
    {
        



        if (awake== true) 
        {
            Movement();

            if (createObstacle == false)
            {
                createObstacle = true;
                StartCoroutine(ObstacleSpawn());
            }
            

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
        transform.Translate(Vector3.forward * _speed* Time.deltaTime);
    }
    //used to spwawn oibstacles in front of the player
    IEnumerator ObstacleSpawn()
    {


        
            //fetches the players position
            playerZ = player[0].GetComponent<Transform>().position.z;
            playerX = player[0].GetComponent<Transform>().position.x;
            playerY = player[0].GetComponent<Transform>().position.y;
            bossZ = GetComponent<Transform>().position.z;

        
            //distanceDifferent = bossZ - playerZ;
            
            //spawns the obstacle 5 feet in front of the player
            obstacleZ = playerZ + 5F;
            
            //Debug.Log("in obstacle spawn");
            Instantiate(obstacle,new Vector3(playerX,playerY,obstacleZ), Quaternion.identity);
            obstacleCount++;
            yield return new WaitForSeconds(2);
            createObstacle = false;
            new WaitForSeconds(5);
            
            


        
        




    }
}
