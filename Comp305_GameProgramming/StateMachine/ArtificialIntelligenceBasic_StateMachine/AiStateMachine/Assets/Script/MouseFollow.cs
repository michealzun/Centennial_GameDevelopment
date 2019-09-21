using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour {

    private Vector3 lastLocation;
    void Start () {
	}

    void Update()
    {
        lastLocation = this.transform.position;
        followMouse();
    }

    void followMouse()
    {
        Vector3 mouselocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        mouselocation = Camera.main.ScreenToWorldPoint(mouselocation);
        this.transform.position = mouselocation;
        if(this.transform.position!= lastLocation) { 
        this.transform.up = lastLocation - this.transform.position;
        }
    }

}
