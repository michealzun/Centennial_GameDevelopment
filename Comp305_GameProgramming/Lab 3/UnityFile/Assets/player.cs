using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class player {

    float moveSpeed = 4f;
    float jumpPower = 5f;
    bool Air;
    GameObject owner;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;
    LayerMask layer;

    public player(GameObject _owner,LayerMask _layer)
    {
        owner = _owner;
        rb = owner.GetComponent<Rigidbody2D>();
        sr = owner.GetComponent<SpriteRenderer>();
        anim = owner.GetComponent<Animator>();
        layer = _layer;
    }

    public void PerUpdate(float x, float y)
    {
        Air = !Physics2D.OverlapCircle(owner.transform.position, 1f,layer);
        anim.SetBool("Air", Air);

        MoveHor(x);
        MoveVer(y);
        anim.SetFloat("Hor", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("Ver", rb.velocity.y);
    }
    public void MoveHor(float x)
    {
        rb.velocity = new Vector2(x * moveSpeed, rb.velocity.y);
        if (x > 0)
        {
            sr.flipX = true;
        }
        else if (x < 0)
        {
            sr.flipX = false;
        }
    }
    public void MoveVer(float y)
    {
        if (y > 0 && !Air)
        {
            rb.AddForce(new Vector2(0, jumpPower),ForceMode2D.Impulse);
        }

    }
}
