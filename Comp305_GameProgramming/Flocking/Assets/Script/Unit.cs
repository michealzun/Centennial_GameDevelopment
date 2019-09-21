using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {
    public GameObject manager;
    public Vector3 currPos;
    public Vector3 goalPos;
    public Vector3 accDir;

    private float angle;

    void Update()
    {
        accTowardsGoal();
        adjustAngle();
        adjustSpeed();
    }

    void accTowardsGoal()
    {
        currPos = this.transform.position;

        if (Random.Range(0, 10) < 1)
        {
            goalPos = manager.transform.position;
            accDir = goalPos - currPos;
            accDir = accDir.normalized *10 + align()*5 + cohesion()*10;
        }
        this.GetComponent<Rigidbody2D>().AddForce(accDir);
    }

    void adjustAngle()
    {
        angle = Mathf.Atan2(this.GetComponent<Rigidbody2D>().velocity.y, this.GetComponent<Rigidbody2D>().velocity.x) * 180 / Mathf.PI + 90;
        this.transform.eulerAngles = new Vector3(0, 0, angle);
    }

    void adjustSpeed()
    {
        if (this.GetComponent<Rigidbody2D>().velocity.magnitude > 3f)
        {
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity.normalized * 3f;
        }
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x,-8,8), Mathf.Clamp(this.transform.position.y, -5,5), 0);
    }

    Vector3 align()
    {
        float neighbourDis = manager.GetComponent<GameController>().neighbourDistance;
        Vector2 sum = Vector2.zero;
        int count = 0;
        foreach (GameObject other in manager.GetComponent<GameController>().orbs)
        {
            if (other == this.gameObject) continue;

            float distance = Vector3.Distance(currPos, other.GetComponent<Unit>().currPos);
            if (distance < neighbourDis)
            {
                sum += other.GetComponent<Rigidbody2D>().velocity;
                count++;
            }
        }
        if (count > 0)
        {
            sum /= count;
            Vector3 steer = new Vector3(sum.x - this.GetComponent<Rigidbody2D>().velocity.x, sum.y - this.GetComponent<Rigidbody2D>().velocity.y, 0);
            return steer;
        }

        return Vector3.zero;
    }

    Vector3 cohesion()
    {
        float neighbourDis = manager.GetComponent<GameController>().neighbourDistance;
        float personalSpace = manager.GetComponent<GameController>().personalSpace;
        Vector3 sum1 = Vector3.zero;
        Vector3 sum2 = Vector3.zero;
        Vector3 sum = Vector3.zero;
        int count1 = 0;
        int count2 = 0;
        int count = 0;
        foreach (GameObject other in manager.GetComponent<GameController>().orbs)
        {
            if (other == this.gameObject) continue;

            float distance = Vector3.Distance(currPos, other.GetComponent<Unit>().currPos);

            if (distance < neighbourDis && distance > personalSpace)
            {
                sum1 += other.GetComponent<Unit>().currPos;
                count1++;
            }
            else if (distance < personalSpace)
            {
                sum2 -= other.GetComponent<Unit>().currPos;
                count2++;
            }
        }
        if (count > 0)
        {
            sum1 /= count1;
            sum2 /= count2;
            sum = (sum1 + sum2) / 2;
            Vector3 steer = sum - currPos;
            steer = steer - currPos;
            return steer;
        }

        return Vector3.zero;
    }

}
