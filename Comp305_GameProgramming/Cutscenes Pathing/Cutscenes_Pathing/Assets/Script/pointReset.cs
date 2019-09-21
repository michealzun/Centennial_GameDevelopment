using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointReset : MonoBehaviour {

    pointSpawn pS;

    private void Start()
    {
        pS = GameObject.Find("Manager").GetComponent<pointSpawn>();
    }

    private void OnMouseDown()
    {
        pS.counter = 0;
        foreach (GameObject point in pS.points)
        {
            Destroy(point);
        }
        pS.points = new GameObject[10];
    }
}
