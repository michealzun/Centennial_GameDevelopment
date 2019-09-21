using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    GameObject item;
    public Score Score;
    int choose;
    // Use this for initialization
    void Start () {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            float randX = Random.Range(-7, 7);
            float randY = Random.Range(-3, 3);
            choose =Random.Range(1, 4);
            switch (choose)
            {
                case 1:
                    item=Instantiate((GameObject)Resources.Load("Prefab/Bounce"),new Vector3(randX,randY,0), Quaternion.Euler(0, 0, 0));
                    break;
                case 2:
                    item = Instantiate((GameObject)Resources.Load("Prefab/Float"), new Vector3(randX, randY, 0), Quaternion.Euler(0, 0, 0));
                    break;
                case 3:
                    item = Instantiate((GameObject)Resources.Load("Prefab/Random"), new Vector3(randX, randY, 0), Quaternion.Euler(0, 0, 0));
                    break;
                default:
                    break;
            }
            item.GetComponent<Item>().score = Score;
            randX = Random.Range(-1f, 1f);
            randY = Random.Range(-1f, 1f);
            item.GetComponent<Rigidbody2D>().velocity = new Vector3(randX, randY, 0);
        }
    }
}
