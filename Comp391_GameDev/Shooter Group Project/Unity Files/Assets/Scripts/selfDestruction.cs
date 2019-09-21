using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfDestruction : MonoBehaviour {
    public float time;
	// Use this for initialization
	void Start () {
        StartCoroutine(timer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private IEnumerator timer()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
