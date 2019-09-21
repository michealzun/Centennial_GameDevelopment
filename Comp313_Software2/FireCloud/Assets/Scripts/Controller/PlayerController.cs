using UnityEngine;
using FireCloud.Perk;
using FireCloud.Entity;
using System.Collections;
using UnityEngine.UI;
using FireCloud.Weapon;
using FireCloud.Mission;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public PerkController PerkController;
    [HideInInspector]
    public WeaponController WeaponController;
    [HideInInspector]
    public MissionManager MissionManager;

    public Image hpBar;
    public Image manaBar;

    public bool IsAlive
    {
        get
        {
            return this.attributes.hp > 0;
        }
    }

    Camera cam;

    private Rigidbody2D rb;
    
    private EntityAttribute attributes;

    void Start()
    {
        PerkController = GetComponent<PerkController>();
        WeaponController = GetComponent<WeaponController>();
        rb = GetComponent<Rigidbody2D>();

        attributes = GetComponent<EntityAttribute>();

        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");
       
        SetForwardDirection();

        Vector2 movement = new Vector2(inputX, inputY);

        rb.AddForce(movement * (attributes.baseSpeed * attributes.speedMultiplier) * Time.fixedDeltaTime);

        UpdatePlayerRotation();
        
        hpBar.fillAmount = Mathf.Lerp(hpBar.fillAmount, this.attributes.hp / this.attributes.baseHp, Time.deltaTime);
        manaBar.fillAmount = Mathf.Lerp(manaBar.fillAmount, this.attributes.mp / this.attributes.baseMp, Time.deltaTime);

        if(this.attributes.hp <= 0)
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(2);
        }
    }

    /// <summary>
    /// Set the facing direction of the player based on the inputs
    /// </summary>
    void SetForwardDirection()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            this.attributes.facingDirection = Vector3.left;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            this.attributes.facingDirection = Vector3.right;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            this.attributes.facingDirection = Vector3.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            this.attributes.facingDirection = Vector3.down;
        }
    }

    /// <summary>
    /// Update the player direction based on the mouse cursor
    /// </summary>
    void UpdatePlayerRotation()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        float radians = Mathf.Atan2(target.y - this.transform.position.y, target.x - this.transform.position.x);
        float degree = (180 / Mathf.PI) * radians;
        this.transform.rotation = Quaternion.Euler(0, 0, degree);
    }
}