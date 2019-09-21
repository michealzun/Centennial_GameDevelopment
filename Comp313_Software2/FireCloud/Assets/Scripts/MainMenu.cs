using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
    
    // Login Scene
    public void ShowLogin()
    {
        SceneManager.LoadScene(1);
    }

    // Quit Button
    public void QuitGame()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }
}
