using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Enemy : MonoBehaviour {

    public bool HpLock;
    public float hp;
    public float maxhp;
    public bool deleteParent=false;
    [SerializeField]
    Image HpBar;
    public void Start()
    {
        maxhp = hp;
    }
    public void Update()
    {
        if (HpBar != null)
        { 
        HpBar.fillAmount = Mathf.Lerp(HpBar.fillAmount, hp / maxhp, Time.deltaTime*10);
        }
    }
    public void Damage(int amount)
    {
        hp -= amount;
        if (hp <= 0)
        {
            if (gameObject.name == "boss")
            {
                Instantiate(Resources.Load<GameObject>("Prefab/bossDie"), this.transform.position, Quaternion.Euler(0, 0, 0));
            }

            if (deleteParent)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
