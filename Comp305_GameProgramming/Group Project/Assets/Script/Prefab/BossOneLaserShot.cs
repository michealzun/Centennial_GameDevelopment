using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneLaserShot : MonoBehaviour {

    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.gameObject.tag == "Player")
        {
            o.gameObject.GetComponent<playerContoller>().Damage(2f);
        }
    }
}
