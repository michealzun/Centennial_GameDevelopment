using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformUp : MonoBehaviour {

    Rigidbody2D rb;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 10;
    }
}
