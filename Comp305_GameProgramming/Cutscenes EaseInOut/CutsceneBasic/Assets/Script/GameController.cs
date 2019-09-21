using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject arrow;

    public GameObject[] arrows;
    int timer=0;
    void Start () {
        arrows = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            arrows[i] = Instantiate(arrow, new Vector3(-8, 3 - 2 * i, 0), Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        if (timer<100)
        {
            arrows[0].GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            arrows[1].GetComponent<Rigidbody2D>().AddForce( new Vector3(2.5f,0,0));
            arrows[2].GetComponent<Rigidbody2D>().velocity = new Vector2(5, 0);
            arrows[3].GetComponent<Rigidbody2D>().AddForce(new Vector3(2.5f, 0, 0));
        }
        if (timer > 110 && arrows[2].transform.position.x < 8)
        {
            arrows[2].GetComponent<Rigidbody2D>().AddForce(new Vector3(-2.5f, 0, 0));
        }
        if (timer> 160 && arrows[3].transform.position.x < 8)
        {
            arrows[3].GetComponent<Rigidbody2D>().AddForce(new Vector3(-2.5f, 0, 0));
        }


        foreach (GameObject i in arrows)
        {
            if (i.transform.position.x >= 8)
            {
                i.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            }
        }

        timer++;
        if (timer == 300)
        {
            timer = 0;
            resetPos();
        }
    }

    void resetPos()
    {
        for (int i = 0; i < 4; i++)
        {
            arrows[i].transform.position = new Vector3(-8, 3 - 2 * i, 0);
            arrows[i].GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }
}
