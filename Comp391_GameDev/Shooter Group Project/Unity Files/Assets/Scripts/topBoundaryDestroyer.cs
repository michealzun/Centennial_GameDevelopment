using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topBoundaryDestroyer : MonoBehaviour {
    public GameObject explosion;
    private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "playerBullet(Clone)" || other.gameObject.name == "playerBullet2(Clone)" || other.gameObject.name == "playerBullet3(Clone)")
        {
            Destroy(other.gameObject);

        }
        if (other.gameObject.name == "Player")
        {
            Instantiate(explosion, other.transform.position, other.transform.rotation);

            Destroy(other.gameObject);
        }
    }
}
