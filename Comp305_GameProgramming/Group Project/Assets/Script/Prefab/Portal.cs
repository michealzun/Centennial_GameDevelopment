using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour {
    Progress progress;
    public bool returnPortal = false;
    [SerializeField]
    int stage;
    private void Start()
    {
        progress = GameObject.Find("Progress").GetComponent<Progress>();
    }
    private void OnTriggerEnter2D(Collider2D o)
    {
        if (o.gameObject.tag == "Player")
        {
            this.GetComponent<Animator>().SetTrigger("Teleport");
            if (progress.stageUnlock < stage-1)
            {
                progress.stageUnlock = stage-1;
            }
            progress.returnPortal = returnPortal;
            if (o.gameObject.name == "P1")
            {
                progress.playerOneHp = o.gameObject.GetComponent<playerContoller>().hp;
            }
            SceneManager.LoadSceneAsync(stage, LoadSceneMode.Single);
        }
    }
}
