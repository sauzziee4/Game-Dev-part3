using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class Destroyer : MonoBehaviour
{

    GameObject[] enemylist = null;
    GameObject[] player = null;
    GameObject[] pickUplist = null;
    int i;
    int j;

    private Pointsmanager _pointManager = Pointsmanager.Instance;
    private const int _soloPoints = 5, _duoPoints = 10, _trioPoints = 15;



    //public int GetPoints()
    //{
        //return _pointManager.value;
    //}


    //counts how many enemies have died
    int deadCounter;
    public static string score;

    [SerializeField] TextMeshProUGUI scoreText;

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");
        deadCounter = 0;
    
    }
    private void Update()
    {
        //the gameobjects with the tag collectable are put in the pickup list
        pickUplist = GameObject.FindGameObjectsWithTag("Collectable");
        for (j = 0; j< pickUplist.Length; j++)
        {

            //if the pickup is behind the player it is destroyed
            if (pickUplist != null && pickUplist[j].GetComponent<Transform>().position.z < player[0].GetComponent<Transform>().position.z)
            {
                new WaitForSeconds(0.5f);
                Destroy(pickUplist[j]);

            }

        }
        //the gameobjects with the tag enemy are put into the enemylist 
        enemylist = GameObject.FindGameObjectsWithTag("Enemy");
        for (i = 0; i < enemylist.Length; i++)
        {
            //if the enemy is behind the player it is destroyed
            if (enemylist != null && enemylist[i].GetComponent<Transform>().position.z < player[0].GetComponent<Transform>().position.z)
            {

                
                new WaitForSeconds(0.1f);
                DestroyImmediate(enemylist[i]);
                deadCounter++;
                //_pointManager.value += _trioPoints;
                
                //used to show that once we pass an enemy our score goes up

                scoreText.text = "Score: " + deadCounter;
                score = scoreText.text;

            }


        }


    }

}
