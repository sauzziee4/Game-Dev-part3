using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PK3Collid : MonoBehaviour
{
    //used for the third pickup

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
        //if the player collides with the pickup the pickup manager is notified and the object is destroyed
        if (other.gameObject.CompareTag("Player"))
        {
            EventManager.Instance.Pickup3Activated();
            PickUpManager.Instance.InvincibleMethod();
            Destroy(this.gameObject);

        }
        
        
            
        
    }
}
