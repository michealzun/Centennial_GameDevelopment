using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwoDoubleThrow : State<Boss2>
{
    int shots;
    ArrayList angles = new ArrayList();
    public override void EnterState(Boss2 _owner)
    {
        _owner.coolDown = 2;
        throwShuriken(_owner);
        _owner.rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized*30,ForceMode2D.Impulse);
        shots = 1;
    }
    public override void UpdateState(Boss2 _owner)
    {
        if (_owner.coolDown <1.25f&& shots == 1)
        {
            throwShuriken(_owner);
            _owner.rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * 30, ForceMode2D.Impulse);
            shots++;
        }
        if (_owner.coolDown < 0.75f && shots == 2)
        {
            throwShuriken(_owner);
            shots++;
        }
        if (_owner.coolDown == 0)
        {

            _owner.StateMachine.ChangeState(new BossTwoTrap());

        }
    }

    public override void ExitState(Boss2 _owner)
    {
        _owner.rb.velocity = Vector3.zero;
    }

    void throwShuriken(Boss2 _owner)
    {
        angles = new ArrayList();
        foreach (var player in _owner.players)
        {
            angles.Add(Mathf.Atan2(player.transform.position.y - _owner.transform.position.y, player.transform.position.x - _owner.transform.position.x) * Mathf.Rad2Deg);
        }
        foreach (float angle in angles)
        {
            _owner.Shuriken(angle);
        }
    }
}
