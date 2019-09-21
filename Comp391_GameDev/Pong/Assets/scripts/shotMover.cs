using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shotMoverLeft : MonoBehaviour {

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 0f);
    }
}
