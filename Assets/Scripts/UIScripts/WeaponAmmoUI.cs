using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponAmmoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI weaponNameText;
    [SerializeField] TextMeshProUGUI currentAmmoText;
    [SerializeField] TextMeshProUGUI TotalAmmoText;

    [SerializeField] WeaponComponent weaponComponent;

    /// <summary>
    /// Set up events for onWeaponEquipped to handle the weapon component we grab.
    /// </summary>
    private void OnEnable()
    {
        PlayerEvents.OnWeaponEquipped += OnWeaponEquipped;
    }

    private void OnDisable()
    {
        PlayerEvents.OnWeaponEquipped -= OnWeaponEquipped;
    }

    void OnWeaponEquipped(WeaponComponent _weaponComponent)
    {
        weaponComponent = _weaponComponent;
    }

    void Update()
    {
    
            if (!weaponComponent) return;

            weaponNameText.text = weaponComponent.weaponStats.weaponName;
            currentAmmoText.text = weaponComponent.weaponStats.bulletsInClip.ToString() + " /";
            TotalAmmoText.text = weaponComponent.weaponStats.totalBullets.ToString();
     
    }
}
