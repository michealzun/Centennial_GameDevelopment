using UnityEngine;
using System.Collections;

namespace FireCloud.Entity
{
    public enum Attribute { HP, MP, Speed, FireRate }
    public class EntityAttribute : MonoBehaviour
    {
        public float baseHp = 100;
        public float hp;
        public float baseMp = 100;
        public float mp;


        public float baseSpeed = 50;
        public float speed;
        public float speedMultiplier = 1;

        public float baseFireRate = 0.2f;
        public float fireRate;
        public float fireRateMultiplier = 1;

        public float baseRegRate = 1;
        public float regRate;
        public float regRateMultiplier = 1;

        public float damageMultiplier = 1;

        public float blockDamageCount = 0;

        public Vector3 facingDirection;

        public float dashForce = 100;

        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            this.hp = baseHp;
            this.mp = baseMp;
            this.speed = baseSpeed;
            this.fireRate = baseFireRate;
            this.regRate = baseRegRate;
            this.facingDirection = Vector3.up;
        }

        public void Damage(float damage)
        {
            this.hp -= damage;
        }

        public void HealthReg(float interval, float amount)
        {
            StartCoroutine(RegOvertime(interval, amount));
        }

        public void AddBuff(Attribute attribute, float value, float duration)
        {
            if(duration > 0)
            {
                StartCoroutine(BuffTimer(attribute, value, duration));
            }
            else
            {
                switch (attribute)
                {
                    case Attribute.HP:
                        baseHp = baseHp * value;
                        hp = baseHp;
                        break;
                    case Attribute.MP:
                        baseMp = baseMp * value;
                        mp = baseMp;
                        break;
                    case Attribute.Speed:
                        speedMultiplier = value;
                        break;
                    case Attribute.FireRate:
                        fireRateMultiplier = value;
                        break;
                }
            }
        }

        IEnumerator BuffTimer(Attribute attribute, float value, float duration)
        {
            float lastValue = 0;
            switch (attribute)
            {
                case Attribute.FireRate:
                    lastValue = fireRateMultiplier;
                    fireRateMultiplier = value;
                    StartCoroutine(DrainOvertime(1, 1, 10));
                    break;
            }
            yield return new WaitForSeconds(duration);
            switch (attribute)
            {
                case Attribute.FireRate:
                    fireRateMultiplier = lastValue;
                    break;
            }
        }

        public void KnockBack(Vector2 pos, float force)
        {
            Vector2 dir = new Vector2(this.transform.position.x - pos.x, this.transform.position.y - pos.y);
            rb.AddForce(dir.normalized * force, ForceMode2D.Impulse);
        }

        /// <summary>
        /// Drain health over time based on amount per tick and total duration
        /// </summary>
        /// <param name="amount">Damage Per Tick</param>
        /// <param name="interval">Interval in seconds</param>
        /// <param name="duration">Total duration in seconds</param>
        /// <returns></returns>
        IEnumerator DrainOvertime(float amount, float interval, float duration)
        {
            float passedTime = 0;
            while(passedTime < duration)
            {
                yield return new WaitForSeconds(interval);
                passedTime += interval;
                hp -= amount;
            }
        }

        IEnumerator RegOvertime(float interval, float amount)
        {
            float regAmount = 0;
            while(regAmount <= amount)
            {
                regAmount += amount;
                hp += amount;
                yield return new WaitForSeconds(interval);
            }
        }
    }
}
