using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class badpost : MonoBehaviour {
    Rigidbody2D rb;
    manager manager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            manager.score++;
            Instantiate(Resources.Load("explosion"), this.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        if (collision.gameObject.name == "banner")
        {
            int spawnNumber = Mathf.RoundToInt(manager.speed);
            for (int i = 0; i < spawnNumber; i++)
            {
                    Vector3 spawnLoc = new Vector3(-10, (Random.value - 0.5f) * 10.6f, 0);
                    Instantiate(Resources.Load("fish"), spawnLoc, Quaternion.identity);
            }      
        }
    }
    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        manager = GameObject.Find("manager").GetComponent<manager>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(0,manager.speed);
        if (this.transform.position.y > 10)
            Destroy(this.gameObject);
    }
}
