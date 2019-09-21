using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int[] score = new int[3];
	void Start () {
        for (int i = 0; i < 2; i++)
        {
            score[i] = 0;
        }
        DontDestroyOnLoad(this.gameObject);
	}
}
