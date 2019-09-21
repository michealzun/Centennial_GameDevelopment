using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FireCloud.Weapon;
using UnityEngine.UI;
using FireCloud.Entity;
using FireCloud.Managers;
using FireCloud.Mission;
public class WeaponController : MonoBehaviour
{
    [HideInInspector]
    public PlayerController PlayerController;

    public int SelectedWeaponIndex = -1;
    public WeaponData[] AvailableWeaponData;
    public Weapon[] Weapons;
    
    public HUDManager hudManager;

    public SpriteRenderer GunSpriteRenderer;
    public Transform BulletSpawn;

    private Camera _cam;

    private bool _sniping = false;

    private Animator _animator;

    void Start()
    {
        PlayerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();

        _cam = Camera.main;
        Weapons = new Weapon[2];
        Weapons[0] = new Weapon(this.gameObject, WeaponData.Build(GameManager.Instance.Profile.weapon1, AvailableWeaponData));
        Weapons[1] = new Weapon(this.gameObject, WeaponData.Build(GameManager.Instance.Profile.weapon2, AvailableWeaponData));
        SelectedWeaponIndex = 0;

        hudManager.UpdateWeaponGUI(this);
    }

    // Update is called once per frame
    void Update()
    {
        if(Weapons.Length > 0)
        {
            CheckSwitchWeapon();
            CheckReload();
            if (Weapons[SelectedWeaponIndex].WeaponType == FireCloud.Weapon.WeaponType.Sniper)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    if (!_sniping)
                    {
                        _sniping = true;
                        _cam.GetComponent<cameraFollow>().targetSize = 20;
                    }
                    else
                    {
                        _sniping = false;
                        _cam.GetComponent<cameraFollow>().targetSize = 10;
                    }
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (Weapons.Length > 0)
        {
            CheckFire();
        }
    }

    public void CheckSwitchWeapon()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            CancelReload();
            SelectedWeaponIndex++;
            if (SelectedWeaponIndex >= Weapons.Length)
            {
                SelectedWeaponIndex = 0;
            }
        }
        else if(Input.mouseScrollDelta.y > 0)
        {
            CancelReload();
            SelectedWeaponIndex--;
            if (SelectedWeaponIndex < 0)
            {
                SelectedWeaponIndex = Weapons.Length - 1;
            }
        }
        if(Weapons[SelectedWeaponIndex].WeaponType != FireCloud.Weapon.WeaponType.Sniper)
        {
            _cam.GetComponent<cameraFollow>().targetSize = 10;
            _sniping = false;
        }
        hudManager.UpdateWeaponGUI(this);
    }

    void CheckFire()
    {
        if(SelectedWeaponIndex != -1 && Weapons[SelectedWeaponIndex] != null)
        {
            if (Input.GetMouseButton(0))
            {
                CancelReload();
                Vector3 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                Vector3 dir = (target - this.transform.position).normalized;
                Weapons[SelectedWeaponIndex].Fire(BulletSpawn.position, dir);
                if(Weapons[SelectedWeaponIndex].WeaponType == FireCloud.Weapon.WeaponType.Sniper)
                {
                    RaycastHit2D[] hits = Physics2D.LinecastAll(this.transform.position, this.transform.position + dir * this.Weapons[SelectedWeaponIndex].Range);
                    if(hits[1].collider.gameObject != null)
                    {
                        if (hits[1].collider.gameObject.GetComponent<MissionTarget>() != null)
                        {
                            hits[1].collider.gameObject.GetComponent<MissionTarget>().OnDamage((int)Weapons[SelectedWeaponIndex].Damage);
                        }
                    }
                }
                hudManager.UpdateWeaponGUI(this);
            }
            Weapons[SelectedWeaponIndex].FireCooldown += Time.deltaTime;
        }
    }

    /// <summary>
    /// Check user input for reload
    /// </summary>
    void CheckReload()
    {
        if (Input.GetKeyDown(KeyCode.R) && !Weapons[SelectedWeaponIndex].IsReloading && Weapons[SelectedWeaponIndex].CanReload)
        {
            StartCoroutine("Reload");
        }
        if (Weapons[SelectedWeaponIndex].IsReloading)
        {
            Weapons[SelectedWeaponIndex].ReloadTimer -= Time.deltaTime;
            hudManager.UpdateWeaponReloadGUI(Weapons[SelectedWeaponIndex]);
        }
    }
    
    /// <summary>
    /// Reload the weapon after time
    /// </summary>
    /// <returns></returns>
    IEnumerator Reload()
    {
        this._animator.SetBool("IsReloading", true);
        Weapons[SelectedWeaponIndex].IsReloading = true;
        Weapons[SelectedWeaponIndex].ReloadTimer = Weapons[SelectedWeaponIndex].ReloadTime;
        yield return new WaitForSeconds(Weapons[SelectedWeaponIndex].ReloadTime);
        Weapons[SelectedWeaponIndex].Reload();
        Weapons[SelectedWeaponIndex].IsReloading = false;
        this._animator.SetBool("IsReloading", false);
        hudManager.UpdateWeaponGUI(this);
    }

    void CancelReload()
    {
        if (Weapons[SelectedWeaponIndex].IsReloading)
        {
            this._animator.SetBool("IsReloading", false);
            StopCoroutine("Reload");
            Weapons[SelectedWeaponIndex].IsReloading = false;
            Weapons[SelectedWeaponIndex].ReloadTimer = 0;
            hudManager.UpdateWeaponReloadGUI(Weapons[SelectedWeaponIndex], true);
        }
    }
}
