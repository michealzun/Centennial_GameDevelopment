using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goodpost : MonoBehaviour {
    Rigidbody2D rb;
    manager manager;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Instantiate(Resources.Load("explosion"), this.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        manager= GameObject.Find("manager").GetComponent<manager>();
    }
    private void Update()
    {
        rb.velocity = new Vector2(0, manager.speed);
        if (this.transform.position.y > 10)
            Destroy(this.gameObject);
    }
}
