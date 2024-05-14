using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //public AudioSource pickUpFX;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //pickUpFX.Play();
            PickUpManager.Instance.JumpBoost(other.GetComponent<PlayerControl2>());
            Destroy(this.gameObject);
        }
    }
  
}
