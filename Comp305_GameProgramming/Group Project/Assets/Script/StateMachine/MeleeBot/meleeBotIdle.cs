using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeBotIdle : State<MeleeBot>
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
        foreach (var player in players)
        {
            anim.SetFloat("Hor", rb.velocity.x);
            anim.SetFloat("Ver", rb.velocity.y);
            if (Vector3.Distance(player.transform.position, _owner.transform.position) < _owner.vision)
            {
                _owner.StateMachine.ChangeState(new MeleeBotChase());       
            }
        }
    }
    public override void ExitState(MeleeBot _owner)
    {

    }
}
