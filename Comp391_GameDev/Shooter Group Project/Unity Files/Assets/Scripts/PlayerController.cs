using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{

    // Public Variables
    public int hp = 3;
    public GameObject explosion;
    public float speed;
    public Boundary boundary;
    public Transform laserSpawn;
    public GameObject laser;
    public GameObject laser2;
    public GameObject laser3;
    public float fireDelta = 0.5f;


    // Private Variables
    Rigidbody2D rBody;
    private float nextFire = 0.1f;
    private float myTime = 0.5f;
    private int powerUp = 1;

    // Use this for initialization
    void Start()
    {
        rBody = this.GetComponent<Rigidbody2D>();   // Creating a reference to THIS rigidbody2D\
    }

    // Used for Physics
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rBody.velocity = movement * speed;

        rBody.position = new Vector2(                                           // Creating a new Vector2 object
            Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax),        // Restricting X to xMin and xMax
            Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax));       // Restricting Y to yMin and yMax
    }

    // Update is called once per frame
    void Update()
    {
        myTime = myTime + Time.deltaTime;
        // myTime += Time.deltaTime;

        if ((Input.GetButton("Fire1") || Input.GetKey(KeyCode.Z)) && myTime > nextFire)
        {
            if (powerUp == 1)
            {
                Instantiate(laser, laserSpawn.position, laserSpawn.rotation);
            }
            else if (powerUp == 2)
            {
                Instantiate(laser2, laserSpawn.position, laserSpawn.rotation);
            }
            else if (powerUp == 3)
            {
                Instantiate(laser3, laserSpawn.position, laserSpawn.rotation);
            }
            myTime = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.X)){
            hp = hp + 100;
        }
            if (hp < 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "enemyBullet(Clone)" || col.gameObject.name == "bossLaser(Clone)")
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(col.gameObject);
            hp--;
        }
        if (col.gameObject.name == "powerUp(Clone)")
        {
            if (powerUp < 3)
            {
                powerUp++;
            }
            Destroy(col.gameObject);
        }
    }

}
