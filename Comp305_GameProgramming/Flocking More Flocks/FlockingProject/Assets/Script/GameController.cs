using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int spawnNumber;
    public GameObject orb;
    public GameObject[] orbs;
    Vector3 mouselocation;

    public float neighbourDistance = 2;
    public float personalSpace = 0.4f;

    private int timer=0;

    void Start () {
        spawnOrb();  
	}

    void Update()
    {
        //followMouse();
        timer++;
        if (timer == 100)
        {
            randomAcc();
            timer = 0;
        }
    }
    

    /*
    void followMouse()
    {
        mouselocation = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10);
        mouselocation = Camera.main.ScreenToWorldPoint(mouselocation);
        this.transform.position = mouselocation;
    }
    */

    void randomAcc()
    {
        Vector3 randomDirection = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3), 0);
        this.GetComponent<Rigidbody2D>().velocity = randomDirection;
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -8, 8), Mathf.Clamp(this.transform.position.y, -5, 5), 0);
    }

    void spawnOrb()
    {
        orbs = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-8, 8), Random.Range(-5, 5), 0);
            orbs[i] = Instantiate(orb, spawnLocation, Quaternion.identity);
            orbs[i].GetComponent<Unit>().manager = this.gameObject;
        }
    }
}
