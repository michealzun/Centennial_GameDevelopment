using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward * 5;
        StartCoroutine(Timer());
    }

    void OnTriggerEnter(Collider other)
    { 
        if(other.gameObject.tag=="walls")
            Destroy(this.gameObject);
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10);
        Destroy(this.gameObject);
    }

}
