using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using FireCloud.Perk;

namespace FireCloud.Managers
{
    public class HUDManager : MonoBehaviour
    {
        // Status
        public Image HPBar;
        public Image MPBar;

        // Perk
        public PerkController PerkController;

        public Image Perk1Icon;
        public string Perk1Key;
        public Text TextPerk1Key;
        public Text TextPerk1Cooldown;

        public Image Perk2Icon;
        public string Perk2Key;
        public Text TextPerk2Key;
        public Text TextPerk2Cooldown;

        public Image Perk3Icon;
        public string Perk3Key;
        public Text TextPerk3Key;
        public Text TextPerk3Cooldown;

        // Weapon
        public WeaponController WeaponController;

        public Image WeaponIcon;
        public Text TextCurrentAmmo;
        public Text TextTotalAmmo;

        public void UpdatePerkGUI(PerkController perkController)
        {
            Perk1Icon.sprite = PerkController.Perk1.Data.Thumbnail;
            Perk2Icon.sprite = PerkController.Perk2.Data.Thumbnail;
            Perk3Icon.sprite = PerkController.Perk3.Data.Thumbnail;

            TextPerk1Key.text = PerkController.Perk1.PerkType == Perk.PerkType.Active ? Perk1Key : "";
            TextPerk2Key.text = PerkController.Perk1.PerkType == Perk.PerkType.Active ? Perk2Key : "";
            TextPerk3Key.text = PerkController.Perk1.PerkType == Perk.PerkType.Active ? Perk3Key : "";

            UpdatePerkCooldownGUI(Perk1Icon, PerkController.Perk1);
            UpdatePerkCooldownGUI(Perk2Icon, PerkController.Perk2);
            UpdatePerkCooldownGUI(Perk3Icon, PerkController.Perk3);
        }

        public void UpdateWeaponGUI(WeaponController weaponController)
        {
            WeaponIcon.sprite = weaponController.Weapons[weaponController.SelectedWeaponIndex].Data.Thumbnail;
            TextCurrentAmmo.text = weaponController.Weapons[weaponController.SelectedWeaponIndex].CurrentAmmo.ToString();
            TextTotalAmmo.text = weaponController.Weapons[weaponController.SelectedWeaponIndex].TotalAmmo.ToString();
            weaponController.GunSpriteRenderer.sprite = weaponController.Weapons[weaponController.SelectedWeaponIndex].Data.GunSprite;
        }

        public void UpdateWeaponReloadGUI(Weapon.Weapon weapon, bool disableFlash = false)
        {
            float amountBeforeUpdate = WeaponIcon.fillAmount;
            float amount = 1 - weapon.ReloadTimer / weapon.ReloadTime;
            WeaponIcon.fillAmount = amount;
            if (disableFlash)
            {
                return;
            }
            if (amount != amountBeforeUpdate && amount >= 1)
            {
                FlashIcon(WeaponIcon);
            }
        }

        private void UpdatePerkCooldownGUI(Image icon, Perk.Perk perk)
        {
            float amountBeforeUpdate = icon.fillAmount;
            float amount = 1 - perk.CurrentCooldown / perk.BaseCooldown;
            icon.fillAmount = amount;
            if (amount != amountBeforeUpdate && amount >= 1)
            {
                FlashIcon(icon);
            }
        }

        private void FlashIcon(Image icon)
        {
            StartCoroutine(OnCooldownReady(icon));
        }

        IEnumerator OnCooldownReady(Image icon)
        {
            float flashDuration = 1.0f;
            int flashCount = 3;
            float flashTime = flashDuration / 2 / flashCount;
            Color c = icon.color;
            for(int i = 0; i < flashCount; i++)
            {
                c.a = 0.5f;
                icon.color = c;
                yield return new WaitForSeconds(flashTime);
                c.a = 1f;
                icon.color = c;
                yield return new WaitForSeconds(flashTime);
            }
        }
    }
}
