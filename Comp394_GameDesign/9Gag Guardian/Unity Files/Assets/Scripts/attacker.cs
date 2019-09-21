using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attacker : MonoBehaviour {
    Rigidbody2D rb;
    GameObject kiki;
    private Text text;
    void Start () {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        kiki = GameObject.Find("kiki");
        text = GameObject.Find("Canvas/Text").GetComponent<Text>();
        rb.velocity = (kiki.transform.position - this.gameObject.transform.position).normalized;
    }
	
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.name == "kiki")
        {
            text.text = "game over";
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }

}
