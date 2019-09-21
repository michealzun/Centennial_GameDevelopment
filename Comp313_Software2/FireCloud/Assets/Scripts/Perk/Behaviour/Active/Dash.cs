using UnityEngine;
using FireCloud.Perk;
using FireCloud.Entity;

namespace FireCloud.Perk.Behaviour
{
    [CreateAssetMenu(fileName = "Perk", menuName = "Perk/Behaviours/Dash", order = 0)]
    public class Dash : PerkBehaviour
    {
        public override void OnCast(GameObject sender, CastEventArgs args)
        {
            Rigidbody2D rb2d = sender.GetComponent<Rigidbody2D>();
            EntityAttribute attributes = sender.GetComponent<EntityAttribute>();
            if (rb2d && attributes)
            {
                rb2d.AddForce(attributes.facingDirection * attributes.dashForce, ForceMode2D.Impulse);
            }
        }
    }
}
