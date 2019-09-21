using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
   
    private AudioSource audioScr;
    void Start()
    {
        audioScr = GetComponent<AudioSource>();
        
    }
    private static Volume instantce = null;
    public static Volume Instance
    {
        get { return instantce; }
    }
    void Awake()
    {
        if (instantce != null && instantce != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instantce = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    public void Update()
    {
        audioScr.volume = PlayerPrefs.GetFloat("MusicVolume");
    }

}
