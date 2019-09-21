using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwoTrapPrefab : MonoBehaviour {
    GameObject target;
    bool hit = false;
    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.gameObject.tag == "Player")
        {
            hit = true;
            target = o.gameObject;
            target.GetComponent<playerContoller>().moveLock = true;
            StartCoroutine(SelfDestruct());
        }
        else if (hit==true)
        {
            if (target)
            {
                target.GetComponent<playerContoller>().moveLock = false;
            }
            Destroy(this.gameObject);
        }
    }

    IEnumerator SelfDestruct()
    {  
        yield return new WaitForSeconds(3.5f);
        target.GetComponent<playerContoller>().moveLock = false;
        Destroy(this.gameObject);
    }
}
