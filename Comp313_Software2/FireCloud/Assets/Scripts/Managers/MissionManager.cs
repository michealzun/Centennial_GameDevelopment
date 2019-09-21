using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FireCloud.Mission
{
    public class MissionManager : MonoBehaviour
    {
        public static List<Mission> MISSIONS = new List<Mission>();
        public GameObject MissionGUI;
        public GameObject MissionPrefab;
        public GameObject RewardPanel;
        [HideInInspector]
        public bool AllMissionCompeleted = false;

        private Dictionary<uint, Text> lstMissions = new Dictionary<uint, Text>();
    
        void Start()
        {
            foreach(Mission m in MISSIONS)
            {
                m.ResetMission();
                m.OnCompeleted += onMissionCompeleted;
                m.OnProgressUpdated += onMissionUpdated;
                var mission = Instantiate(MissionPrefab);
                mission.transform.GetChild(0).GetComponent<Text>().text = m.Title;
                mission.transform.GetChild(1).GetComponent<Text>().text = m.Description;
                mission.transform.SetParent(MissionGUI.transform);

                lstMissions.Add(m.MissionId, mission.transform.GetChild(1).GetComponent<Text>());
                onMissionUpdated(m);
                if (m.Type == Type.Defend)
                {
                    StartCoroutine(DefendCountDown(m));
                }
            }
        }

        public void OnBackClicked()
        {
            SceneManager.LoadScene(2);
        }

        IEnumerator DefendCountDown(Mission m)
        {
            for(int i = 0; i < m.TotalRequired; i++)
            {
                yield return new WaitForSeconds(1);
                m.CompletedCount++;
            }
        }

        private void onMissionCompeleted(Mission m)
        {
            if (lstMissions.ContainsKey(m.MissionId))
            {
                lstMissions[m.MissionId].text = "[Completed]\n\n" + m.Description;
                bool allCompleted = true;
                foreach(Mission mission in MISSIONS)
                {
                    if (mission.Status != Status.Compeleted)
                    {
                        allCompleted = false;
                        break;
                    }
                }
                AllMissionCompeleted = allCompleted;
            }
            if (AllMissionCompeleted)
            {
                int totalExp = 0;
                foreach(Mission missionExp in MISSIONS)
                {
                    totalExp += missionExp.RewardExp;
                }
                RewardPanel.transform.GetChild(1).GetComponent<Text>().text = "Rewards\n\nExp: " + totalExp;
                RewardPanel.gameObject.SetActive(true);
            }
        }

        private void onMissionUpdated(Mission m)
        {
            if(lstMissions[m.MissionId] == null || lstMissions[m.MissionId].text == null)
            {
                return;
            }
            if (lstMissions.ContainsKey(m.MissionId))
            {
                switch (m.Type)
                {
                    case Type.Defend:
                        int min = (m.TotalRequired - m.CompletedCount) / 60;
                        int sec = (m.TotalRequired - m.CompletedCount) % 60;
                        lstMissions[m.MissionId].text = "[In Progress] - " + min + ":" + sec + "\n\n" + m.Description;
                        break;
                    default:
                        lstMissions[m.MissionId].text = "[In Progress] - " + m.CompletedCount + "/" +  m.TotalRequired + "\n\n" + m.Description;
                        break;
                }
            
            }
        }
    }
}