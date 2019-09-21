using System.Collections.Generic;
using UnityEngine;
using FireCloud.Perk.Behaviour;
using FireCloud.Perk;

namespace Assets.Scripts.Perk.Behaviour
{
    [CreateAssetMenu(fileName = "Perk Behaviour", menuName = "Perk/Behaviours/Place Entity", order = 1)]
    public class PlaceEntity : PerkBehaviour
    {
        public int MaximumEntityCount = 3;
        public GameObject Entity;
        public float EntityTimer = -1;

        public override void OnCast(GameObject sender, CastEventArgs args)
        {
            GameObject entity = Instantiate(Entity, sender.transform.position, Quaternion.identity);
            if(EntityTimer != -1)
            {
                Destroy(entity, EntityTimer);
            }
        }
    }
}
