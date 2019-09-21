using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {

    // Use this for initialization
    private GameObject character;
    private Animator animation;
    private Rigidbody2D rb;
    private float blend; 
    public bool LookRight;
    void Start() {
        blend = 0.2f;
        LookRight = false;
        character = GameObject.Find("character");
        animation = character.GetComponent<Animator>();
        rb = character.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            animation.SetInteger("State", 1);
            StartCoroutine(resetState());
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (LookRight)
            {
                flip();
            }
            animation.SetInteger("State", 2);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!LookRight)
            {
                flip();
            }
            animation.SetInteger("State", 2);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            animation.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animation.SetInteger("State", 3);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            animation.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animation.SetInteger("State", 4);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            animation.SetInteger("State", 0);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            animation.SetInteger("State", 5);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            animation.SetInteger("State", 0);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            if (blend < 1) { blend += 0.02f; }
            animation.SetFloat("Blend", blend);
        }
        if (Input.GetKey(KeyCode.X))
        {
            if (blend >0) { blend -= 0.02f; }
            animation.SetFloat("Blend", blend);
        }
    }
    void flip()
    {
        LookRight = !LookRight;
        if (LookRight)
        {
            character.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            character.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    IEnumerator resetState()
    {
        yield return new WaitForSeconds(0.5f);
        animation.SetInteger("State", 0);
    }
}
