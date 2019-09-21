using FireCloud.Managers;
using System.Collections;
using UnityEngine;

namespace FireCloud.Weapon
{
    public class Weapon
    {
        public WeaponData Data { get; private set; }
        public int WeaponID { get; private set; }
        public string Name { get; private set; }
        public int AmmoPerRound { get; private set; }
        public int CurrentAmmo { get; set; }
        public int TotalAmmo{ get; set; }

        public float FireRate { get; set; }
        public float FireRateMultiplier { get; set; } = 1;
        public float SpreadRate { get; set; }
        public float Damage { get; private set; }
        public float Range { get; private set; }

        public float ReloadTimer { get; set; }
        public float ReloadTime { get; set; }

        public int TotalShotPerRound { get; private set; }

        public float FireCooldown = 0;

        public float BulletSpeedMultiplier = 1;

        private GameObject _owner;
        
        public WeaponType WeaponType { get; private set; }

        public event OnFireEventHandler OnFire;

        public bool FireReady
        {
            get
            {
                if (FireCooldown >= FireRate * FireRateMultiplier)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsReloading { get; set; } = false;

        public bool CanReload
        {
            get
            {
                return CurrentAmmo < AmmoPerRound;
            }
        }

        public Weapon(GameObject owner, WeaponData data)
        {
            this.Data = data;
            this._owner = owner;
            this.WeaponID = data.WeaponID;
            this.Name = data.Name;
            this.WeaponType = data.WeaponType;
            this.Range = data.Range;
            this.ReloadTime = data.ReloadTime;
            this.AmmoPerRound = data.AmmoPerRound;
            this.CurrentAmmo = data.AmmoPerRound;
            this.TotalAmmo = data.TotalCarriedAmmo;
            this.FireRate = data.FireRate;
            this.FireCooldown = this.FireRate;
            this.SpreadRate = data.SpreadRate;
            this.Damage = data.Damage;
            this.TotalShotPerRound = data.TotalShotPerRound;
            this.BulletSpeedMultiplier = data.BulletSpeedMultiplier;
            // SFX sound
            this.OnFire += delegate {
                AudioManager.Instance.PlaySFX(data.SFXOnFire);
            };
            // Set up Firing Behaviour (number of bullets, bullet angle)
            this.OnFire += data.OnFire;
        }

        public void Fire(Vector2 startPosition, Vector2 direction)
        {
            if (FireReady && CurrentAmmo > 0)
            {
                this.OnFire(startPosition, direction);
                CurrentAmmo -= TotalShotPerRound;
                FireCooldown = 0;
            }
        }
        
        public void Reload()
        {
            int reloadAmount = AmmoPerRound - CurrentAmmo;
            if (TotalAmmo >= reloadAmount)
            {
                this.CurrentAmmo += reloadAmount;
                this.TotalAmmo -= reloadAmount;
            }
            else
            {
                this.CurrentAmmo += TotalAmmo;
                this.TotalAmmo = 0;
            }
        }
    }
}
