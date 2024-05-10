using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testingdestroy : MonoBehaviour
{
    public GameManager gm;
    public int KillReward = 5;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("in collison");

        //when the player collects a collectible the counter goes up by one
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("player has died");
            Destroy(other.gameObject);
            



        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.score += KillReward;
            GameManager.Instance.kills += 1;
            
            Debug.Log("enemy has been destroyed");
            Destroy(other.gameObject);
            //Debug.Log(other.gameObject.name);
        }
        
        if (other.gameObject.CompareTag("Boss"))
        {
            Debug.Log("boss has been killed");
            gm.BossDeath();
            Destroy(other.gameObject);

        }
        else
        {
            //Debug.Log("other destroyed");
            //Destroy(other.gameObject);

        }
    }

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
