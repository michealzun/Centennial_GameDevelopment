using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTwoIdle : State<Boss2> {

    public override void EnterState(Boss2 _owner)
    {
    }
    public override void UpdateState(Boss2 _owner)
    {
        foreach (var player in _owner.players)
        {
            if (GameObject.Find("Controller").GetComponent<gameController>().bossStage == 1)
            {
                _owner.StateMachine.ChangeState(new BossTwoDash());
            }
        }
    }
    public override void ExitState(Boss2 _owner)
    {
        _owner.hpScript.HpLock = false;
    }
}
