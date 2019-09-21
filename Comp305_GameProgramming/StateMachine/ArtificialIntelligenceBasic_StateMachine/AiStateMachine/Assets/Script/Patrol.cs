using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State<Enemy>
{
    private static Patrol instance;

    private Patrol()
    { 
        if(instance != null)
        {
            return;
        }
        instance = this;
    }

    public static Patrol Instance
    {
        get
        {
            if(instance == null)
            {
                new Patrol();
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
            _owner.StateMachine.ChangeState(Follow.Instance);
        }
    }
    public override void ExitState(Enemy _owner)
    {
    }
}
