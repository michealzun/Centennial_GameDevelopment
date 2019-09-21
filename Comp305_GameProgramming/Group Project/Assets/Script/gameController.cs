using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameController : MonoBehaviour
{
    GameObject progress;
    GameObject died;
    public playerContoller playerOne;
    public playerContoller playerTwo;
    public Vector3 returnPortalSpawn;
    public int bossStage=0;

    void Start()
    {
        if (GameObject.Find("Progress") == null)
        {
            progress = Instantiate(Resources.Load<GameObject>("Prefab/Progress"), new Vector3(0, 0, 0), Quaternion.Euler(0, 0, 0));
            progress.gameObject.name = "Progress";
        }
        else
        {
            progress = GameObject.Find("Progress");
        }
        died = GameObject.Find("Died");
        if (progress.GetComponent<Progress>().returnPortal)
        {
            playerOne.transform.position = returnPortalSpawn;
            progress.GetComponent<Progress>().returnPortal = false;
        }
        playerOne.hp = progress.GetComponent<Progress>().playerOneHp;
    }


    void Update()
    {
        if (playerOne.alive)
        {
            playerOne.inputVec = new Vector2(Input.GetAxisRaw("1Hor"), Input.GetAxisRaw("1Ver")).normalized;
            if (Input.GetKeyDown(KeyCode.J))
            {
                playerOne.Attack("pipeLight");
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                playerOne.Attack("dash");
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                playerOne.Attack("pistolLight");
            }
            if (Input.GetKey(KeyCode.K))
            {
                playerOne.Attack("pistolSpecial");
            }
            if (Input.GetKeyUp(KeyCode.K))
            {
                playerOne.Attack("pistolEnd");
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                playerOne.Attack("HealStart");
            }
            if (Input.GetKey(KeyCode.L))
            {
                playerOne.Attack("Heal");
            }
            if (Input.GetKeyUp(KeyCode.L))
            {
                playerOne.Attack("HealEnd");
            }
            if (Input.GetKeyUp(KeyCode.B))
            {
                playerOne.hpLock = !playerOne.hpLock;
            }
        }

        /*
        playerTwoCon.Move(Input.GetAxis("2Hor"), Input.GetAxis("2Ver"));
        */
        if (!playerOne.alive)
        {
            StartCoroutine(Died());
        }
    }

    IEnumerator Died()
    {
        died.GetComponent<Image>().enabled = true;
        this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sound/died");
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

}
