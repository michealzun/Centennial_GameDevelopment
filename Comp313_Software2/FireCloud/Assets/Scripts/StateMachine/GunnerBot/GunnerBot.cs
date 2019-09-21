using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireCloud.Entity;

public class GunnerBot : MonoBehaviour
{
    public int damage = 5;
    public int attackSpeed = 1;
    public int vision = 10;
    public int speed = 5;

    [HideInInspector]
    public StateMachine<GunnerBot> StateMachine;
    public GameObject[] patrolNodes;
    [HideInInspector]
    public int goalNode=0;
    [HideInInspector]
    public GameObject player;
    [HideInInspector]
    public float cd=0;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StateMachine = new StateMachine<GunnerBot>(this);
        StateMachine.ChangeState(new GunnerBotPatrol());
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
    public void Shoot()
    {
        Instantiate(Resources.Load<GameObject>("Prefabs/enemyBullet"), this.transform.position, Quaternion.Euler(0, 0, this.transform.eulerAngles.z));
    }
}
