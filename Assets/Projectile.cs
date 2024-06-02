using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0,0,-1)*speed* Time.deltaTime);;
        
    }
    
}
