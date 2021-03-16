using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Weapons;
using Systems.Health;

public class PlayerEvents
{
    public delegate void OnWeaponEquippedEvent(WeaponComponent weaponComponent);

    public static event OnWeaponEquippedEvent OnWeaponEquipped;

    public static void Invoke_OnWeaponEquipped(WeaponComponent weaponComponent)
    {
        OnWeaponEquipped?.Invoke(weaponComponent);
    }

    //Health

    public delegate void OnHealthInitializeEvent(HealthComponent healthComponent);

    public static event OnHealthInitializeEvent OnHealthinitialized;

    public static void Invoke_OnHealthInitialize(HealthComponent healthComponent)
    {
        OnHealthinitialized?.Invoke(healthComponent);
    }


}
