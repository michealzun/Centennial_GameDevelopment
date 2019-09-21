using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMover : MonoBehaviour {

    public LayerMask mask;
    GameObject player;
    Rigidbody2D rb;
    bool grounded;
    public bool cameraLock;
	void Start () {
        player = GameObject.Find("player");
        rb = player.GetComponent<Rigidbody2D>();
        grounded = true;
    }
	
	void Update () {
        grounded = Physics2D.OverlapCircle(player.transform.position, 0.6f, mask);
        rb.velocity = new Vector2( Input.GetAxis("Horizontal")*5, rb.velocity.y);
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y+10);
        }
    }
}
