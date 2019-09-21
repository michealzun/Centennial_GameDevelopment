using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour {

    void Start()
    {
        StartCoroutine(destroy());
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
	
}
