using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsManager : MonoBehaviour
{

    public static PointsManager Instance { get; private set; }

    //public int value = 0;


    private void Awake()
    {
        //does this reset the score on a new game
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }



}
