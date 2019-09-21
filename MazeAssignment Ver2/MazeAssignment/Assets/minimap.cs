using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minimap : MonoBehaviour {

    public GameObject player;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = player.transform.position + new Vector3(0, 30, 0);
	}
}
