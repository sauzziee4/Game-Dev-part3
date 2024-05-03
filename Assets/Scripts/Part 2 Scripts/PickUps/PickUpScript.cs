using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource pickUpFX;
    private void OnTriggerEnter(Collider other)
    {
        pickUpFX.Play();
        this.gameObject.SetActive(false);
    }
}
