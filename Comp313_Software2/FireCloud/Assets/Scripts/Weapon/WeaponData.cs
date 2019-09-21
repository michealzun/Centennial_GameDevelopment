using UnityEngine;
using FireCloud.Entity;

namespace FireCloud.Weapon
{
    public delegate void OnFireEventHandler(Vector2 startPosition, Vector2 direction);
    public enum WeaponType { AssaultRifle, Shotgun, MachineGun, Sniper }
    public abstract class WeaponData : ScriptableObject
    {
        public int WeaponID;
        public string Name;
        public string Description;
        public Sprite Thumbnail;
        public Sprite GunSprite;

        public int AmmoPerRound = 10;
        public int TotalCarriedAmmo = 30;
        public float FireRate = 1;
        public float ReloadTime = 2;
        public float SpreadRate = 1;
        public float Damage = 1;
        public int TotalShotPerRound = 1;
        public float BulletSpeedMultiplier = 1;

        public float Range = 100;

        public AudioClip SFXOnFire;

        public abstract WeaponType WeaponType { get; }

        protected GameObject owner;
        protected EntityAttribute entityAttribute;

        public abstract void OnFire(Vector2 startPosition, Vector2 direction);

        public void SetupParameters(DamageSource source)
        {
            source.SetSpeed(BulletSpeedMultiplier);
            source.SetDamage((int)Damage);
            source.TravelDistance = this.Range;
        }

        public static WeaponData Build(int id, WeaponData[] availableWeaponData)
        {
            for (int i = 0; i < availableWeaponData.Length; i++)
            {
                if (availableWeaponData[i].WeaponID == id)
                {
                    return availableWeaponData[i];
                }
            }
            return null;
        }
    }
}
