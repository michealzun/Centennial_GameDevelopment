using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

    public static ScoreController instance;
    public Text POneScore;
    public Text PTwoScore;
    // Use this for initialization
    void Start () {
        instance = this;
        POneScore.text = Convert.ToString(0);
        PTwoScore.text = Convert.ToString(0);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void POneScorePoint() {
        int score = Convert.ToInt32(POneScore.text) + 1;
        POneScore.text = Convert.ToString(score);
    }
    public void PTwoScorePoint() {
        int score = Convert.ToInt32(PTwoScore.text) + 1;
        PTwoScore.text = Convert.ToString(score);
    }
}
