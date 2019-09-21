using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss1FaceDir : MonoBehaviour {
    Boss1 boss1;
    Animator anim;
    Vector2 dir;
    void Start () {
        boss1 = GetComponent<Boss1>();
        anim = GetComponent<Animator>();
    }

	void Update () {
        dir.x = 0;
        dir.y = 0;
        foreach (var player in boss1.players)
        {
            dir.x += player.transform.position.x - transform.position.x;
            dir.y += player.transform.position.y - transform.position.y;
        }
        anim.SetFloat("Hor", dir.normalized.x);
        anim.SetFloat("Ver", dir.normalized.y);
    }
}
