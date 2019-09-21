using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneAllAngleShot : State<Boss1>
{
    float angle = 0;
    float cd=0.1f;
    public override void EnterState(Boss1 _owner)
    {
        _owner.coolDown = 5;
        _owner.Charge();
    }
    public override void UpdateState(Boss1 _owner)
    {
        cd -= Time.deltaTime;
        if (_owner.coolDown < 3.5f && cd<=0)
        {
            _owner.Shoot(angle);
            angle += 30;
            cd = 0.1f;
        }
        if(_owner.coolDown <= 0)
        {
            if (_owner.hpScript.hp <= _owner.hpScript.maxhp / 2)
            {
                _owner.StateMachine.ChangeState(new BossOneStageTransition());
            }
            else
            {
                _owner.StateMachine.ChangeState(new BossOneTripleShot());
            }
        }

    }
    public override void ExitState(Boss1 _owner)
    {
    }
}
