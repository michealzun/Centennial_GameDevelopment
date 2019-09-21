using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneJump : State<Boss1>
{
    Vector3 jumpLoc;
    bool notShot;
    public override void EnterState(Boss1 _owner)
    {
        _owner.coolDown = 3;
        jumpLoc = new Vector3(Random.Range(_owner.leftBound, _owner.rightBound), Random.Range(_owner.bottomBound, _owner.topBound), 0);
        notShot = true;
    }
    public override void UpdateState(Boss1 _owner)
    {
        if (Vector3.Distance(_owner.transform.position, jumpLoc) > 0.5f)
        {
            _owner.rb.velocity = new Vector3(jumpLoc.x - _owner.transform.position.x, jumpLoc.y - _owner.transform.position.y, 0).normalized*50;
        }
        else
        {
            _owner.rb.velocity = Vector3.zero;
        }
        if(notShot && _owner.coolDown<=2.5f)
        {
            int angle= 0;
            while (angle < 360)
            {
                _owner.Shoot(angle);
                angle += 45;
            }
            notShot = false;
        }
        if (_owner.coolDown == 0)
        {
            if (_owner.hpScript.hp<= _owner.hpScript.maxhp / 2)
            {
                _owner.StateMachine.ChangeState(new BossOneStageTransition());
            }
            else
            {
                _owner.StateMachine.ChangeState(new BossOneAllAngleShot());
            }

        }
    }
    public override void ExitState(Boss1 _owner)
    {
        _owner.rb.velocity = Vector3.zero;
    }
}
