using UnityEngine;
using FireCloud.Entity;
using FireCloud.Perk.Behaviour;

namespace FireCloud.Perk
{
    public enum PerkType { Passive, Active }

    [CreateAssetMenu(fileName ="New Perk", menuName ="Perk/Perk", order = 0)]
    public class PerkData : ScriptableObject
    {
        public int PerkID;
        public string Name;
        public string Description;
        public Sprite Thumbnail;
        public PerkType PerkType;
        public float BaseCooldown;
        public AudioClip SFXOnCast;

        public PerkBehaviour[] Behaviours;

        public virtual void OnCast(GameObject sender, CastEventArgs args) { }
        
        public static PerkData Get(int id, PerkData[] availablePerks)
        {
            for (int i = 0; i < availablePerks.Length; i++)
            {
                if (availablePerks[i].PerkID == id)
                {
                    return availablePerks[i];
                }
            }
            return null;
        }
    }
}