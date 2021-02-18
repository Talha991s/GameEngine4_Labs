using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Character;
using Weapon;
using Character.UI;
using System;

namespace Weapon
{
    [Serializable]
    public struct WeaponStats
    {
        public string Name;
        public float Damage;
        public int BulletInClip;
        public int ClipSize;
        public int TotalBulletAvailable;

        public float FireStartsDelay;
        public float FireRate;
        public float FireDistance;
        public bool Repeating;

        public LayerMask WeaponHitLayer;
    }
    public class WeaponComponent : MonoBehaviour
    {
        //public Transform handposition;
        public Transform GripLocation => GripIKLocation;
        [SerializeField] private Transform GripIKLocation;

        public bool Firing { get; private set; }

        [SerializeField] protected WeaponStats WeaponStats;

        protected WeaponHolder WeaponHolder;
        protected Crosshair Crosshair;

        public void Initialize(WeaponHolder weaponHolder, Crosshair crosshair)
        {
            WeaponHolder = weaponHolder;
            Crosshair = crosshair;
        }
        public virtual void StartFiring()
        {
            Firing = true;
            if (WeaponStats.Repeating)
            {
                InvokeRepeating(nameof(FireWeapon), WeaponStats.FireStartsDelay, WeaponStats.FireRate);
            }
            else
            {
                FireWeapon();
            }
        }
        public virtual void StopFiring()
        {
            Firing = false;
            CancelInvoke(nameof(FireWeapon));
        }
        protected virtual void FireWeapon()
        {

        }
    }
}
