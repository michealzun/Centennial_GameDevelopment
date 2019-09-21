using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int type;
    public GameObject ball;
    private void OnMouseDown()
    {
        ball.GetComponent<Mover>().type = type;
        ball.GetComponent<Mover>().curSeg = 0;
    }
}
