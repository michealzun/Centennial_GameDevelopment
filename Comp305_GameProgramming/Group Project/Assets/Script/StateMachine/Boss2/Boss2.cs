using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour {
    public float coolDown = 0;
    public StateMachine<Boss2> StateMachine;
    public GameObject[] players;
    public Enemy hpScript;
    public Rigidbody2D rb;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        hpScript = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        StateMachine = new StateMachine<Boss2>(this);
        StateMachine.ChangeState(new BossTwoIdle());
    }

    void Update()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        else
        {
            coolDown = 0;
        }
        StateMachine.Update();
    }

    public void Dash(float angle)
    {
        Instantiate(Resources.Load<GameObject>("Prefab/dashAttack"), this.transform.position, Quaternion.Euler(0, 0, angle - 90));
    }
    public void ConeSlash (float angle)
    {
        Instantiate(Resources.Load<GameObject>("Prefab/120Slash"), this.transform.position, Quaternion.Euler(0, 0, angle - 90));
    }
    public void CircleSlash()
    {
        Instantiate(Resources.Load<GameObject>("Prefab/360PullAoe"), this.transform.position, Quaternion.Euler(0, 0, 0));
    }
    public void Clone(Vector3 pos)
    {
        Instantiate(Resources.Load<GameObject>("Prefab/Clone"), new Vector3(pos.x, pos.y,0), Quaternion.Euler(0, 0, 0));
        Instantiate(Resources.Load<GameObject>("Prefab/Clone"), new Vector3(pos.x, pos.y, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(Resources.Load<GameObject>("Prefab/Clone"), new Vector3(pos.x, pos.y, 0), Quaternion.Euler(0, 0, 0));
    }
    public void Shuriken(float angle)
    {
        Instantiate(Resources.Load<GameObject>("Prefab/Shuriken"), this.transform.position, Quaternion.Euler(0, 0, angle - 90));
    }
    public void Trap()
    {
        Instantiate(Resources.Load<GameObject>("Prefab/Trap"), this.transform.position, Quaternion.Euler(0, 0, 0));
    }
    public void Charge()
    {
        Instantiate(Resources.Load<GameObject>("Prefab/ChargeUp"), this.transform.position, Quaternion.Euler(0, 0, 0));
    }
}
