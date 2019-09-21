using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour {
    public bool[] gearUnlock = new bool[6];
    public int stageUnlock = 0;
    public int portal = 0;
    public bool returnPortal = false;
    public float playerOneHp = 100;
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
        if (Input.GetKey("f1"))
        {
            for (int i = 0; i < gearUnlock.Length; i++)
            {
                gearUnlock[i] = true;
            }
            stageUnlock = 10;
        }

    }
}
