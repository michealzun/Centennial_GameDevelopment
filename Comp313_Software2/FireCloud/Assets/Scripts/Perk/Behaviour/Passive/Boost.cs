using UnityEngine;
using FireCloud.Entity;

namespace FireCloud.Perk.Behaviour
{
    [CreateAssetMenu(fileName = "Perk Behaviour", menuName = "Perk/Behaviours/Boost", order = 1)]
    public class Boost : PerkBehaviour
    {
        public Attribute Attribute;
        public float Amount;

        public override void OnCast(GameObject sender, CastEventArgs args)
        {
            EntityAttribute attributes = sender.GetComponent<EntityAttribute>();
            if (attributes)
            {
                attributes.AddBuff(Attribute, Amount, -1);
            }
        }
    }
}
