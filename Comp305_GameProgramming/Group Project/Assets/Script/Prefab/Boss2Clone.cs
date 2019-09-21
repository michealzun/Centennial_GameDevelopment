using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2Clone : MonoBehaviour {
    ArrayList angles = new ArrayList();
    public GameObject[] players;
    Vector3 pos = Vector3.zero;
    void Start()
    {
        while (pos==Vector3.zero)
        {
            pos = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0).normalized * 5f;
        }
        this.transform.position += pos;
        players = GameObject.FindGameObjectsWithTag("Player");
        StartCoroutine(Slash());
    }

    IEnumerator Slash()
    {
        this.GetComponent<Rigidbody2D>().velocity = -pos;
        yield return new WaitForSeconds(0.3f);
        foreach (var player in players)
        {
            angles.Add(Mathf.Atan2(player.transform.position.y - this.transform.position.y, player.transform.position.x - this.transform.position.x) * Mathf.Rad2Deg);
        }
        yield return new WaitForSeconds(0.3f);
        foreach (float angle in angles)
        {
            Instantiate(Resources.Load<GameObject>("Prefab/dashAttack"), this.transform.position, Quaternion.Euler(0, 0, angle - 90));
        }
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
