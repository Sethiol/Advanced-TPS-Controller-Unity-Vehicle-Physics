using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GunController weaponFab;
    private void OnTriggerEnter(Collider other)
    {
        ActiveWeapon activeWeapon = other.gameObject.GetComponent<ActiveWeapon>();
        if (activeWeapon)
        {
            GunController newWeapon = Instantiate(weaponFab);
            activeWeapon.Equip(newWeapon, true);
        }
    }
}
