using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneCloseRangeBlast : State<Boss1>
{
    bool notShot = true;
    public override void EnterState(Boss1 _owner)
    {
        _owner.coolDown = 5;
        _owner.Charge();
    }
    public override void UpdateState(Boss1 _owner)
    {
        if (_owner.coolDown <= 3.5f && notShot)
        {
            _owner.WildShot();
            notShot = false;
        }
        if (_owner.coolDown == 0)
        {
            _owner.StateMachine.ChangeState(new BossOneLaserSpin());
        }
    }

    public override void ExitState(Boss1 _owner)
    {
    }

}
