using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //used for the first pickup

    //public AudioSource pickUpFX;
    private void OnTriggerEnter(Collider other)
    {
        //if the player collides with the pickup the pickup manager is notified and the object is destroyed
        if (other.gameObject.CompareTag("Player"))
        {
            EventManager.Instance.Pickup1Activated();
            //pickUpFX.Play();
            PickUpManager.Instance.JumpBoost(other.GetComponent<PlayerControl2>());
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
  
}
