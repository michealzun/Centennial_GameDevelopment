using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level0Dialog1 : MonoBehaviour {
    GameObject dialogBox;
    Text dialog;
    private void Start()
    {
        dialogBox = GameObject.Find("DialogBox");
        dialog = GameObject.Find("Dialog").GetComponent<Text>();
    }
    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.tag=="Player")
        {
            dialogBox.SetActive(true);
            dialog.text = "Use WASD to move";
        }
    }

    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            dialogBox.SetActive(false);
            Destroy(this.gameObject);
        }
    }
}
