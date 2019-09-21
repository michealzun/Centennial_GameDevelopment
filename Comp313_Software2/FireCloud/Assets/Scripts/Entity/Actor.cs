using UnityEngine;

namespace FireCloud.Entity
{
    public enum ActorType { Entity, Structure }
    public class Actor : MonoBehaviour
    {
        public ActorType ActorType;
        public bool receiveDamage;
    }
}
