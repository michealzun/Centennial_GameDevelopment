using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOneIdle : State<Boss1>
{
    public override void EnterState(Boss1 _owner)
    { 
    }
    public override void UpdateState(Boss1 _owner)
    {
        foreach (var player in _owner.players)
        {
            if (GameObject.Find("Controller").GetComponent<gameController>().bossStage == 1)
            {
                _owner.StateMachine.ChangeState(new BossOneJump());
            }
        }
    }
    public override void ExitState(Boss1 _owner)
    {
        _owner.hpScript.HpLock = false;
    }
}
