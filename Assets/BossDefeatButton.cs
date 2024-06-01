using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeatButton : MonoBehaviour
{
    //varios methods that can be triggered by pressing the button
    //this is for testing purposes
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Bossdefeatmethod()
    {
        GameManager.Instance.DefeatBoss();
    }
    public void BossSpawnmethod()
    {
        GameManager.Instance.SpawnBoss1();

    }
    public void Pickup1()
    {
        GameManager.Instance.ActivatePickup1();
    }
    public void Pickup2()
    { GameManager.Instance.ActivatePickup2();
    
    }
    public void Pickup3()
    { GameManager.Instance.ActivatePickup3();
    }
    public void NextLevelmethod()
    {
        LevelManager.Instance.LoadNextLevel();

    }
    public void SubmitScoremethod()
    {

    }
}
