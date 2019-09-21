using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Dialog2 : MonoBehaviour {
    cameraFollow cam;
    GameObject bossLock;
    GameObject miniMap;
    private void Start()
    {
        miniMap = GameObject.Find("MiniMapBack");
        cam = GameObject.Find("Main Camera").GetComponent<cameraFollow>();
        bossLock = GameObject.Find("BossLock");
        bossLock.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            StartCoroutine(StartBoss());
            miniMap.SetActive(false);
        }
    }
    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            cam.camLock = true;
            cam.targetPos = new Vector2(54.5f, -21.25f);
            cam.targetSize = 11;
        }
    }

    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            cam.camLock = false;
            miniMap.SetActive(true);
        }
    }
    IEnumerator StartBoss()
    {
        yield return new WaitForSeconds(2);
        bossLock.SetActive(true);
        GameObject.Find("Controller").GetComponent<gameController>().bossStage=1;
    }
}
