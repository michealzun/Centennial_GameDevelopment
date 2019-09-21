using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour {

    // Use this for initialization
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
