using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testdestroyer : MonoBehaviour
{
    private PointsManager _pointManager = PointsManager.Instance;

    private const int _soloPoints = 5, _duoPoints = 10, _trioPoints = 15;
    GameObject[] player = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Transform>().position.z < player[0].GetComponent<Transform>().position.z)
        {
            

            _pointManager.value += _trioPoints;
            Debug.Log(_pointManager.value);
            Destroy(this.gameObject);

        }


    }
    public int GetPoints()
    {
        return _pointManager.value;
    }
}
