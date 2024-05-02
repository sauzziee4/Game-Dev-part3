using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //Camera follows player
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float offsetZ = 10;
    

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.transform.position.z - offsetZ);
    }
}
