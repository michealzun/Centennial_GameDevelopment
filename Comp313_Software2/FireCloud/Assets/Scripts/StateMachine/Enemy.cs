using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FireCloud.Entity;

[System.Serializable]
public class Enemy : MonoBehaviour {
    public string mode = null;
    public bool HpLock;
    public bool deleteParent=false;
    public GameObject canvas;
    public Image HpBar;

    private EntityAttribute attributes;

    public void Start()
    {
        attributes = GetComponent<EntityAttribute>();
        canvas = this.transform.GetChild(0).gameObject;
    }
    public void Update()
    {
        canvas.transform.rotation = Quaternion.Euler(0,0,-this.transform.rotation.z);
        if (HpBar != null)
        { 
            HpBar.fillAmount = Mathf.Lerp(HpBar.fillAmount, attributes.hp / attributes.baseHp, Time.deltaTime * 10);
        }
    }
    public void Damage(int amount)
    {
        attributes.hp -= amount;
        if (attributes.hp <= 0)
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
