using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss2FaceDir : MonoBehaviour {
    Boss2 boss2;
    Animator anim;
    Vector2 dir;
    void Start()
    {
        boss2 = GetComponent<Boss2>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        dir.x = 0;
        dir.y = 0;
        foreach (var player in boss2.players)
        {
            dir.x += player.transform.position.x - transform.position.x;
            dir.y += player.transform.position.y - transform.position.y;
        }
        anim.SetFloat("Hor", dir.normalized.x);
        anim.SetFloat("Ver", dir.normalized.y);
    }
}
