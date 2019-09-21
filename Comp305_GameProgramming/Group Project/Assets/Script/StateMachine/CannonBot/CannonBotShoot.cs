using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBotShoot : State<CannonBot>
{
    GameObject[] players;
    float cooldown = 100;
    public override void EnterState(CannonBot _owner)
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }
    public override void UpdateState(CannonBot _owner)
    {
        if (cooldown > 0)
        {
            cooldown -= 1;
        }
        bool playerInRange = false;
        foreach (var player in players)
        {
            if (Vector3.Distance(player.transform.position, _owner.transform.position) < _owner.vision)
            {
                playerInRange = true;
                _owner.transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(player.transform.position.y-_owner.transform.position.y, player.transform.position.x - _owner.transform.position.x) * Mathf.Rad2Deg -90);
            }

        }
        if (playerInRange)
        {
            if (cooldown<=0)
            {
                _owner.Shoot();
                cooldown = 100;
            }
        }
        else
        {
            _owner.StateMachine.ChangeState(new CannonBotIdle());
        }
    }
    public override void ExitState(CannonBot _owner)
    {

    }
}
