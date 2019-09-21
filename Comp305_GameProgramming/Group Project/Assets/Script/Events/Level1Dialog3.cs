using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1Dialog3 : MonoBehaviour {
    GameObject dialogBox;
    Text dialog;
    private void Start()
    {
        dialogBox = GameObject.Find("DialogBox");
        dialog = GameObject.Find("Dialog").GetComponent<Text>();
    }
    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            if (!GameObject.Find("Progress").GetComponent<Progress>().gearUnlock[1])
            {
                dialogBox.SetActive(true);
                dialog.text = "I'll need a way to deal with the turret on the other side";
            }
            else
            {
                dialogBox.SetActive(true);
                dialog.text = "press k to shoot";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            dialogBox.SetActive(false);
            if (GameObject.Find("Progress").GetComponent<Progress>().gearUnlock[1])
            {
                Destroy(this.gameObject);
            }
        }
    }
}
