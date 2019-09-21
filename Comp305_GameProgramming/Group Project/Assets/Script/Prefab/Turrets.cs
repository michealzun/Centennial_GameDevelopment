using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour {
    public float fireRate=1f;
    public float fireAngle = 90;
    void Start()
    {
        StartCoroutine(BulletCycle());
    }

    IEnumerator BulletCycle()
    {
        while (true)
        {
            Instantiate(Resources.Load<GameObject>("Prefab/turretBullet"), this.transform.position, Quaternion.Euler(0, 0, this.transform.rotation.z+ fireAngle));
            yield return new WaitForSeconds(fireRate);
        }
    }
}
