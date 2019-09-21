using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level0Dialog2 : MonoBehaviour {
    GameObject dialogBox;
    Text dialog;
    bool progress;
    private void Start()
    {
        dialogBox = GameObject.Find("DialogBox");
        dialog = GameObject.Find("Dialog").GetComponent<Text>();
    }
    private void Update()
    {
        progress = GameObject.Find("Progress").GetComponent<Progress>().gearUnlock[0];
    }
private void OnTriggerStay2D(Collider2D o)
    {
        if (o.tag=="Player")
        {
                dialogBox.SetActive(true);
                dialog.text = "The Door is Jammed, I need to pry it open with something";
        }
    }

    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            dialogBox.SetActive(false);
            if (progress)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
