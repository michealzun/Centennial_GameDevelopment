using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class manager : MonoBehaviour {
    [HideInInspector]
	public int score;
    private Text scoreText;
    public GameObject lastSpawn;
    public float speed=1f;
    void Start () {
        score = 0;
        scoreText = GameObject.Find("Canvas/Score").GetComponent<Text>();   
    }

	void Update () {
        scoreText.text = score.ToString();
        if (lastSpawn.transform.position.y >= -10f)
            spawn();
        /*  for testing purpose only
        if (Input.GetKeyDown("up"))
        {
            speed += 0.5f;
        }

        if (Input.GetKeyDown("down"))
        {
            speed -= 0.5f;
        }
        */
        speed += Time.deltaTime * 0.03f;
    }

    void spawn()
    {
        if (Random.value >= 0.5f)
        {
            lastSpawn=(GameObject)Instantiate(Resources.Load("badPost"), lastSpawn.transform.position + new Vector3(0, -7.5f, 0),Quaternion.identity);
        }
        else
        {
            lastSpawn = (GameObject)Instantiate(Resources.Load("goodPost"), lastSpawn.transform.position + new Vector3(0, -7.5f, 0), Quaternion.identity);
        }
    }
}
