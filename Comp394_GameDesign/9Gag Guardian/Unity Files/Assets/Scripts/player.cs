using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0);
            Vector3 spawnPos = new Vector3(this.transform.position.x-0.3f, this.transform.position.y + 1, 0);
            GameObject star= (GameObject)Instantiate(Resources.Load("star"), spawnPos, Quaternion.identity);
            star.GetComponent<Rigidbody2D>().velocity = (mouse - star.transform.position).normalized*10;
        }
    }
}
