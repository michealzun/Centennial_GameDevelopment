using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealStation : MonoBehaviour {
    public GameObject particle;
    private void Start()
    {
        particle.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D o)
    {
        if (o.gameObject.tag == "Player")
        {
            particle.SetActive(true);
            o.gameObject.GetComponent<playerContoller>().Damage(-1);
        }
    }
    private void OnTriggerExit2D(Collider2D o)
    {
        if (o.gameObject.tag == "Player")
        {
            particle.SetActive(false);
        }
    }
}
