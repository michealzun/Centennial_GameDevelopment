using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwoClone : State<Boss2>
{
    SpriteRenderer sprite;
    Color color;
    ArrayList angles = new ArrayList();
    int AttackStage;
    Vector3 targetLoc;
    public override void EnterState(Boss2 _owner)
    {
        _owner.coolDown = 4;
        sprite = _owner.GetComponent<SpriteRenderer>();
        color = sprite.material.color;
        AttackStage = 0;
    }
    public override void UpdateState(Boss2 _owner)
    {
        if (_owner.coolDown >= 3)
        {
            float alpha = Mathf.Lerp(1, 0, 1 - (_owner.coolDown - 3));
            sprite.color = new Color(color.r, color.g, color.b, alpha);
            _owner.hpScript.HpLock = true;
        }
        if (_owner.coolDown < 3 && AttackStage == 0)
        {
            foreach (var player in _owner.players)
            {
                _owner.Clone(player.transform.position);
                targetLoc = player.transform.position;
            }
            AttackStage = 1;
        }
        if (_owner.coolDown < 0.5 && AttackStage == 1)
        {
            sprite.color = new Color(color.r, color.g, color.b, 1);
            _owner.hpScript.HpLock = false;
            _owner.transform.position = targetLoc;
            AttackStage = 2;
        }

        if (_owner.coolDown == 0)
        {

             _owner.StateMachine.ChangeState(new BossTwoDoubleThrow());
 
        }
    }

    public override void ExitState(Boss2 _owner)
    {
        _owner.rb.velocity = Vector3.zero;
    }
}
