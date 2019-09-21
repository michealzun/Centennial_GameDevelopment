using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float speed;
    // Use this for initialization
    private Rigidbody2D rb = new Rigidbody2D();
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0f, -speed);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.name == "player")
        {
            ScoreController.instance.gainLife();
            Destroy(this.gameObject);
        }
    }
}
