using UnityEngine;

namespace FireCloud.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public int DefaultWeapon1Id;
        public int DefaultWeapon2Id;

        public int DefaultPerk1Id;
        public int DefaultPerk2Id;
        public int DefaultPerk3Id;

        [HideInInspector]
        public PlayerProfile Profile = new PlayerProfile();

        void OnEnable()
        {
            if(Instance != null)
            {
                return;
            }
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            Profile = new PlayerProfile
            {
                weapon1 = DefaultWeapon1Id,
                weapon2 = DefaultWeapon2Id,

                perk1 = DefaultPerk1Id,
                perk2 = DefaultPerk2Id,
                perk3 = DefaultPerk3Id
            };
        }
    }
}
