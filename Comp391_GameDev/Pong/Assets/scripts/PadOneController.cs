using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadOneController : MonoBehaviour {
    public Animator anim;
    public float speed;

    private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0f, speed);
        } else if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = new Vector2(0f, -speed);
        } else { rb.velocity = new Vector2(0f, 0f);
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Ball")
        {
            anim.Play("ryuattack");
        }

    }
}
