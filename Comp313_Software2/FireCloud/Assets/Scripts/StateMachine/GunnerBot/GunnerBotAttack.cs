using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GunnerBotAttack : State<GunnerBot>
{
    Rigidbody2D rb;
    public override void EnterState(GunnerBot _owner)
    {
        _owner.GetComponent<Enemy>().mode = "attack";
        rb = _owner.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
    }
    public override void UpdateState(GunnerBot _owner)
    {
        
        
        if (Vector3.Distance(_owner.player.transform.position, _owner.transform.position) < _owner.vision)
        {
             _owner.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(_owner.player.transform.position.y - _owner.transform.position.y, _owner.player.transform.position.x - _owner.transform.position.x) * Mathf.Rad2Deg - 90);

            if (_owner.cd > 0)
            {
                _owner.cd -= 1;
            }
            else
            {
                _owner.Shoot();
                _owner.cd = 100-_owner.attackSpeed;
            }

        }
        else
        {
            _owner.StateMachine.ChangeState(new GunnerBotPatrol());
        }
    }
    public override void ExitState(GunnerBot _owner)
    {
        _owner.cd = 0;
    }

}
