using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeBotPatrol : State<MeleeBot>
{

    Rigidbody2D rb;
    public override void EnterState(MeleeBot _owner)
    {
        _owner.GetComponent<Enemy>().mode = "patrol";
        rb = _owner.GetComponent<Rigidbody2D>();
    }
    public override void UpdateState(MeleeBot _owner)
    {
        if (_owner.patrolNodes.Length > 1 && Vector2.Distance(_owner.transform.position, _owner.patrolNodes[_owner.goalNode].transform.position) < 1)
        {
            if (_owner.goalNode < _owner.patrolNodes.Length - 1)
                _owner.goalNode++;
            else
                _owner.goalNode = 0;
            
        }
        if (_owner.patrolNodes.Length > 0)
            rb.velocity = (_owner.patrolNodes[_owner.goalNode].transform.position - _owner.transform.position).normalized * _owner.speed;

        if (Vector3.Distance(_owner.player.transform.position, _owner.transform.position) < _owner.vision)
        {
            rb.velocity = Vector2.zero;
            _owner.StateMachine.ChangeState(new MeleeBotAttack());
        }
    }
    public override void ExitState(MeleeBot _owner)
    {

    }
}
