using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject powerUp;
    public GameObject EnemyDown;
    public GameObject EnemyZigZag;
    public GameObject EnemyLeftRightDown;
    public GameObject EnemyRD;
    public GameObject EnemyLD;
    public GameObject EnemyTurr;
    public GameObject EnemyBoss;
    public AudioSource AudioSource;
    public AudioClip warning;
    public AudioClip bossBGM;
    public Text txt;
    void Start () {
        StartCoroutine(SpawnWaves());
	}

	void Update () {

	}
        IEnumerator SpawnWaves()
    {
        //wave 1
        Instantiate(EnemyDown,new Vector3(5f,6f,0), this.transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(EnemyDown, new Vector3(-5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyDown, new Vector3(-5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(3);
        txt = GameObject.Find("Text").GetComponent<Text>();
        txt.text = " ";
        Instantiate(EnemyLeftRightDown, new Vector3(-4f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyLeftRightDown, new Vector3(4f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(13);
        Instantiate(EnemyZigZag, new Vector3(2.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyZigZag, new Vector3(2.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyZigZag, new Vector3(2.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyZigZag, new Vector3(2.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyZigZag, new Vector3(2.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        //wave 2
        Instantiate(EnemyRD, new Vector3(-3f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyRD, new Vector3(-3.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(EnemyLD, new Vector3(2f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyLD, new Vector3(2.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyLD, new Vector3(3f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyLD, new Vector3(3.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyLD, new Vector3(4f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(4);
        Instantiate(EnemyTurr, new Vector3(-4f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(4f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(4);
        Instantiate(EnemyDown, new Vector3(-4f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyDown, new Vector3(4f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyDown, new Vector3(-2.5f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyDown, new Vector3(2.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyDown, new Vector3(-1f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyDown, new Vector3(1f, 6f, 0), this.transform.rotation);
        //wave 3
        yield return new WaitForSeconds(4);
        Instantiate(EnemyZigZag, new Vector3(-6f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyTurr, new Vector3(5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyDown, new Vector3(-7.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyDown, new Vector3(-5.5f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyDown, new Vector3(-7.5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyDown, new Vector3(-6f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(EnemyLeftRightDown, new Vector3(0f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(6);
        Instantiate(EnemyTurr, new Vector3(-5f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(5f, 6f, 0), this.transform.rotation);
        Instantiate(powerUp, new Vector3(0f, 6f, 0), this.transform.rotation);
        //wave 4
        yield return new WaitForSeconds(5);
        Instantiate(EnemyTurr, new Vector3(-5f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(EnemyLD, new Vector3(6f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyLD, new Vector3(5f, 7f, 0), this.transform.rotation);
        Instantiate(EnemyLD, new Vector3(4f, 8f, 0), this.transform.rotation);
        yield return new WaitForSeconds(4);
        Instantiate(EnemyTurr, new Vector3(-6f, 7f, 0), this.transform.rotation);
        yield return new WaitForSeconds(1);
        Instantiate(EnemyRD, new Vector3(-6f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyRD, new Vector3(-5f, 7f, 0), this.transform.rotation);
        Instantiate(EnemyRD, new Vector3(-4f, 8f, 0), this.transform.rotation);
        yield return new WaitForSeconds(2);
        Instantiate(EnemyTurr, new Vector3(0f, 7f, 0), this.transform.rotation);
        yield return new WaitForSeconds(5);
        Instantiate(EnemyTurr, new Vector3(-4f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(0f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(EnemyTurr, new Vector3(-4f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(4);
        Instantiate(EnemyTurr, new Vector3(2f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyDown, new Vector3(7f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(6);
        Instantiate(EnemyDown, new Vector3(1f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyDown, new Vector3(-3f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyDown, new Vector3(-5f, 6f, 0), this.transform.rotation);
        //wave 5
        yield return new WaitForSeconds(4);
        Instantiate(EnemyTurr, new Vector3(-6f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(4);
        Instantiate(EnemyTurr, new Vector3(8f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(4);
        Instantiate(EnemyTurr, new Vector3(8f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(7);
        Instantiate(EnemyLeftRightDown, new Vector3(-4f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyLeftRightDown, new Vector3(4f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(-8f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(8f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(2);
        Instantiate(EnemyTurr, new Vector3(-8f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(8f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(2);
        Instantiate(EnemyTurr, new Vector3(-8f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(8f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(2);
        Instantiate(EnemyTurr, new Vector3(-8f, 6f, 0), this.transform.rotation);
        Instantiate(EnemyTurr, new Vector3(8f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(powerUp, new Vector3(4f, 6f, 0), this.transform.rotation);
        Instantiate(powerUp, new Vector3(-4f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(6);
        //boos
        Instantiate(EnemyDown, new Vector3(0f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(EnemyDown, new Vector3(5f, 6f, 0), this.transform.rotation);
        yield return new WaitForSeconds(3);
        Instantiate(EnemyDown, new Vector3(-5f, 6f, 0), this.transform.rotation);
        AudioSource.clip = warning;
        AudioSource.Play();
        yield return new WaitForSeconds(5);
        AudioSource.clip = bossBGM;
        AudioSource.Play();
        Instantiate(EnemyBoss, new Vector3(0f, 7f, 0), this.transform.rotation);
    }

}
