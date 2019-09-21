using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float speed;
    public int spawnChance;
    public GameObject healthUp;
    public GameObject shooter;
    private Text gameovertext;
    private Rigidbody2D rb;
    // Use this for initialization

    IEnumerator Pause()
    {
        this.transform.position = new Vector2(0f, -2f);
        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(1f);
        launchBall();
    }

    void launchBall()
    {
        rb.velocity = new Vector2(0f, -speed);
    }

    void Start () {
        gameovertext = GameObject.Find("Life").GetComponent<Text>();
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(Pause());
    }
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.y < -5f)
        {
            ScoreController.instance.loseLife();
            if (ScoreController.instance.life > 0)
            { 
            StartCoroutine(Pause());
            } else { Destroy(gameObject); }
        }
        if (gameovertext.text== "Victory")
        {
            Destroy(gameObject);
        }
    }
    
    void OnCollisionEnter2D (Collision2D hit)
    {
        if (hit.gameObject.name == "player")
        {
            float xSpeed = (this.transform.position.x - hit.gameObject.transform.position.x)*3f + rb.velocity.x;
            if (xSpeed > speed) xSpeed = speed;
            if (xSpeed < -speed) xSpeed = -speed;
            rb.velocity = new Vector2(xSpeed, speed);
        }
        if (hit.gameObject.tag == "plank")
        {
            ScoreController.instance.addScore();
            Destroy(hit.gameObject);
            var number = Random.Range(1, spawnChance);
            if (number == 1)
            {
                Instantiate(healthUp, hit.transform.position, hit.transform.rotation);
            }
            if (number == 2)
            {
                Instantiate(shooter, hit.transform.position, hit.transform.rotation);
            }
        }
    }
}
