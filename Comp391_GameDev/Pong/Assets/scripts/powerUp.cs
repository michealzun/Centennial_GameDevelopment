using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUp : MonoBehaviour {
    public GameObject pOne;
    public GameObject pTwo;
    public GameObject shot;
    public GameObject shotLeft;
    // Use this for initialization
    void Start () {
        pOne = GameObject.Find("PadOne");
        pTwo = GameObject.Find("PadTwo");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.name == "Ball")
        {
            this.GetComponent<Renderer>().enabled = false;
            int user = GameObject.Find("Ball").GetComponent<BallController>().lastHit;
            if (user == 1) {
                Instantiate(shotLeft, pOne.transform.position, pOne.transform.rotation);
            }
            else if (user == 2) {
                Instantiate(shot, pTwo.transform.position, pTwo.transform.rotation);
            }
            Destroy(this.gameObject);
        }
    }
}
