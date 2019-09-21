using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour {

    int counter=30;
    Text counterText;
	void Start () {
        counterText = GameObject.Find("Counter").GetComponent<Text>();
        StartCoroutine(Timer());
	}
	
	IEnumerator Timer()
    {
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            counterText.text = counter.ToString();
        }
        SceneManager.LoadScene(1);
    }
}
