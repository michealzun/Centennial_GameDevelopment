using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBotIdle : State<CannonBot>
{
    GameObject[] players;
    public override void EnterState(CannonBot _owner)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    public override void UpdateState(CannonBot _owner)
    {
        bool playerInRange = false;
        foreach (var player in players)
        {
            if (Vector3.Distance(player.transform.position, _owner.transform.position) < _owner.vision)
            {
                playerInRange = true;
            }

        }
        if(playerInRange)
        {
            _owner.StateMachine.ChangeState(new CannonBotShoot());
        }
    }
    public override void ExitState(CannonBot _owner)
    {

    }

}
