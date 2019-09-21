using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level0Dialog3 : MonoBehaviour {
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
            if (!GameObject.Find("Progress").GetComponent<Progress>().gearUnlock[0])
            {
                dialogBox.SetActive(true);
                dialog.text = "That looks useful";
            }
            else
            {
                dialogBox.SetActive(true);
                dialog.text = "J - swing attack, Shift - dash";
            }
        }
    }

    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            dialogBox.SetActive(false);
            if (GameObject.Find("Progress").GetComponent<Progress>().gearUnlock[0])
            {
                Destroy(this.gameObject);
            }
        }
    }
}
