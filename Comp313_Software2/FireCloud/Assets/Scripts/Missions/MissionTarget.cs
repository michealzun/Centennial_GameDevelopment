using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireCloud.Entity;

namespace FireCloud.Mission
{
    public enum MissionTargetType { None, PowerGenerator, HiddenBoss, MeleeBot, TowerBot };
    public class MissionTarget : MonoBehaviour
    {
        public MissionTargetType MissionTargetType;
        [HideInInspector]
        public EntityAttribute attribute;

        private void Start()
        {
            attribute = GetComponent<EntityAttribute>();
        }

        public void OnDamage(float damage)
        {
            if (attribute)
            {
                attribute.hp -= damage;
                if (attribute.hp <= 0)
                {
                    foreach (Mission m in MissionManager.MISSIONS)
                    {
                        if (m.MissionTargetType == this.MissionTargetType)
                        {
                            m.CompletedCount++;
                            break;
                        }
                    }
                    Destroy(this.gameObject);
                }
            }
            
        }
        void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.GetComponent<DamageSource>())
            {

            }
        }
    }
}

