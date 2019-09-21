using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using FireCloud.Mission;
using FireCloud.Entity;

public class Sentry : MonoBehaviour
{
    public float Damage;
    public float RadarRadius;
    public float RadarInterval;
    public GameObject BulletPrefab;
    public float BulletSpeed;
    public float FireRate;
    public float RotationSpeed;

    public Transform BulletSpawn;

    [HideInInspector]
    public bool EnableFiring;
    [HideInInspector]
    public bool EnableRadar;

    private Vector3 _cloestEnemy;
    private float _degree;

    void Start()
    {
        EnableFiring = true;
        EnableRadar = true;
        StartCoroutine(CheckCloestEnemy());
        StartCoroutine(Fire());
    }

    void FixedUpdate()
    {
        if (EnableRadar)
        {
            if (EnemyInRange())
            {
                float radians = Mathf.Atan2(_cloestEnemy.y - this.transform.position.y, _cloestEnemy.x - this.transform.position.x);
                _degree = radians * Mathf.Rad2Deg;
                transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, _degree), RotationSpeed * Time.deltaTime);
            }
        }
    }

    bool EnemyInRange()
    {
        RaycastHit2D[] hits = Physics2D.LinecastAll(transform.position, transform.position + (RadarRadius * (_cloestEnemy - transform.position).normalized));
        RaycastHit2D hit = hits.Where(x => x.collider.GetComponent<EntityAttribute>() != null && !x.collider.CompareTag("Player")).OrderBy(x => Vector3.Distance(x.transform.position, transform.position)).FirstOrDefault();
        return hit;
    }

    IEnumerator Fire()
    {
        while (EnableFiring)
        {
            yield return new WaitForSeconds(FireRate);
            if (EnemyInRange())
            {
                GameObject bullet = Instantiate(BulletPrefab, BulletSpawn.position, Quaternion.Euler(0, 0, _degree - 90));
                DamageSource source = bullet.GetComponent<DamageSource>();
                source.SetDamage((int)Damage);
                source.SetSpeed(BulletSpeed);
                source.TravelDistance = RadarRadius;
            }
        }
    }

    IEnumerator CheckCloestEnemy()
    {
        while (EnableRadar)
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, RadarRadius);
            if (hits.Length > 0)
            {
                Collider2D hit = hits.Where(x => x.GetComponent<EntityAttribute>() != null && !x.CompareTag("Player")).OrderBy(x => Vector3.Distance(x.transform.position, transform.position)).FirstOrDefault();
                if (hit != null)
                {
                    _cloestEnemy = hit.transform.position;
                }
            }
            yield return new WaitForSeconds(RadarInterval);
        }
    }
}