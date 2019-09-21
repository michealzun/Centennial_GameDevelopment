using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runnerSpawn : MonoBehaviour {
    pointSpawn pS;
    public GameObject runner;
    Vector3 spawnPos;

    private void Start()
    {
        pS = GameObject.Find("Manager").GetComponent<pointSpawn>();
    }
    private void OnMouseDown()
    {
        if (pS.points.Length > 3) {
        spawnPos = pS.points[0].transform.position;
        Instantiate(runner, spawnPos,this.transform.rotation);
        }
}
}
