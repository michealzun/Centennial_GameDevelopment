using UnityEngine;
using FireCloud.Perk;
using FireCloud.Entity;

namespace FireCloud.Perk.Behaviour
{
    [CreateAssetMenu(fileName = "Perk", menuName = "Perk/Behaviours/Buff", order = 0)]
    public class Buff : PerkBehaviour
    {
        public Attribute Attribute;
        public float Amount;
        public float Duration;

        public override void OnCast(GameObject sender, CastEventArgs args)
        {
            EntityAttribute attributes = sender.GetComponent<EntityAttribute>();
            if (attributes)
            {
                attributes.AddBuff(Attribute, Amount, Duration);
            }
        }
    }
}