    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretBullet : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D o)
    {
        if(o.gameObject.tag == "Player")
        {
            o.gameObject.GetComponent<playerContoller>().Damage(15);
            Destroy(this.gameObject);
        }
        if (o.gameObject.tag == "Wall" || o.gameObject.tag == "DestructableWall")
        {
            Destroy(this.gameObject);
        }
    }
}
