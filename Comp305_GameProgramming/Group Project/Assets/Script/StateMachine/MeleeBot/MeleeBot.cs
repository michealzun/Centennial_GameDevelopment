using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeleeBot : MonoBehaviour {
    public int damage = 5;
    public int vision = 7;
    public StateMachine<MeleeBot> StateMachine;
    void Start()
    {
        StateMachine = new StateMachine<MeleeBot>(this);
        StateMachine.ChangeState(new MeleeBotIdle());
    }

    void Update()
    {
        StateMachine.Update();
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<playerContoller>().Damage(damage);
            coll.gameObject.GetComponent<playerContoller>().KnockBack(this.transform.position, 10);
        }
    }
}
