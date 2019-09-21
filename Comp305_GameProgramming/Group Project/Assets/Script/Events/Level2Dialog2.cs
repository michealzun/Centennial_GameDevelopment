using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2Dialog2 : MonoBehaviour {
    GameObject dialogBox;
    Text dialog;
    private void Start()
    {
        dialogBox = GameObject.Find("DialogBox");
        dialog = GameObject.Find("Dialog").GetComponent<Text>();
    }
    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.tag == "Player" && GameObject.Find("Progress").GetComponent<Progress>().gearUnlock[2] == true)
        {
            dialogBox.SetActive(true);
            dialog.text = "The repair module broke off...press l to heal. You can't move while using it. recharge the charges are heal stations";
        }
    }
    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == "Player" && GameObject.Find("Progress").GetComponent<Progress>().gearUnlock[2] == true)
        {
            dialogBox.SetActive(false);
            Destroy(this.gameObject);
        }
    }

}
