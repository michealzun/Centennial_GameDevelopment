using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour {
    public float leftBound;
    public float topBound;
    public float rightBound;
    public float bottomBound;
    public float coolDown=0;
    public GameObject spinner;
    public StateMachine<Boss1> StateMachine;
    public GameObject[] players;
    public Enemy hpScript;
    public Rigidbody2D rb;
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        hpScript = GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        StateMachine = new StateMachine<Boss1>(this);
        StateMachine.ChangeState(new BossOneIdle());
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

    public void Shoot(float angle)
    {
        Instantiate(Resources.Load<GameObject>("Prefab/turretBullet"), this.transform.position, Quaternion.Euler(0, 0, angle-90));
    }
    public GameObject laser(float angle)
    {
        return Instantiate(Resources.Load<GameObject>("Prefab/laserAim"), this.transform.position, Quaternion.Euler(0, 0, angle - 90));
    }
    public void Charge()
    {
        Instantiate(Resources.Load<GameObject>("Prefab/ChargeUp"), this.transform.position, Quaternion.Euler(0, 0, 0));
    }
    public void WildShot()
    {
        Instantiate(Resources.Load<GameObject>("Prefab/WildShot"), this.transform.position, Quaternion.Euler(0, 0, 0));
    }
}
