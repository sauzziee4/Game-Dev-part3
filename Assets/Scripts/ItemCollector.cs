using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemCollector : MonoBehaviour
{
    
    
    public static float collectibles = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("in collison");

        //when the player collects a collectible the counter goes up by one
        if (other.gameObject.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            collectibles++;
            
            
            
        }
    }
}
