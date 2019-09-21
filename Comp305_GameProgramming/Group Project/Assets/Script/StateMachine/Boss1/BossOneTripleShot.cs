using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneTripleShot : State<Boss1>
{
    Vector3 jumpDir = Vector3.zero;
    int shots;
    public override void EnterState(Boss1 _owner)
    {
        _owner.coolDown = 5;
        foreach (var player in _owner.players)
        {
            jumpDir += new Vector3(_owner.transform.position.x - player.transform.position.x, _owner.transform.position.y - player.transform.position.y,0).normalized;
        }
        _owner.rb.AddForce(jumpDir*50,ForceMode2D.Impulse);
        shots = 0;
    }
    public override void UpdateState(Boss1 _owner)
    {
        if (_owner.coolDown<=4 && shots<1)
        {
            shootAtPlayer(_owner);
        }
        else if (_owner.coolDown <= 3.5 && shots < 2)
        {
            shootAtPlayer(_owner);
        }
        else if(_owner.coolDown <= 3 && shots <3)
        {
            shootAtPlayer(_owner);
        }
        else if (_owner.coolDown <= 2.5 && shots < 4)
        {
            shootAtPlayer(_owner);
        }
        else if (_owner.coolDown <= 2 && shots < 5)
        {
            shootAtPlayer(_owner);
        }
        else if (_owner.coolDown == 0)
        {
            if (_owner.hpScript.hp <= _owner.hpScript.maxhp / 2)
            {
                _owner.StateMachine.ChangeState(new BossOneStageTransition());
            }
            else
            {
                _owner.StateMachine.ChangeState(new BossOneLaser());
            }

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
            _owner.Shoot(angle);
        }
        shots++;
    }
}
