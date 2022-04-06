using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Item/Weapon", order = 2)]
public class WeaponScriptable : EquippableScriptable
{
    public WeaponStats weaponStats;

    public override void UseItem(PlayerController playerController)
    {
        if (equipped)
        {
            // Unequip from inventory
            // Remove from controller
        }
        else
        {
            // Invoke OnWeaponEquipped from player here from inventory
            // Equip weapon from weapon holder on playerController
        }

        base.UseItem(playerController);
    }
}
