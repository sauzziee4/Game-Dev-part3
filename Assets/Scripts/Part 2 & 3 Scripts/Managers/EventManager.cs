using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public event Action OnObstaclePassed;
    public event Action OnPickup1Activated;
    public event Action OnPickup2Activated;
    public event Action OnPickup3Activated;
    public event Action OnBossSpawned;
    public event Action OnBossBeaten;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void ObstaclePassed()
    {
        Debug.Log("obstaclepassed");
        OnObstaclePassed?.Invoke();
    }
    public void Pickup1Activated()
    {
        OnPickup1Activated?.Invoke();

    }
    public void Pickup2Activated()
    {
        OnPickup2Activated?.Invoke();

    }
    public void Pickup3Activated()
    {
        OnPickup3Activated?.Invoke();

    }
    public void BossSpawned()
    {
        OnBossSpawned?.Invoke();

    }
    public void BossBeaten()
    {
        OnBossBeaten?.Invoke();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
