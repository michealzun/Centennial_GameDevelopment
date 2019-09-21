using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class PlayerProfile
{
    public string accessToken;
    public int weapon1;
    public int weapon2;
    public int perk1;
    public int perk2;
    public int perk3;

    public static PlayerProfile CreateFromJson(string jsonString)
    {
        return JsonUtility.FromJson<PlayerProfile>(jsonString);
    }

    public static void ModifyProfile(PlayerProfile profile)
    {
        WWWForm profileForm = new WWWForm();
        profileForm.AddField("accessToken", profile.accessToken);
        profileForm.AddField("weapon1", profile.weapon1);
        profileForm.AddField("weapon2", profile.weapon2);
        profileForm.AddField("perk1", profile.perk1);
        profileForm.AddField("perk2", profile.perk2);
        profileForm.AddField("perk3", profile.perk3);
        UnityWebRequest webRequest = UnityWebRequest.Post(Authenticator.PROFILE_UPDATE_URL, profileForm);
        webRequest.SendWebRequest();
    }
}
