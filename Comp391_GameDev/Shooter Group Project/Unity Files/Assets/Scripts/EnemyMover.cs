using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMover : MonoBehaviour
{
    private GameObject player;
    public GameObject explosion;
    public float downSpeed;
    public float hp;
    public string moveStyle;
    public GameObject shot;
    public GameObject laser;
    private Rigidbody2D rb;
    private float deltaX;
    private float deltaY;
    private float angle;
    public Text txt;
    void Start()
    {
        player = GameObject.Find("Player");
        downSpeed = -downSpeed;
        rb = this.GetComponent<Rigidbody2D>();
        switch (moveStyle)
        {
            case "stationary":
                StartCoroutine(stationary());
                break;
            case "turr":
                StartCoroutine(turr());
                break;
            case "random":
                StartCoroutine(random());
                break;
            case "leftSwing":
                StartCoroutine(leftSwing());
                break;
            case "rightSwing":
                StartCoroutine(rightSwing());
                break;
            case "leftDiagonal":
                StartCoroutine(leftDiagonal());
                break;
            case "rightDiagonal":
                StartCoroutine(rightDiagonal());
                break;
            case "leftRightStop":
                StartCoroutine(leftRightStop());
                break;
            case "leftRight":
                StartCoroutine(leftRight());
                break;
            case "zigZag":
                StartCoroutine(zigZag());
                break;
            case "boss":
                StartCoroutine(bossMove());
                StartCoroutine(bossAttack());   
                break;
        }
    }

    void FixedUpdate() {
        if (hp <= 0 && moveStyle !="boss") {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        if (hp <= 0 && moveStyle == "boss")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            txt = GameObject.Find("Text").GetComponent<Text>();
            txt.text = "Congratulations";
            Destroy(this.gameObject);
        }
        deltaX = this.transform.position.x - player.transform.position.x;
        deltaY = this.transform.position.y - player.transform.position.y;
        angle = -Mathf.Atan2(deltaX, deltaY) / Mathf.PI * 180f; 
    }
    private IEnumerator stationary()
    {
        rb.velocity = new Vector2(0f, downSpeed);
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(shot, this.transform.position, this.transform.rotation);
        }
    }
    private IEnumerator turr()
    {
        rb.velocity = new Vector2(0f, downSpeed);
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(shot, this.transform.position, Quaternion.Euler(0f,0f,angle));
        }
    }
    private IEnumerator random()
    {
        rb.velocity = new Vector2(Random.Range(-5f, 5f), downSpeed+ Random.Range(-2f, 2f));
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(shot, this.transform.position, this.transform.rotation);
        }
    }

    private IEnumerator leftSwing()
    {
        rb.velocity = new Vector2(0f, downSpeed);
        yield return new WaitForSeconds(2);
        Instantiate(shot);
        rb.velocity = new Vector2(-1f, downSpeed);
        yield return new WaitForSeconds(2);
        Instantiate(shot);
        rb.velocity = new Vector2(0f, downSpeed);
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(shot,this.transform.position,this.transform.rotation);
        }
    }

    private IEnumerator rightSwing()
    {
        rb.velocity = new Vector2(0f, downSpeed);
        yield return new WaitForSeconds(2);
        Instantiate(shot);
        rb.velocity = new Vector2(1f, downSpeed);
        yield return new WaitForSeconds(2);
        Instantiate(shot);
        rb.velocity = new Vector2(0f, downSpeed);
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(shot, this.transform.position, this.transform.rotation);
        }
    }
    private IEnumerator leftDiagonal()
    {
        float horizontal = downSpeed;
        rb.velocity = new Vector2(horizontal, downSpeed);
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(shot, this.transform.position, this.transform.rotation);
        }
    }
    private IEnumerator rightDiagonal()
    {
        float horizontal = -downSpeed;
        rb.velocity = new Vector2(horizontal, downSpeed);
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(shot, this.transform.position, this.transform.rotation);
        }
    }

    private IEnumerator leftRightStop()
    {
        rb.velocity = new Vector2(0, downSpeed);
        yield return new WaitForSeconds(2);
        for (int i = 0; i < 3; i++)
        {
            rb.velocity = new Vector2(-1f, 0);
            yield return new WaitForSeconds(1);
            Instantiate(shot, this.transform.position, this.transform.rotation);
            Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, -30f));
            Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 30f));
            rb.velocity = new Vector2(1f, 0);
            yield return new WaitForSeconds(2);
            Instantiate(shot, this.transform.position, this.transform.rotation);
            Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, -30f));
            Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 30f));
            rb.velocity = new Vector2(-1f, 0);
            yield return new WaitForSeconds(1);
        }
        rb.velocity = new Vector2(0, downSpeed);
    }

    private IEnumerator leftRight()
    {
        while (true)
        {
            rb.velocity = new Vector2(-1f, downSpeed);
            yield return new WaitForSeconds(2);
            Instantiate(shot);
            rb.velocity = new Vector2(1f, 0);
            yield return new WaitForSeconds(2);
            Instantiate(shot, this.transform.position, this.transform.rotation);
        }
    }

    private IEnumerator zigZag()
    {
        while (true)
        {
                rb.velocity = new Vector2(-1f, downSpeed);
                yield return new WaitForSeconds(1);
                Instantiate(shot, this.transform.position, this.transform.rotation);
                rb.velocity = new Vector2(1f, downSpeed);
                yield return new WaitForSeconds(2);
                Instantiate(shot, this.transform.position, this.transform.rotation);
                rb.velocity = new Vector2(-1f, downSpeed);
                yield return new WaitForSeconds(1);

        }
    }
    private IEnumerator bossMove()
    {
        rb.velocity = new Vector2(0, downSpeed);
        yield return new WaitForSeconds(2);
        while (true)
        {
            rb.velocity = new Vector2(-1f, 0);
            yield return new WaitForSeconds(1);
            rb.velocity = new Vector2(1f, 0);
            yield return new WaitForSeconds(2);
            rb.velocity = new Vector2(-1f, 0);
            yield return new WaitForSeconds(1);
        }
    }
    private IEnumerator bossAttack() {
        yield return new WaitForSeconds(2);
        while (hp > 1000)
        {
            for (int i = 0; i < 6; i++)
            {
                int a = 0;
                while (a < 60)
                {
                    Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle + a));
                    yield return new WaitForSeconds(0.05f);
                    a=a+10;
                }
                while (a > -60)
                {
                    Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle + a));
                    yield return new WaitForSeconds(0.05f);
                    a=a-15;
                }
                while (a < 0)
                {
                    Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle + a));
                    yield return new WaitForSeconds(0.05f);
                    a = a + 15;
                }
            }
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 5; i++)
            {
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle - 15f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle + 15f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle - 30f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle + 30f));
                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 0));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 15f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 30f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 45f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 60f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 75f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 90f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 105f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 120f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 135f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 150f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 165f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 180f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 195f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 210f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 225f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 240f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 255f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 270f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 285f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 300f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 315f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 330f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 345f));

                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(2f);
        }
        while (hp <= 1000)
        {
            for (int i = 0; i < 4; i++)
            {
                int a = 0;
                while(a < 60) { 
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle+a));
                 Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle - a));
                yield return new WaitForSeconds(0.05f);
                a=a+12;
                }
                while (a > -60)
                {
                    Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle + a));
                    Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle - a));
                    yield return new WaitForSeconds(0.05f);
                    a = a - 12;
                }
                while (a < 0)
                {
                    Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle + a));
                    Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle - a));
                    yield return new WaitForSeconds(0.05f);
                    a = a + 12;
                }
            }
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 6; i++)
            {
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle-10f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle+10f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle-20f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle+20f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle - 30f));
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, angle + 30f));
                yield return new WaitForSeconds(0.4f);
            }
            yield return new WaitForSeconds(2f);
            for (int i = 0; i < 1000; i++)
            {
                Instantiate(shot, this.transform.position, Quaternion.Euler(0f, 0f, 15*i));
                yield return new WaitForSeconds(0.001f);    
            }
            yield return new WaitForSeconds(2f);
            Instantiate(laser, new Vector3(this.transform.position.x - 2, -4f, 0), Quaternion.Euler(0f, 0f, 180f));
            Instantiate(laser, new Vector3(this.transform.position.x+2, -4f,0), Quaternion.Euler(0f, 0f, 180f));
            yield return new WaitForSeconds(2f);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "player")
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "playerBullet(Clone)")
        {
            hp--;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "playerBullet2(Clone)")
        {
            hp-=1.5f;
            Destroy(other.gameObject);
        }
        if (other.gameObject.name == "playerBullet3(Clone)")
        {
            hp-=2;
            Destroy(other.gameObject);
        }
    }
}