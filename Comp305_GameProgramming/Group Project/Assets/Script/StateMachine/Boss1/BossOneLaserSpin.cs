using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneLaserSpin : State<Boss1>
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
            float angle = _owner.spinner.transform.rotation.eulerAngles.z;
            for (int i = 0; i < 6; i++)
            {
                GameObject newLaser= _owner.laser(angle);
                newLaser.transform.parent = _owner.spinner.transform;
                angle += 60;
            }
            notShot = false;
        }
        if (_owner.coolDown == 0)
        {
            _owner.StateMachine.ChangeState(new BossOneSpray());
        }
    }

    public override void ExitState(Boss1 _owner)
    {
    }

}
