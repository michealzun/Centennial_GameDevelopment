using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeUp : MonoBehaviour {
    float size = 2;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        size -= Time.deltaTime * 2;
        this.transform.localScale = new Vector3(size, size,1);
        if (size <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
