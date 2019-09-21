using UnityEngine;

namespace FireCloud.Perk.Behaviour
{
    public abstract class PerkBehaviour : ScriptableObject
    {
        public abstract void OnCast(GameObject sender, CastEventArgs args);
    }
}
