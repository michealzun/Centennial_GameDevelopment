using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour {
    public Score score;
    public Text scoreA;
    public Text scoreB;
    public Text scoreC;
    void Start () {
        score = GameObject.Find("Score").GetComponent<Score>();
        scoreA.text = "X  " + score.score[0].ToString();
        scoreB.text = "X  " + score.score[1].ToString();
        scoreC.text = "X  " + score.score[2].ToString();
    }

}
