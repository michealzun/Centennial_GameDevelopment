using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {
    Progress progress;
    public Button[] stages= new Button[4];
    public Button continueGame;
    private void Start()
    {
        progress = GameObject.Find("Progress").GetComponent<Progress>();
        for (int i = 0; i < stages.Length; i++)
        {
            if(progress.stageUnlock <= i)
            {
                stages[i].interactable = false;
            }
            else
            {
                stages[i].interactable = true;
            }
        }
        if(progress.stageUnlock < 1)
        {
            continueGame.interactable = false;
        }
        else
        {
            continueGame.interactable = true;
        }
    }
    public void Continue()
    {
        progress.playerOneHp = 100;
        string level = "level" + progress.stageUnlock;
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
    public void StartGame()
    {
        progress.playerOneHp = 100;
        SceneManager.LoadScene("Level0", LoadSceneMode.Single);
    }
    public void CheckPoint()
    {
        StartCoroutine(Scroll(550));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void Stage1()
    {
        progress.playerOneHp = 100;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    public void Stage2()
    {
        progress.playerOneHp = 100;
        SceneManager.LoadScene("Level2", LoadSceneMode.Single);
    }
    public void Stage3()
    {
        progress.playerOneHp = 100;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    public void Stage4()
    {
        progress.playerOneHp = 100;
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }
    public void Back()
    {
        StartCoroutine(Scroll(-550));
    }
    IEnumerator Scroll(int amount)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0,amount);
        yield return new WaitForSeconds(1);
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }
}
