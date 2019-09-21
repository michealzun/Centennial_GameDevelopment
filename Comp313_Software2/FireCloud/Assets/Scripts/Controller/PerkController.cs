using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FireCloud.Perk;
using FireCloud.Managers;

public class PerkController : MonoBehaviour
{
    [HideInInspector]
    public PlayerController PlayerController;

    public HUDManager HUDManager;
    public PerkData[] AvailablePerkData;
    public Perk Perk1;
    public Perk Perk2;
    public Perk Perk3;

    private CastEventArgs _perk1Args;
    private CastEventArgs _perk2Args;
    private CastEventArgs _perk3Args;

    void Start()
    {
        PlayerController = GetComponent<PlayerController>();

        Perk1 = new Perk(this.gameObject, PerkData.Get(GameManager.Instance.Profile.perk1, AvailablePerkData));
        Perk2 = new Perk(this.gameObject, PerkData.Get(GameManager.Instance.Profile.perk2, AvailablePerkData));
        Perk3 = new Perk(this.gameObject, PerkData.Get(GameManager.Instance.Profile.perk3, AvailablePerkData));

        _perk1Args = new CastEventArgs { KeyCode = KeyCode.Alpha1 };
        _perk2Args = new CastEventArgs { KeyCode = KeyCode.Alpha2 };
        _perk3Args = new CastEventArgs { KeyCode = KeyCode.Alpha3 };

        HUDManager.UpdatePerkGUI(this);
    }

    void Update()
    {
        OnCastPerk();
    }

    private void FixedUpdate()
    {
        UpdatePerkCooldown();
    }

    public void OnCastPerk()
    {
        if (Input.GetKeyDown(_perk1Args.KeyCode) && Perk1.PerkType == PerkType.Active)
        {
            Perk1.Cast(gameObject, _perk1Args);
        }
        if (Input.GetKeyDown(_perk2Args.KeyCode) && Perk2.PerkType == PerkType.Active)
        {
            Perk2.Cast(gameObject, _perk2Args);
        }
        if (Input.GetKeyDown(_perk3Args.KeyCode) && Perk3.PerkType == PerkType.Active)
        {
            Perk3.Cast(gameObject, _perk3Args);
        }
    }

    public void UpdatePerkCooldown()
    {
        Perk1.UpdateCooldown();
        Perk2.UpdateCooldown();
        Perk3.UpdateCooldown();

        HUDManager.UpdatePerkGUI(this);
    }
}
