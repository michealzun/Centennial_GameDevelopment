using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneStageTransition : State<Boss1>
{
    Vector3 jumpLoc;
    public override void EnterState(Boss1 _owner)
    {
        _owner.coolDown = 1.5f;
        GameObject.Find("Controller").GetComponent<gameController>().bossStage = 2;
        _owner.hpScript.HpLock = true;
        jumpLoc = new Vector3((_owner.leftBound+_owner.rightBound)/2, (_owner.topBound + _owner.bottomBound) / 2,0);
    }
    public override void UpdateState(Boss1 _owner)
    {
        if (Vector3.Distance(_owner.transform.position, jumpLoc) > 0.5f)
        {
            _owner.rb.velocity = new Vector3(jumpLoc.x - _owner.transform.position.x, jumpLoc.y - _owner.transform.position.y, 0).normalized * 50;
        }
        else
        {
            _owner.rb.velocity = Vector3.zero;
        }
        if (_owner.coolDown == 0)
        {
            _owner.StateMachine.ChangeState(new BossOneCloseRangeBlast());
        }
    }

    public override void ExitState(Boss1 _owner)
    {
        _owner.hpScript.HpLock = false;
    }

}
