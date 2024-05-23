using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetricManager : MonoBehaviour
{
    public static MetricManager Instance { get; private set; }
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
