using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Dialog4 : MonoBehaviour {
    cameraFollow cam;
    private void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<cameraFollow>();
    }
    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            cam.camLock = true;
            cam.targetPos = new Vector2(10f, -30f);
            cam.targetSize = 12;
        }
    }

    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            cam.camLock = false;
        }
    }
}
