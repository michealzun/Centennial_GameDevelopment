using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointSpawn : MonoBehaviour {

    public GameObject point;
    public GameObject[] points= new GameObject[10];
    public int counter = 0;

	void Update () {
        if (Input.GetMouseButtonDown(1)&&counter<10)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            points[counter]=Instantiate(point, mousePos,this.transform.rotation);
            counter++;
        }
	}
}
