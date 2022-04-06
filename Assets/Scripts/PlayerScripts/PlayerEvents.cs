using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerEvents : MonoBehaviour
{
    public delegate void OnWeaponEquippedEvent(WeaponComponent weaponComponent);

    public static event OnWeaponEquippedEvent OnWeaponEquipped;

    public static void InvokeOnWeaponEquipped(WeaponComponent weaponComponent)
    {
        OnWeaponEquipped?.Invoke(weaponComponent);
    }

    public delegate void OnHealthInitializeEvent(HealthComponent healthComponent);

    public static event OnHealthInitializeEvent OnHealthInitialize;

    public static void InvokeOnHealthInitialized(HealthComponent healthComponent)
    {
        OnHealthInitialize?.Invoke(healthComponent);
    }
}