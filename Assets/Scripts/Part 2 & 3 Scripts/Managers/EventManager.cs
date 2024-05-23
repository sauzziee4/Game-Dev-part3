using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public event Action OnObstaclePassed;
    public event Action OnPickupActivated;
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
        OnObstaclePassed?.Invoke();
    }
    public void PickupActivated()
    {
        OnPickupActivated?.Invoke();

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
