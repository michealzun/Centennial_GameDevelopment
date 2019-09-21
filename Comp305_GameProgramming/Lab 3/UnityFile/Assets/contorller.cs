using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contorller : MonoBehaviour {

    public GameObject[] player;
    public player[] p;
    public LayerMask layer;
    void Start () {
        p = new player[3];
        for (int i = 0; i < 3; i++)
        {
            p[i] = new player(player[i],layer);
        }
    }
	
	void FixedUpdate () {
        p[0].PerUpdate(Input.GetAxis("H1"), Input.GetAxis("V1"));
        p[1].PerUpdate(Input.GetAxis("H2"), Input.GetAxis("V2"));
        p[2].PerUpdate(Input.GetAxis("H3"), Input.GetAxis("V3"));
    }
}
