using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeBotAttack : State<MeleeBot>
{
    Rigidbody2D rb;
    public override void EnterState(MeleeBot _owner)
    {
        _owner.GetComponent<Enemy>().mode = "attack";
        rb = _owner.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, 0, 0);
    }
    public override void UpdateState(MeleeBot _owner)
    {
       if (Vector3.Distance(_owner.player.transform.position, _owner.transform.position) < _owner.vision)
        {
                rb.velocity = (_owner.player.transform.position - _owner.transform.position).normalized * _owner.speed;
        }else{
            _owner.StateMachine.ChangeState(new MeleeBotPatrol());
        }
    }
    public override void ExitState(MeleeBot _owner)
    {
        rb.velocity = new Vector3(0, 0, 0);
    }

}
