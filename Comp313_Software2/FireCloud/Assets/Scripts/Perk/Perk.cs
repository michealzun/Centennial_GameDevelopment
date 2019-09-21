using System.Collections.Generic;
using UnityEngine;
using FireCloud.Entity;
using FireCloud.Perk.Behaviour;
using FireCloud.Managers;

namespace FireCloud.Perk
{
    public delegate void OnCastEventHandler(GameObject sender, CastEventArgs args);

    public class Perk
    {
        public int PerkID { get; private set; }
        public string Name { get; private set; }

        public float BaseCooldown = 0;
        public float CurrentCooldown = 0;

        private GameObject _owner;
        private EntityAttribute _ownerAttributes;

        public PerkData Data;

        public virtual PerkType PerkType { get; private set; }

        public event OnCastEventHandler OnCast;

        public bool Ready
        {
            get
            {
                if (CurrentCooldown <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public Perk(GameObject owner, PerkData data)
        {
            this.Data = data;
            this._owner = owner;
            this._ownerAttributes = this._owner.GetComponent<EntityAttribute>();
            this.PerkID = data.PerkID;
            this.Name = data.Name;
            this.PerkType = data.PerkType;
            this.BaseCooldown = data.BaseCooldown;
            initializeBehaviours();
            this.OnCast += delegate {
                if (this.PerkType != PerkType.Passive)
                {
                    AudioManager.Instance.PlaySFX(data.SFXOnCast);
                }
            };
            if (this.PerkType == PerkType.Passive)
            {
                this.OnCast(this._owner, null);
            }
        }

        public void Cast(GameObject sender, CastEventArgs args)
        {
            if (Ready && this.OnCast != null)
            {
                this.OnCast(sender, args);
                this.CurrentCooldown = this.BaseCooldown;
            }
        }

        public void SetReady(bool b)
        {
            this.CurrentCooldown = b ? this.BaseCooldown : 0;
        }

        private void initializeBehaviours()
        {
            if (this.Data)
            {
                foreach(PerkBehaviour behaviour in this.Data.Behaviours)
                {
                    this.OnCast += behaviour.OnCast;
                }
            }
        }

        public void UpdateCooldown()
        {
            if (this.CurrentCooldown > 0)
            {
                this.CurrentCooldown -= Time.fixedDeltaTime;
            }
            if(this.CurrentCooldown < 0)
            {
                this.CurrentCooldown = 0;
            }
        }
    }
}