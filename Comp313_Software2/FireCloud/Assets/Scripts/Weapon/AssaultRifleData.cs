using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FireCloud.Weapon
{
    [CreateAssetMenu(fileName = "Assault Rifle", menuName = "Weapon/Assault Rifle", order = 0)]
    public class AssaultRifleData : WeaponData
    {
        public override WeaponType WeaponType
        {
            get
            {
                return WeaponType.AssaultRifle;
            }
        }

        public override void OnFire(Vector2 startPosition, Vector2 direction)
        {
            GameObject bullet = Instantiate(Resources.Load<GameObject>("Prefabs/Bullets/Bullet"), new Vector2(startPosition.x, startPosition.y), Quaternion.Euler(0f, 0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90));
            SetupParameters(bullet.GetComponent<DamageSource>());
        }
    }
}
