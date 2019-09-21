using System;
using UnityEngine;

namespace FireCloud.Weapon
{
    [CreateAssetMenu(fileName = "Machine Gun", menuName = "Weapon/Machine Gun", order = 2)]
    public class MachineGunData : WeaponData
    {
        public override WeaponType WeaponType
        {
            get
            {
                return WeaponType.MachineGun;
            }
        }

        public override void OnFire(Vector2 startPosition, Vector2 direction)
        {
            GameObject bullet = Instantiate(Resources.Load<GameObject>("Prefabs/Bullets/Bullet"), new Vector2(startPosition.x, startPosition.y), Quaternion.Euler(0f, 0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90));
            SetupParameters(bullet.GetComponent<DamageSource>());
        }
    }
}
