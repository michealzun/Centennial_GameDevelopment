using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuriken : MonoBehaviour {

    void Update()
    {
        transform.Rotate(0, 0, 1000 * Time.deltaTime);
    }

    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.gameObject.tag == "Player")
        {
            o.gameObject.GetComponent<playerContoller>().Damage(3);
            o.gameObject.GetComponent<playerContoller>().KnockBack(this.transform.position,10);
        }
        if (o.gameObject.tag == "Wall" || o.gameObject.tag == "DestructableWall")
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
