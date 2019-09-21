using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

    public Transform bg1;
    public Transform bg2;
    public Transform cam;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(bg1.position.y< cam.position.y - 20.48f)
        {
            bg1.position = new Vector3(0, bg2.position.y + 20.48f, 0);
        }
        if (bg2.position.y < cam.position.y - 20.48f)
        {
            bg2.position = new Vector3(0, bg1.position.y + 20.48f, 0);
        }
    }
}
