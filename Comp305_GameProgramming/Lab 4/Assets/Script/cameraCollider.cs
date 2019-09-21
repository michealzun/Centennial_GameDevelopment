using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraCollider : MonoBehaviour {
    GameObject manager;
    GameObject player;
    GameObject cameraMain;
    public float size;
    private void Start()
    {
        manager = GameObject.Find("Manager");
        player = GameObject.Find("player");
        cameraMain = GameObject.Find("cameraMain");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            manager.GetComponent<cameraMover>().cameraLock = true;
        }
        cameraMain.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10);
        cameraMain.GetComponent<Camera>().orthographicSize = Mathf.Lerp(cameraMain.GetComponent<Camera>().orthographicSize, size, Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            manager.GetComponent<cameraMover>().cameraLock = false;
        }
    }
}
