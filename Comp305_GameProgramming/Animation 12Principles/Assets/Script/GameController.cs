using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // Use this for initialization
    private GameObject camera;
	void Start () {
        camera = GameObject.Find("MainCamera");

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.A))
        {
            camera.transform.position = new Vector3(camera.transform.position.x - 0.5f, camera.transform.position.y, camera.transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            camera.transform.position = new Vector3(camera.transform.position.x + 0.5f, camera.transform.position.y, camera.transform.position.z);
        }
    }
}
