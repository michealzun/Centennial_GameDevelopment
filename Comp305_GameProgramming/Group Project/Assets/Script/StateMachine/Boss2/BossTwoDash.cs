using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwoDash : State<Boss2>
{
    ArrayList angles;
    int attackStage;
    public override void EnterState(Boss2 _owner)
    {
        _owner.coolDown = 3;
        _owner.Charge();
        attackStage = 0;
    }
    public override void UpdateState(Boss2 _owner)
    {
        if (_owner.coolDown <= 2 && attackStage == 0)
        {
            PrepNextSlash(_owner);
            attackStage++;
        }
        if (_owner.coolDown <= 1.5 && attackStage==1)
        {
            Slash(_owner);
            PrepNextSlash(_owner);
        }
        if (_owner.coolDown <= 1 && attackStage == 2)
        {
            Slash(_owner);
            PrepNextSlash(_owner);
        }
        if (_owner.coolDown <= 0.5 && attackStage == 3)
        {
            Slash(_owner);
        }

        if (_owner.coolDown == 0)
        {
            _owner.rb.velocity = Vector3.zero;
            if (_owner.hpScript.hp <= _owner.hpScript.maxhp / 2)
            {
                _owner.StateMachine.ChangeState(new BossTwoClone());
            }
            else
            {
                _owner.StateMachine.ChangeState(new BossTwoSneakAttack());
            }

        }
    }

    public override void ExitState(Boss2 _owner)
    {
        _owner.rb.velocity = Vector3.zero;
    }

    void PrepNextSlash(Boss2 _owner)
    {
        angles = new ArrayList();
        foreach (var player in _owner.players)
        {
            angles.Add(Mathf.Atan2(player.transform.position.y - _owner.transform.position.y, player.transform.position.x - _owner.transform.position.x) * Mathf.Rad2Deg);
        }
    }
    void Slash(Boss2 _owner)
    {
        foreach (float angle in angles)
        {
            _owner.Dash(angle);
        }
        attackStage++;
    }


}
