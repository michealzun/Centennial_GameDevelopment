using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeactiveTextBox : MonoBehaviour {

    GameObject dialogBox;
    private void Start()
    {
        dialogBox = GameObject.Find("DialogBox");
        dialogBox.SetActive(false);
    }
}
