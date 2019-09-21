using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Buttons : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

	void Update () {
		
	}

    public void UploadScene()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    public void ViewScene()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    
    //[MenuItem("Example/Load Textures To Folder")]
    public void Upload()
    {
        /*
        string[] files = Directory.GetFiles(EditorUtility.OpenFolderPanel("Load png Textures", "", ""));

        foreach (string file in files)
            if (file.EndsWith(".png"))
            {
                //File.Copy(file, SceneManager.GetActiveScene().ToString());
            }*/
    }
}
