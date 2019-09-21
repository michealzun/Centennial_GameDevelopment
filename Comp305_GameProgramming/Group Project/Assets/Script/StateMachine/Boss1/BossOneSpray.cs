using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneSpray : State<Boss1>
{
    int shots;
    public override void EnterState(Boss1 _owner)
    {
        _owner.coolDown = 5;
        shots = 0;
    }
    public override void UpdateState(Boss1 _owner)
    {
        if (_owner.coolDown <= 4 && shots < 1)
        {
            shootAtPlayer(_owner);
        }
        else if (_owner.coolDown <= 3 && shots < 2)
        {
            shootAtPlayer(_owner);
        }
        else if (_owner.coolDown <= 2 && shots < 3)
        {
            shootAtPlayer(_owner);
        }
        else if (_owner.coolDown == 0)
        {
            _owner.StateMachine.ChangeState(new BossOneCloseRangeBlast());
        }
    }

    public override void ExitState(Boss1 _owner)
    {
    }
    void shootAtPlayer(Boss1 _owner)
    {
        foreach (var player in _owner.players)
        {
            float angle = Mathf.Atan2(player.transform.position.y - _owner.transform.position.y, player.transform.position.x - _owner.transform.position.x) * Mathf.Rad2Deg;
            for (int i = -20; i <= 20; i+=10)
            {
                _owner.Shoot(angle+i);
            }

        }
        shots++;
    }
}
