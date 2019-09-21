using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using FireCloud.Managers;

public class Authenticator : MonoBehaviour
{
    public enum ErrorCode { NoConnection, Invalid }
    public const string SIGNUP_URL = "http://project.jiabintang.com/firecloud/signup";
    public const string LOGIN_URL = "http://project.jiabintang.com/firecloud/api/auth/";
    public const string PROFILE_URL = "http://project.jiabintang.com/firecloud/api/profile/";
    public const string PROFILE_UPDATE_URL = "http://project.jiabintang.com/api/profile/update/";

    private LoginSession session;

    public IEnumerator Authenticate(string username, string password, LoginController controller)
    {
        // Disable Input
        EnableControls(controller, false);
        controller.textMessage.color = Color.black;
        controller.textMessage.text = "Logging in......";

        // Create Login Form
        WWWForm loginForm = new WWWForm();
        loginForm.AddField("USERNAME", username);
        // Create HTTP Request
        UnityWebRequest webRequest = UnityWebRequest.Post(LOGIN_URL, loginForm);

        // Wait for response
        yield return webRequest.SendWebRequest();

        // Show Error
        if (webRequest.isNetworkError || webRequest.isHttpError)
        {
            switch (webRequest.responseCode)
            {
                case 404:
                case 400:
                    showErrorMessage(ErrorCode.Invalid, controller);
                    break;
                default:
                    showErrorMessage(ErrorCode.NoConnection, controller);
                    break;
            }
            EnableControls(controller, true);
        }
        else
        {
            // Show results as text
            session = LoginSession.CreateFromJson(webRequest.downloadHandler.text);
            if (SecurityUtility.PBKDF2(password, session.salt) == session.password)
            {
                if (session != null)
                {
                    controller.textMessage.text = "Logged in";
                    StartCoroutine(LoadProfile(username));
                }
            }
            else
            {
                showErrorMessage(ErrorCode.Invalid, controller);
                EnableControls(controller, true);
            }
        }
        EventSystem.current.SetSelectedGameObject(controller.inputUsername.gameObject);
    }

    private void EnableControls(LoginController controller, bool b)
    {
        controller.inputUsername.interactable = b;
        controller.inputPassword.interactable = b;
        controller.buttonLogin.interactable = b;
        controller.buttonSignUp.interactable = b;
        controller.buttonBack.interactable = b;
    }

    IEnumerator LoadProfile(string username)
    {
        string accessToken = SecurityUtility.PBKDF2(username, session.salt);
        WWWForm profileForm = new WWWForm();
        profileForm.AddField("accessToken", accessToken);
        UnityWebRequest webRequest = UnityWebRequest.Post(PROFILE_URL, profileForm);
        yield return webRequest.SendWebRequest();
        if (webRequest.responseCode == 200)
        {
            GameManager.Instance.Profile = PlayerProfile.CreateFromJson(webRequest.downloadHandler.text);
            SceneManager.LoadScene(2);
        }
    }

    private void showErrorMessage(ErrorCode code, LoginController controller)
    {
        controller.textMessage.color = Color.red;
        string error = "Error: ";
        switch (code)
        {
            case ErrorCode.Invalid:
                error += "Invalid Username or Password.";
                break;
            case ErrorCode.NoConnection:
                error += "Failed to connect to server.";
                break;
        }
        controller.textMessage.text = error;
    }
}