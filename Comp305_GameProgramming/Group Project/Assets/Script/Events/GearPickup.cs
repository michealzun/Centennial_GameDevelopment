using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPickup : MonoBehaviour {
    public int gearNum;
    public bool darken = false;
    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.tag == "Player")
        {
            GameObject.Find("Progress").GetComponent<Progress>().gearUnlock[gearNum] = true;
            if (darken)
            {
                GetComponent<SpriteRenderer>().color = Color.gray;
            }
            else
            {
                Destroy(this.gameObject);
            }

        }
    }
}
