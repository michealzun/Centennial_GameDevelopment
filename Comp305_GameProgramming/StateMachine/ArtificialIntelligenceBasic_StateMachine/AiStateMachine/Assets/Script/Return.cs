using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : State<Enemy>
{
    private static Return instance;
    private Return()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    public static Return Instance
    {
        get
        {
            if (instance == null)
            {
                new Return();
            }
            return instance;
        }
    }

    public override void EnterState(Enemy _owner)
    {
        
    }
    public override void UpdateState(Enemy _owner)
    {
        Vector3 followVec = _owner.StartPos - _owner.transform.position;
        _owner.GetComponent<Rigidbody2D>().velocity = followVec.normalized;

        if(Vector2.Distance(_owner.StartPos, _owner.transform.position) < 0.1f)
        {
            _owner.StateMachine.ChangeState(Patrol.Instance);
        }
    }
    public override void ExitState(Enemy _owner)
    {
        _owner.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
