using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreController : MonoBehaviour {
    public static ScoreController instance;
    public int score;
    public int life;
    public Text scoretext;
    public Text gameovertext;
    public int maxscore;
    private int stageCount;
    private string nextscene;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    void Start () {
        maxscore = 22;
        instance = this;
        stageCount = 2;
        nextscene = "scene/level" + stageCount;
    }
	
	void Update () {
    }
    public void gainLife()
    {
        life++;
        gameovertext.text = "Life : " + life;
    }
    public void loseLife()
    {
        life--;
        gameovertext.text = "Life : " + life;
        if (life < 1 &&  gameovertext.text != "Victory")
        {
            gameovertext.text = "Game Over";
        }
    }
    public void addScore()
    {
        score++;
        scoretext.text = "score : " + score;
        if (score >= maxscore)
        {
            if (stageCount == 4)
            {
                gameovertext.text = "Victory";
            }
            else
            { 
                SceneManager.LoadScene(nextscene);
                maxscore = maxscore + 22;
                stageCount++;
                nextscene = "scene/level" + stageCount;
            }
       }
    }
}
