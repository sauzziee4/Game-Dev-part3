using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoss : MonoBehaviour 
{
    public float _speed = 1f;
    float Spawnz;
    float Spawnx;
    public bool awake = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        Spawnx=GetComponent<Transform>().position.x;
        Spawnz=GetComponent<Transform>().position.z;
        awake = true;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (awake== true) 
        {
            Movement();


        }
        
        
    }
    void Movement()
    {
        transform.Translate(Vector3.forward * _speed* Time.deltaTime);
    }
}
