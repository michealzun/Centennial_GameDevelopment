using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colorChanger : MonoBehaviour {

    public GameObject player;
    public Sprite sprite;
    void OnMouseDown()
    {
        Debug.Log("color change");
        player.GetComponent<SpriteRenderer>().sprite = sprite;
    }
}
