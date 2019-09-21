using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSpawner : MonoBehaviour {

    public int spawnNumber;
    public GameObject slime;
    public GameObject[] slimes;
    public Sprite[] slimeSpirites= new Sprite[3];
    void Start () {
        spawnSlime();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void spawnSlime()
    {
        slimes = new GameObject[spawnNumber];
        for (int i = 0; i < spawnNumber; i++)
        {
            Vector3 spawnLocation = new Vector3(Random.Range(-8, 8), Random.Range(-5, 5), 0);
            slimes[i] = Instantiate(slime, spawnLocation, Quaternion.identity);
            slimes[i].GetComponent<Enemy>().spawner = this.gameObject;
            
            slimes[i].GetComponent<SpriteRenderer>().sprite = slimeSpirites[Random.Range(0,3)];
        }
    }
}
