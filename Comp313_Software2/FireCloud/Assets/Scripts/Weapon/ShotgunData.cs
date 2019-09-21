using UnityEngine;

namespace FireCloud.Weapon
{
    [CreateAssetMenu(fileName = "Shotgun", menuName = "Weapon/Shotgun", order = 1)]
    public class ShotgunData : WeaponData
    {
        public override WeaponType WeaponType
        {
            get
            {
                return WeaponType.Shotgun;
            }
        }

        public override void OnFire(Vector2 startPosition, Vector2 direction)
        {
            float sprayAngle = 8;
            for (int i = 0; i < TotalShotPerRound; i++)
            {
                GameObject bullet = Instantiate(Resources.Load<GameObject>("Prefabs/Bullets/Bullet"), new Vector2(startPosition.x, startPosition.y), Quaternion.Euler(0f, 0f, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90 + UnityEngine.Random.Range(-sprayAngle / 2, sprayAngle / 2)));
                SetupParameters(bullet.GetComponent<DamageSource>());
            }
        }
    }
}
