using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour {

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "manager")
        {
            Destroy(this.gameObject);
        }
    }
}
