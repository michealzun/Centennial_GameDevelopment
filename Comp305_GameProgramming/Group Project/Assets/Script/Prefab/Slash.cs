using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour {
    Enemy enemy;
    
    public void OnTriggerEnter2D(Collider2D o)
    {
        if (o.GetComponent<Enemy>()!=null)
        {
            enemy=o.GetComponent<Enemy>();
            enemy.Damage(10);
        }
    }
    public void SelfDestroy()
    {
        Destroy(this.gameObject);
    }
}
