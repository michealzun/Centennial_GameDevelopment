using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneLaser : State<Boss1>
{
    ArrayList angles = new ArrayList();
    bool notShot=true;
    public override void EnterState(Boss1 _owner)
    {
        _owner.coolDown = 5;
        _owner.Charge();
    }
    public override void UpdateState(Boss1 _owner)
    {
        if (_owner.coolDown <= 3.5f && notShot)
        {
            foreach (var player in _owner.players)
            {
               angles.Add(Mathf.Atan2(player.transform.position.y - _owner.transform.position.y, player.transform.position.x - _owner.transform.position.x) * Mathf.Rad2Deg - 90);
            }
            foreach (float angle in angles)
            {
                _owner.laser(angle);
            }
            notShot = false;
        }
        if (_owner.coolDown == 0)
        {
            if (_owner.hpScript.hp <= _owner.hpScript.maxhp / 2)
            {
                _owner.StateMachine.ChangeState(new BossOneStageTransition());
            }
            else
            {
                _owner.StateMachine.ChangeState(new BossOneJump());
            }

        }
    }

    public override void ExitState(Boss1 _owner)
    {
    }

}
