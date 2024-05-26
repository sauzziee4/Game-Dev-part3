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
}
