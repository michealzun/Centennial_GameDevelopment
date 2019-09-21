using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwoTrap : State<Boss2>
{
    int shots=0;
    public override void EnterState(Boss2 _owner)
    {
        _owner.coolDown = 2.5f;
        _owner.Charge();
    }
    public override void UpdateState(Boss2 _owner)
    {
        if (_owner.coolDown <= 0.5f && shots==0)
        {
            _owner.Trap();
            _owner.rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 20, ForceMode2D.Impulse);
            shots++;
        }

        if (_owner.coolDown == 0)
        {

            _owner.StateMachine.ChangeState(new BossTwoClone());

        }
    }

    public override void ExitState(Boss2 _owner)
    {
        _owner.rb.velocity = Vector3.zero;
    }
}
