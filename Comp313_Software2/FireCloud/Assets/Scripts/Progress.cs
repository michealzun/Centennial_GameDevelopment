using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour {
    public bool[] gearUnlock = new bool[6];
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        for (int i = 0; i < 6; i++)
        {
            gearUnlock[i] = false;
        }         
    }

    private void Update()
    {
        if (Input.GetKey("escape"))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
        }
    }
}
