using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb = new Rigidbody2D();
    private GameObject player;
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
            this.gameObject.transform.localScale = new Vector2(0,0);
            StartCoroutine(ShooterChange());
        }
    }

    IEnumerator ShooterChange()
    {
        player = GameObject.Find("player");
        player.transform.localScale = new Vector2(player.transform.localScale.x * 1.5f, player.transform.localScale.y);
        yield return new WaitForSeconds(5f);
        player.transform.localScale = new Vector2(player.transform.localScale.x / 1.5f, player.transform.localScale.y);
        Destroy(this.gameObject);
    }
}
