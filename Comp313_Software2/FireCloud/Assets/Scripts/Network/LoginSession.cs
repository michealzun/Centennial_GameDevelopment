using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LoginSession
{
    public string salt;
    public string password;
    public static LoginSession CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<LoginSession>(jsonString);
    }
}
