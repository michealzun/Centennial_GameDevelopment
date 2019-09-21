using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LoginController : MonoBehaviour
{
    public Authenticator authenticator;

    public Text textMessage;
    public InputField inputUsername;
    public InputField inputPassword;
    public Button buttonBack;
    public Button buttonLogin;
    public Button buttonSignUp;

    void Start()
    {
        // Focus on the email input field when enter scene
        EventSystem.current.SetSelectedGameObject(inputUsername.gameObject);
    }
    public void Login()
    {
        StartCoroutine(authenticator.Authenticate(inputUsername.text, inputPassword.text, this));
    }

    public void OpenSignUpPage()
    {
        // Start the page in browser
        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo(Authenticator.SIGNUP_URL);
        System.Diagnostics.Process.Start(startInfo);
    }

    public void GoBack()
    {
        SceneManager.LoadScene(0);
    }

    void OnGUI()
    {
        // Making the controls user friendly(aka tab between input fields)
        if (inputUsername.isFocused)
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                EventSystem.current.SetSelectedGameObject(inputPassword.gameObject);
            }
        }
        if (inputPassword.isFocused)
        {
            if (Input.GetKeyUp(KeyCode.Tab))
            {
                EventSystem.current.SetSelectedGameObject(inputUsername.gameObject);
            }
            // Use the event instead of Input.GetKeyUp(KeyCode.Return), Input.GetKeyUp will eat by the input field
            if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return)
            {
                buttonLogin.onClick.Invoke();
            }
        }
    }
}