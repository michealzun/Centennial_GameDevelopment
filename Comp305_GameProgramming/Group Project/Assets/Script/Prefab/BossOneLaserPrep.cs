using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneLaserPrep : MonoBehaviour {

    public float timer = 3f;
    public GameObject laser=null;
    void Start()
    {
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 2 && laser==null)
        {
            laser=Instantiate(Resources.Load<GameObject>("Prefab/laserShot"), this.transform.position, Quaternion.Euler(0, 0, this.transform.eulerAngles.z));
            laser.transform.parent = this.transform;
        }
        if (timer <= 0)
        {
            Destroy(laser);
            Destroy(this.gameObject);
        }
    }
}
