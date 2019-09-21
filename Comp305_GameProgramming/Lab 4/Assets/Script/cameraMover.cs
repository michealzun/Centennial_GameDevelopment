using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMover : MonoBehaviour {

    Camera cameraMain;
    GameObject player;
    public bool cameraLock;
    float lerp;
    void Start () {
        cameraMain = GameObject.Find("cameraMain").GetComponent<Camera>();
        player = GameObject.Find("player");
    }

	void Update () {
        if (player.transform.position.x < 10.5f && !cameraLock)
        {
            cameraMain.transform.position = new Vector3(0, 0, -10);
            cameraMain.orthographicSize = Mathf.Lerp(cameraMain.orthographicSize,7,Time.deltaTime);
        }else if(player.transform.position.x < 34 && !cameraLock)
        {
            cameraMain.transform.position = new Vector3(player.transform.position.x, 0, -10);
            cameraMain.orthographicSize = Mathf.Lerp(cameraMain.orthographicSize, 5, Time.deltaTime);
        }
        else if (!cameraLock)
        {
            cameraMain.orthographicSize = Mathf.Lerp(cameraMain.orthographicSize, (100f - player.transform.position.x) / 15f, Time.deltaTime);
            cameraMain.transform.position = new Vector3(player.transform.position.x, 0, -10);
        }
    }
}
