using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDefeatButton : MonoBehaviour
{
    
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
        GameManager.Instance.SpawnBoss();

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
}
