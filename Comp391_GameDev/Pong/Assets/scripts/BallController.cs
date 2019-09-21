using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    public GameObject trail;
    public GameObject powerUpSpawn;
    public GameObject explosionBlue;
    public GameObject explosionRed;
    public GameObject explosionWhite;
    public GameObject powerUP;
    public float speed;
    public new GameObject camera;
    public float shakeTimer;
    public int lastHit;
    private Rigidbody2D rb;
    IEnumerator Pause()
    {
        Destroy(GameObject.Find("trail(Clone)"));
        this.transform.position = Vector2.zero;
        rb.velocity = new Vector2(0f, 0f);
        yield return new WaitForSeconds(1.5f);
        var trailVar = Instantiate(trail, this.transform.position, this.transform.rotation);
        trailVar.transform.parent = this.gameObject.transform;
        launchBall();
    }

    void launchBall()
    {
        float xDir = Random.Range(0, 2);
        float yDir = Random.Range(0, 3);
        Vector2 launchDir = new Vector2();

        if (xDir == 0)
        {
            launchDir.x = -2f * speed;
        }
        if (xDir == 1)
        {
            launchDir.x = 2f * speed;
        }
        if (yDir == 0)
        {
            launchDir.y = -speed;
        }
        if (yDir == 1)
        {
            launchDir.y = speed;
        }
        if (yDir == 2)
        {
            launchDir.y = 0f;
        }

        rb.velocity = new Vector2(launchDir.x, launchDir.y);
    }
    void Start () {
        var trailVar = Instantiate(trail, this.transform.position, this.transform.rotation);
        trailVar.transform.parent = this.gameObject.transform;
        shakeTimer = 0;
        rb = this.GetComponent<Rigidbody2D>();
        StartCoroutine(Pause());
        StartCoroutine(spawnPowerUp());
    }
	
	// Update is called once per frame
	void Update () {


        if (this.transform.position.x < -8f)
        {
            ScoreController.instance.PTwoScorePoint();
            StartCoroutine(Pause());
        }
        if (this.transform.position.x > 8f)
        {
            ScoreController.instance.POneScorePoint();
            StartCoroutine(Pause());
        }
        if (shakeTimer > 0)
        {
            camera.transform.position = new Vector3(camera.transform.position.x+ Random.Range(-0.1f, 0.1f), camera.transform.position.y+ Random.Range(-0.1f, 0.1f), camera.transform.position.z);
            shakeTimer -= Time.deltaTime;
        } else { camera.transform.position = new Vector3(0f, 0f, -10f); }
    }
    IEnumerator spawnPowerUp()
    {
        while (true) { 
            yield return new WaitForSeconds(10f);
        powerUpSpawn.transform.position= new Vector2(Random.Range(-6f, 6f), Random.Range(-4f, 4));
        Instantiate(powerUP, powerUpSpawn.transform.position, Quaternion.identity); ;
    }
}
    void OnCollisionEnter2D (Collision2D hit)
    {
        if (hit.gameObject.name == "PadOne")
        {
            float ySpeed = (this.transform.position.y - hit.gameObject.transform.position.y) * speed *3f;
            rb.velocity = new Vector2(2f * speed, ySpeed);
            Instantiate(explosionBlue, this.transform.position , this.transform.rotation);
            shakeTimer += 0.1f;
            lastHit = 1;
        }
        if (hit.gameObject.name == "PadTwo")
        {
            float ySpeed = (this.transform.position.y - hit.gameObject.transform.position.y) * speed * 3f;
            rb.velocity = new Vector2(-2f * speed, ySpeed);
            Instantiate(explosionRed, this.transform.position, this.transform.rotation);
            lastHit = 2;
            shakeTimer += 0.1f;
        }
        if (hit.gameObject.name == "TopBoudary" || hit.gameObject.name == "BotBoudary")
        {
            Instantiate(explosionWhite, this.transform.position, this.transform.rotation);
        }
    }
}
