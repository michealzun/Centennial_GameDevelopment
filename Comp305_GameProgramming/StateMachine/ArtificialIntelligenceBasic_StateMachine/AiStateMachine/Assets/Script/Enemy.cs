using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public GameObject spawner;
    public GameObject player;
    public Vector3 StartPos;

    public StateMachine<Enemy> StateMachine { get; set; }

	void Start () {
        player= GameObject.Find("Player");
        StartPos = this.transform.position;

        StateMachine = new StateMachine<Enemy>(this);
        StateMachine.ChangeState(Patrol.Instance);
    }

	void Update () {
        StateMachine.Update();
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, -8, 8), Mathf.Clamp(this.transform.position.y, -5, 5));
	}
}
