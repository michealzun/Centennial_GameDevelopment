using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runnerPathing : MonoBehaviour {

    pointSpawn pS;
    public Vector3[] pos;
    public int counter;
    public int curPosCounter = 0;
	void Start () {
        pS = GameObject.Find("Manager").GetComponent<pointSpawn>();
        pos = new Vector3[pS.counter];
        counter = pS.counter;
        for (int i = 0; i < counter; i++)
        {
            pos[i] = pS.points[i].transform.position;
        }
	}

    private void FixedUpdate()
    {
        if (curPosCounter < counter)
        {
            if (Vector2.Distance(this.transform.position, pos[curPosCounter]) > 0.1f) {
                this.transform.position = Vector3.MoveTowards(this.transform.position, pos[curPosCounter], 0.05f);
            }
            else {
            curPosCounter++;
            }
        }
        else { Destroy(this.gameObject); };
    }

}
