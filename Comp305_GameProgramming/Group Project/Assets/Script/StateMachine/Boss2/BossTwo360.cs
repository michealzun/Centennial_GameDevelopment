using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwo360 : State<Boss2>
{
    int attackStage;
    public override void EnterState(Boss2 _owner)
    {
        _owner.coolDown = 3;
        _owner.Charge();
        attackStage = 0;
    }
    public override void UpdateState(Boss2 _owner)
    {
        if (_owner.coolDown >= 1.5f)
        {
            foreach (var player in _owner.players)
            {
                Vector3 angle = new Vector3(_owner.transform.position.x-player.transform.position.x, _owner.transform.position.y - player.transform.position.y,0).normalized;
                player.GetComponent<Rigidbody2D>().AddForce(angle*1f,ForceMode2D.Impulse);
            }
        }
        if (attackStage == 0 &&_owner.coolDown<1f)
        {
            _owner.CircleSlash();
            attackStage++;
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
                _owner.StateMachine.ChangeState(new BossTwoDash());
            }

        }
    }

    public override void ExitState(Boss2 _owner)
    {
        _owner.rb.velocity = Vector3.zero;
    }
}
