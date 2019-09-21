using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class playerContoller : MonoBehaviour
{
    [SerializeField]
    Image HpBar;
    Progress gameProgress;
    Rigidbody2D rb;
    Animator anim;
    GameObject heal;

    public bool alive = true;
    public bool moveLock = false;
    public Vector2 inputVec;
    Vector2 prevInputVec;
    public bool hpLock = false;
    public float hp = 100;
    public float lightCoolDown = 0;
    public float specialCoolDown = 0;
    int shootCount=0;
    public void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        gameProgress = GameObject.Find("Progress").GetComponent<Progress>();
        heal = transform.Find("heal").gameObject;
        heal.SetActive(false);
    }

    public void Update()
    {

        HpBar.fillAmount = Mathf.Lerp(HpBar.fillAmount, hp / 100f, Time.deltaTime * 5);
        if (lightCoolDown > 0)//update cooldown
        {
            lightCoolDown -= Time.deltaTime;
        }
        else
        {
            lightCoolDown = 0;
        }
        if (specialCoolDown > 0)//update spcial attack cooldown
        {
            specialCoolDown -= Time.deltaTime;
        }
        else
        {
            specialCoolDown = 0;
        }
        if (inputVec.x != 0 || inputVec.y != 0) { prevInputVec = inputVec; }
        if (!moveLock)//player movement
        {
            anim.SetFloat("Hor", prevInputVec.x);
            anim.SetFloat("Ver", prevInputVec.y);
            rb.velocity += inputVec;
        }
    }


    public void Damage(float hpDelta)
    {
        if (!hpLock && alive)
        {
            hp -= hpDelta;


            if (hp < 0)
            {

                alive = false;
            }
            if (hp > 100)
            {
                hp = 100;
            }

        }
    }
    public void KnockBack(Vector2 pos, float force)
    {
        Vector2 dir = new Vector2(this.transform.position.x - pos.x, this.transform.position.y - pos.y);
        rb.AddForce(dir.normalized * force, ForceMode2D.Impulse);
    }
    public void Attack(string type)
    {

        switch (type)
        {
            case "pipeLight":
                if (gameProgress.gearUnlock[0] && lightCoolDown == 0)//check if weapon unlocked
                {
                    Instantiate(Resources.Load<GameObject>("Prefab/pipeLightAttack"), this.transform.position + new Vector3(prevInputVec.x * 1.5f, prevInputVec.y * 1.5f, 0), Quaternion.Euler(0, 0, Mathf.Atan2(prevInputVec.y, prevInputVec.x) * Mathf.Rad2Deg - 90));
                    lightCoolDown += 0.3f;
                }
                break;
            case "dash":
                if (gameProgress.gearUnlock[0] && specialCoolDown == 0 && !moveLock)
                {//check if weapon unlocked
                    Instantiate(Resources.Load<GameObject>("Prefab/pipeSpecialAttack"), this.transform.position + new Vector3(-inputVec.x * 1.5f, -inputVec.y * 1.5f, 0), Quaternion.Euler(0, 0, Mathf.Atan2(inputVec.y, inputVec.x) * Mathf.Rad2Deg - 90));
                    rb.velocity += inputVec * 20;
                    specialCoolDown += 1.5f;
                }
                break;
            case "pistolLight":
                if (gameProgress.gearUnlock[1] && lightCoolDown == 0)//check if weapon unlocked
                {
                    Instantiate(Resources.Load<GameObject>("Prefab/bullet"), this.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(prevInputVec.y, prevInputVec.x) * Mathf.Rad2Deg - 90));
                    shootCount++;
                    lightCoolDown = 0.5f;
                }
                break;
            case "pistolSpecial":
                if (gameProgress.gearUnlock[1] && lightCoolDown <0.4f && shootCount > 0 && shootCount<5)
                {
                    moveLock = true;
                    Instantiate(Resources.Load<GameObject>("Prefab/bullet"), this.transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(prevInputVec.y, prevInputVec.x) * Mathf.Rad2Deg - 90 + Random.Range(-10, 10)));
                    shootCount++;
                    lightCoolDown = 0.5f;
                }
                break;
            case "pistolEnd":
                if (gameProgress.gearUnlock[1])
                {
                    moveLock = false;
                    if(shootCount > 0)
                    {
                        lightCoolDown += 1 + 0.25f * shootCount;
                    }
                    shootCount = 0;
                }
                break;
            case "HealStart":
                if (gameProgress.gearUnlock[2])
                {
                    heal.SetActive(true);
                    moveLock = true;
                }
                break;
            case "Heal":
                if (gameProgress.gearUnlock[2])
                {
                    moveLock = true;
                    Damage(-0.1f);
                }
                break;
            case "HealEnd":
                if (gameProgress.gearUnlock[2])
                {
                    moveLock = false;
                    heal.SetActive(false);
                }
                break;
            default:
                break;
        }

    }

}
