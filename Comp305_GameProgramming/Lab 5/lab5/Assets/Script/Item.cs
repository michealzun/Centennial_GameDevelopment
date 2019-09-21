using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public int itemType;
    public Score score;
    void start()
    {
        StartCoroutine(Timer());
    }
    private void Update()
    {
    }
    void OnMouseDown()
    {
        score.score[itemType] += 1;
        Destroy(this.gameObject);
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
