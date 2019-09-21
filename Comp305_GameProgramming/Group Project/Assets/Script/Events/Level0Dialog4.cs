using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level0Dialog4 : MonoBehaviour {
    GameObject dialogBox;
    Text dialog;
    cameraFollow cam;
    private void Start()
    {
        dialogBox = GameObject.Find("DialogBox");
        dialog = GameObject.Find("Dialog").GetComponent<Text>();
        cam = GameObject.Find("Main Camera").GetComponent<cameraFollow>();
    }
    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.tag=="Player")
        {
            cam.camLock = true;
            cam.targetPos = new Vector2(16, -2);
            cam.targetSize = 7;
            dialogBox.SetActive(true);
            dialog.text = "these turrets are active. Use 'shift' to dash across without getting shot";
        }
    }

    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            cam.camLock = false;
            dialogBox.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
