using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireCloud.Entity;

public class TurretBullet : MonoBehaviour {

    Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 10;
        Destroy(this.gameObject, 5000);
    }
    private void OnTriggerEnter2D(Collider2D o)
    {
        if(o.gameObject.tag == "Player")
        {
            o.gameObject.GetComponent<EntityAttribute>().Damage(15);
            Destroy(this.gameObject);
        }

        if (o.gameObject.CompareTag("Wall") || o.gameObject.CompareTag("BulletProof"))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D o)
    {
        if (o.gameObject.tag == "Player")
        {
            o.gameObject.GetComponent<EntityAttribute>().Damage(15);
            Destroy(this.gameObject);
        }

        if (o.gameObject.CompareTag("Wall") || o.gameObject.CompareTag("BulletProof"))
        {
            Destroy(this.gameObject);
        }
    }
}
