﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Shooting : MonoBehaviour
    {
        public int weaponIndex = 0;

        private Weapon[] attachedWeapons;

        private Rigidbody2D rigid;

        void Awake()
        {
            rigid = GetComponent<Rigidbody2D>();
        }

        void Start()
        {
            // Get all attachedWeapons in children
            attachedWeapons = GetComponentsInChildren<Weapon>();
            // Set the first weapon
            SwitchWeapon(weaponIndex);
        }

        void Update()
        {
            CheckFire();
            WeaponSwitching();
        }

        // Checks if the user pressed to fire the current weapon
        void CheckFire()
        {
            // Set currentWeapon to attachedweapons[weaponIndex]
            Weapon currentweapon = attachedWeapons[weaponIndex];
            // IF user pressed down space
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Fire currentWeapon
                currentweapon.Fire();
                // Add recoil to player from weapon's recoil
                rigid.AddForce(-transform.right * currentweapon.recoil, ForceMode2D.Impulse);
            }
        }

        // Handles weapon switching when pressing keys
        void WeaponSwitching()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                CycleWeapon(1);
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                CycleWeapon(-1);
            }
        }

        void CycleWeapon(int amount)
        {
            // SET desiredIndex to weaponIndex + amount
            int desiredIndex = weaponIndex + amount;
            // IF desiredIndex > length of weapons
            if (desiredIndex >= attachedWeapons.Length)
            {
                // SET desiredIndex to zero
                desiredIndex = 0;
            }
            // ELSE If desiredIndex < 0
            else if (desiredIndex < 0)
            {
                // SET desiredIndex to length of weapons - 1
                desiredIndex = attachedWeapons.Length - 1;
            }
            // SET weaponIndex to desiredIndex
            weaponIndex = desiredIndex;
            // SwitchWeapon() to weaponIndex
            SwitchWeapon(weaponIndex);
        }

        Weapon SwitchWeapon(int weaponIndex)
        {
            // Check if index is outside bounds
            if(weaponIndex < 0 || weaponIndex >= attachedWeapons.Length)
            {
                // Return null weapon as error
                return null;
            }
            // Looping through all weapon
            for (int i = 0; i < attachedWeapons.Length; i++)
            {
                // Get the weapon at i
                Weapon w = attachedWeapons[i];
                // IF i == weaponIndex
                if (i == weaponIndex)
                {
                    // Activate the weapon
                    w.gameObject.SetActive(true);
                }
                // ELSE
                else
                {
                    // Deactivate the true
                    w.gameObject.SetActive(false);
                }
            }
            // Return seleted weapon
            return attachedWeapons[weaponIndex];
        }
    }
}
