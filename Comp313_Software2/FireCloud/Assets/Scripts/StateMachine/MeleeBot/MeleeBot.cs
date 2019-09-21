using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireCloud.Entity;

public class MeleeBot : MonoBehaviour {
    public int damage = 5;
    public int vision = 7;
    public int speed = 5;
    [HideInInspector]
    public StateMachine<MeleeBot> StateMachine;
    public GameObject[] patrolNodes;
    [HideInInspector]
    public int goalNode = 0;
    [HideInInspector]
    public GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StateMachine = new StateMachine<MeleeBot>(this);
        StateMachine.ChangeState(new MeleeBotPatrol());
    }

    void FixedUpdate()
    {
        StateMachine.Update();
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll.gameObject.GetComponent<EntityAttribute>().Damage(damage);
            coll.gameObject.GetComponent<EntityAttribute>().KnockBack(this.transform.position, 10);
        }
    }
}
