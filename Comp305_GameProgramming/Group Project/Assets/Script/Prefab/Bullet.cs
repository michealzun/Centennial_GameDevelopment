using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Rigidbody2D rb;
    Enemy enemy;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 20;
    }

    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.GetComponent<Enemy>() != null)
        {
            enemy = o.GetComponent<Enemy>();
            enemy.Damage(5);
            Destroy(this.gameObject);
        }
        if (o.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }
}
