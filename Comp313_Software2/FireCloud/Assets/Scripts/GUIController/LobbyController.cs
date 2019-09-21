using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Networking;
using System;
using UnityEngine.UI;
using FireCloud.Mission;
using FireCloud.Managers;

public class LobbyController : MonoBehaviour
{
   // public TextMeshProUGUI profileText;
    public Selector weaponSelector1;
    public Selector weaponSelector2;
    public Selector perkSelector1;
    public Selector perkSelector2;
    public Selector perkSelector3;

    public GameObject missionBoard;
    public GameObject missionPrefab;

    public Text textMissionDescription;

    public List<Mission> missions = new List<Mission>();

    void Start()
    {
        LoadProfile();
        MissionManager.MISSIONS.Clear();
        foreach(Mission m in missions)
        {
            var prefab = Instantiate(missionPrefab);
            prefab.transform.GetChild(1).GetComponent<Text>().text = m.Title;
            prefab.transform.SetParent(missionBoard.transform);
            var toggle = prefab.GetComponent<Toggle>();
            toggle.onValueChanged.AddListener(delegate
            {
                OnValueChanged(m, toggle);
            });
        }
    }

    public void StartGame()
    {
        // TODO Load Level based on mission
        if(MissionManager.MISSIONS.Count > 0)
        {
            StartCoroutine(SetProfile());
        }
    }

    IEnumerator SetProfile()
    {
        if (GameManager.Instance.Profile == null)
        {
            yield break;
        }
        WWWForm profileForm = new WWWForm();
        profileForm.AddField("accessToken", GameManager.Instance.Profile.accessToken);
        profileForm.AddField("weapon1", weaponSelector1.SelectableItems[weaponSelector1.SelectedIndex].itemId);
        profileForm.AddField("weapon2", weaponSelector2.SelectableItems[weaponSelector2.SelectedIndex].itemId);
        profileForm.AddField("perk1", perkSelector1.SelectableItems[perkSelector1.SelectedIndex].itemId);
        profileForm.AddField("perk2", perkSelector2.SelectableItems[perkSelector2.SelectedIndex].itemId);
        profileForm.AddField("perk3", perkSelector3.SelectableItems[perkSelector3.SelectedIndex].itemId);
        UnityWebRequest webRequest = UnityWebRequest.Post(Authenticator.PROFILE_UPDATE_URL, profileForm);
        yield return webRequest.SendWebRequest();

        if (webRequest.responseCode == 200)
        {
            SceneManager.LoadScene(3);
        }
        else
        {
            Debug.Log(webRequest.responseCode + " " + webRequest.error);
        }
    }

    public void LogOff()
    {
        GameManager.Instance.Profile = default(PlayerProfile);
        SceneManager.LoadScene(0);
    }

    private string FormatProfile(PlayerProfile p)
    {
        string profile = "";
        profile += "Wepaon 1 ID: " + p.weapon1 + Environment.NewLine;
        profile += "Wepaon 2 ID: " + p.weapon2 + Environment.NewLine;
        profile += "Perk 1 ID: " + p.perk1 + Environment.NewLine;
        profile += "Perk 2 ID: " + p.perk2 + Environment.NewLine;
        profile += "Perk 3 ID: " + p.perk3;
        return profile;
    }

    private void LoadProfile()
    {
        if (GameManager.Instance.Profile != null)
        {
            weaponSelector1.SelectedIndex = GameManager.Instance.Profile.weapon1;
            weaponSelector2.SelectedIndex = GameManager.Instance.Profile.weapon2;
            perkSelector1.SelectedIndex = GameManager.Instance.Profile.perk1;
            perkSelector2.SelectedIndex = GameManager.Instance.Profile.perk2;
            perkSelector3.SelectedIndex = GameManager.Instance.Profile.perk3;
        }
    }

    private void OnValueChanged(Mission m, Toggle toggle)
    {
        if (toggle.isOn)
        {
            MissionManager.MISSIONS.Add(m);
        }
        else
        {
            MissionManager.MISSIONS.Remove(m);
        }
        textMissionDescription.text = m.Description;
    }
}
