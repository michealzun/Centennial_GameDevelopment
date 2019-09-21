using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwoSneakAttack : State<Boss2>
{
    SpriteRenderer sprite;
    Color color;
    ArrayList angles = new ArrayList();
    int AttackStage;
    public override void EnterState(Boss2 _owner)
    {
        _owner.coolDown = 4;
        sprite=_owner.GetComponent<SpriteRenderer>();
        color = sprite.material.color;
        AttackStage = 0;
    }
    public override void UpdateState(Boss2 _owner)
    {
        if (_owner.coolDown >= 3)
        {
            float alpha = Mathf.Lerp(1, 0, 1-(_owner.coolDown-3));
            sprite.color = new Color(color.r, color.g, color.b, alpha);
            _owner.hpScript.HpLock = true;
        }
        if (_owner.coolDown <2 && AttackStage==0)
        {
            foreach (var player in _owner.players)
            {
                _owner.transform.position = player.transform.position;
            }
            AttackStage = 1;
        }
        if (_owner.coolDown < 1.5 && AttackStage==1)
        {
            foreach (var player in _owner.players)
            {
                angles.Add(Mathf.Atan2(player.transform.position.y - _owner.transform.position.y, player.transform.position.x - _owner.transform.position.x) * Mathf.Rad2Deg);
            }
            AttackStage = 2;
        }
        if (_owner.coolDown < 1 && AttackStage == 2)
        {
            sprite.color = new Color(color.r, color.g, color.b, 1);
            _owner.hpScript.HpLock = false;
            foreach (float angle in angles)
            {
                _owner.ConeSlash(angle);
            }
            AttackStage = 3;
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
                _owner.StateMachine.ChangeState(new BossTwo360());
            }

        }
    }

    public override void ExitState(Boss2 _owner)
    {
        _owner.hpScript.HpLock = false;
    }
}
