using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using FireCloud.Mission;

public class DamageSource : MonoBehaviour
{
    public float BaseDamage { get; private set; } = 1;
    public float DamageMultiplier { get; private set; } = 1;
    public float TravelDistance;

    Rigidbody2D rb;

    private Vector3 _startPos;

    void Start()
    {
        _startPos = this.transform.position;
        rb = this.GetComponent<Rigidbody2D>();
    }

    public void SetDamage(int baseDamage, int damageMultiplier = 1)
    {
        this.BaseDamage = baseDamage;
        this.DamageMultiplier = damageMultiplier;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, _startPos) >= this.TravelDistance)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetSpeed(float speedMultiplier)
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 30 * speedMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {
            MissionTarget target = other.GetComponent<MissionTarget>();
            if (target != null)
            {
                target.OnDamage(this.BaseDamage * this.DamageMultiplier);
                Destroy(this.gameObject);
            }
        }

    }
}