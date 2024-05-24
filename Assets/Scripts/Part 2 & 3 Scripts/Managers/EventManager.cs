using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance { get; private set; }

    public event Action OnObstaclePassed;
    public event Action OnPickupActivated;
    public event Action OnBossSpawned;
    public event Action OnBossBeaten;

    private static Dictionary<string, UnityEvent> eventDictionary = new Dictionary<string, UnityEvent>();

    public static void StartListening(string eventname, UnityAction listener)
    {
        if (eventDictionary.TryGetValue(eventname,out UnityEvent thisEvent))
        {
            thisEvent.AddListener(listener);
        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            eventDictionary.Add(eventname, thisEvent);
        }
    }
    public static void Stoplistening(string eventname, UnityAction listener)
    {
        if (eventDictionary.TryGetValue(eventname, out UnityEvent thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }
    public static void TriggerEvent(string eventName)
    {
        if (eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
        {
            thisEvent.Invoke();
        }
    }

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
