using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossLock : MonoBehaviour {
	void Start ()
    {	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(!GameObject.Find("boss"))
        {
            Destroy(this.gameObject);
        }
    }
}
