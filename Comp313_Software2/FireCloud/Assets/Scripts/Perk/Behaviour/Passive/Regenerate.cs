using UnityEngine;
using FireCloud.Perk;
using FireCloud.Entity;

namespace FireCloud.Perk.Behaviour
{
    public enum RegenerateType { Percentage, Fixed }
    [CreateAssetMenu(fileName = "Perk", menuName = "Perk/Behaviours/Regenerate", order = 0)]
    public class Regenerate : PerkBehaviour
    {
        public RegenerateType RegenerateType;

        public float Amount = 50;

        public override void OnCast(GameObject sender, CastEventArgs args)
        {
            EntityAttribute attributes = sender.GetComponent<EntityAttribute>();
            if (attributes)
            {
                switch (RegenerateType)
                {
                    case RegenerateType.Percentage:
                        if(attributes.hp < ((100 - Amount) / 100 * attributes.baseHp))
                        {
                            attributes.HealthReg(5, attributes.baseHp - attributes.hp);
                        }
                        break;
                    case RegenerateType.Fixed:
                        if (attributes.hp < Amount)
                        {
                            attributes.HealthReg(5, attributes.baseHp - attributes.hp);
                        }
                        break;
                }
            }
        }

    }
}