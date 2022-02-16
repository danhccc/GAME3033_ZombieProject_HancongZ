using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponComponent : MonoBehaviour
{
    public Transform gripLocation;
    public WeaponStats weaponStats;
    protected WeaponHolder weaponHolder;
    [SerializeField]
    protected ParticleSystem firingEffect;

    public bool isFiring;
    public bool isReloading;


    protected Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    public void Initialized(WeaponHolder _weaponHolder)
    {
        weaponHolder = _weaponHolder;
    }

    public virtual void StartFiringWeapon()
    {
        isFiring = true;
        if (weaponStats.repeating)
        {
            // fire weapon
            InvokeRepeating(nameof(FireWeapon), weaponStats.fireStartDelay, weaponStats.fireRate);
        }
        else
        {
            FireWeapon();
        }
    }

    public virtual void StopFiringWeapon()
    {
        isFiring = false;
        CancelInvoke(nameof(FireWeapon));
        if (firingEffect && firingEffect.isPlaying)
        {
            firingEffect.Stop();
        }
    }

    protected virtual void FireWeapon()
    {
        print("Firing Weapon!");
        weaponStats.bulletsInClip--;
        print(weaponStats.bulletsInClip);
    }

    public virtual void StartReloading()
    {
        isReloading = true;
        ReloadWeapon();
    }

    public virtual void StopReloading()
    {
        isReloading = false;
    }

    // Set ammo here
    protected virtual void ReloadWeapon()
    {
        // Check to see if there is a firing effect and stop it
        if (firingEffect && firingEffect.isPlaying)
        {
            firingEffect.Stop();
        }

        int bulletsToReload = weaponStats.clipSize - weaponStats.totalBullets;
        if (bulletsToReload < 0)
        {
            weaponStats.totalBullets -= (weaponStats.clipSize - weaponStats.bulletsInClip);
            weaponStats.bulletsInClip = weaponStats.clipSize;
        }
        else
        {
            weaponStats.bulletsInClip = weaponStats.totalBullets;
            weaponStats.totalBullets = 0;
        }
    }

}

/// <summary>
/// /////////////////////////////////////////////////////////////////////////////////
/// </summary>

public enum WeaponType
{
    None, Pistol, MachineGun
}

public enum WeaponFiringPattern
{
    SemiAuto, FullAuto, ThreeShotBurst, FiveShotBurst
}

[System.Serializable]
public struct WeaponStats
{
    public WeaponType weaponType;
    public WeaponFiringPattern firingPattern;
    public string weaponName;
    public float damage;
    public int bulletsInClip;
    public int clipSize;
    public float fireStartDelay;
    public float fireRate;
    public float fireDistance;
    public bool repeating;
    public LayerMask weaponHitLayers;
    public int totalBullets;
}
