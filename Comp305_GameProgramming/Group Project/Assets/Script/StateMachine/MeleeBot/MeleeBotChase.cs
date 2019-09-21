using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeBotChase : State<MeleeBot>
{
    Animator anim;
    Rigidbody2D rb;
    GameObject[] players;
    public override void EnterState(MeleeBot _owner)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        anim = _owner.GetComponent<Animator>();
        rb = _owner.GetComponent<Rigidbody2D>();
    }
    public override void UpdateState(MeleeBot _owner)
    {
        bool playerInRange = false;
        foreach (var player in players)
        {
            if (Vector3.Distance(player.transform.position, _owner.transform.position) < _owner.vision)
            {
                Vector3 dir = player.transform.position - _owner.transform.position;
                rb.velocity = dir.normalized;
                playerInRange = true;
            }
            
        }
        anim.SetFloat("Hor", rb.velocity.x);
        anim.SetFloat("Ver", rb.velocity.y);
        if (playerInRange == false)
        {
            _owner.StateMachine.ChangeState(new MeleeBotIdle());
        }
    }
    public override void ExitState(MeleeBot _owner)
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

}
