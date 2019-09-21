using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBot : MonoBehaviour {
    public int damage = 5;
    public int vision = 10;
    public StateMachine<CannonBot> StateMachine;
    void Start()
    {
        StateMachine = new StateMachine<CannonBot>(this);
        StateMachine.ChangeState(new CannonBotIdle());
    }

    void FixedUpdate()
    {
        StateMachine.Update();
    }

    public void Shoot()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/enemyBullet"), this.transform.position, Quaternion.Euler(0, 0, this.transform.eulerAngles.z));
    }
}
