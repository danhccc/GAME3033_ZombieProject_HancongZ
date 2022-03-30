using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47Component : WeaponComponent
{
    Vector3 hitLocation;
    protected override void FireWeapon()
    {

        if (weaponStats.bulletsInClip > 0 && !isReloading && !weaponHolder.playerController.isRunning)
        {
            base.FireWeapon();

            if (firingEffect)
            {
                firingEffect.Play();
            }

            Ray screenRay = mainCamera.ViewportPointToRay(new Vector2(0.5f, 0.5f));
            if (Physics.Raycast(screenRay, out RaycastHit hit, weaponStats.fireDistance, weaponStats.weaponHitLayers))
            {
                hitLocation = hit.point;
                DealDamage(hit);
                Vector3 hitDirection = hit.point - mainCamera.transform.position;
                Debug.DrawRay(mainCamera.transform.position, hitDirection.normalized * weaponStats.fireDistance, Color.red, 1);
            }
        }
        else if (weaponStats.bulletsInClip <= 0)
        {
            // Trigger reload when no ammo left
            weaponHolder.StartReloading();
        }
    }

    void DealDamage(RaycastHit hitInfo)
    {
        IDamageable damageable = hitInfo.collider.GetComponent<IDamageable>();
        damageable?.TakeDamage(weaponStats.damage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(hitLocation, 0.1f);
    }
}
