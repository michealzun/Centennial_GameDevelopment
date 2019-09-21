using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : State<Enemy>
{
    private static Follow instance;

    private Follow()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public static Follow Instance
    {
        get
        {
            if (instance == null)
            {
                new Follow();
            }
            return instance;
        }
    }

    public override void EnterState(Enemy _owner)
    {
    }
    public override void UpdateState(Enemy _owner)
    {
        if (Vector2.Distance(_owner.transform.position, _owner.player.transform.position) < 3)
        {
            Vector3 followVec = _owner.player.transform.position - _owner.transform.position;
            _owner.GetComponent<Rigidbody2D>().velocity = followVec.normalized;
        }
        else
        {
            _owner.StateMachine.ChangeState(Patrol.Instance);
        }

        if (Vector2.Distance(_owner.player.transform.position, _owner.transform.position) < 0.1f)
        {
            _owner.StateMachine.ChangeState(Return.Instance);
        }
    }
    public override void ExitState(Enemy _owner)
    {
        _owner.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
