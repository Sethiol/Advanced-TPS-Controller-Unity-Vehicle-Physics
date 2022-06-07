using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadWeapon : MonoBehaviour
{
    [SerializeField] private Animator rigController;
    private PlayerControls Controls;
    public WeaponAnimationEvents animationEvents;
    private ActiveWeapon activeWeapon;
    public Transform lefthand;
    public AmmoWidget ammoWidget;
    GameObject magazineHand;
    private void Start()
    {
        activeWeapon = GetComponent<ActiveWeapon>();
        animationEvents.WeaponAnimationEvent.AddListener(OnAnimationEvent);
        Controls = new PlayerControls();
        Controls.Enable();
        Controls.Keyboard.Reload.performed += ctx =>
        {
            GunController weapon = activeWeapon.GetActiveWeapon();
            if (weapon && weapon.ammoCount != weapon.ClipSize && weapon.WeaponSlotType.ToString() != "Axe")
            rigController.SetTrigger("reload_weapon");
        };
    }
    private void Update()
    {
        GunController weapon = activeWeapon.GetActiveWeapon();
        if (weapon && weapon.ammoCount <= 0 && weapon.WeaponSlotType.ToString() != "Axe" && weapon.WeaponSlotType.ToString() != "Knife")
        {
            rigController.SetTrigger("reload_weapon");
        }
        if (weapon)
        {
            ammoWidget.Refresh(weapon.ammoCount, weapon.ClipSize, weapon.WeaponSlotType.ToString());
        }
    }
    void OnAnimationEvent(string eventName)
    {
        switch (eventName)
        {
            case "detach_magazine":
                DetachMagazine();
                break;
            case "drop_magazine":
                DropMagazine();
                break;
            case "refill_magazine":
                Refillagazine();
                break;
            case "attach_magazine":
                AttachMagazine();
                break;
        }
    }

    private void AttachMagazine()
    {
        GunController weapon = activeWeapon.GetActiveWeapon();
        weapon.Magazine.SetActive(true);
        Destroy(magazineHand);
        weapon.ammoCount = weapon.ClipSize;
        rigController.ResetTrigger("reload_weapon");
        ammoWidget.Refresh(weapon.ammoCount, weapon.ClipSize, weapon.WeaponSlotType.ToString());
    }

    private void Refillagazine()
    {
        magazineHand.SetActive(true);
    }

    private void DropMagazine()
    {
        GameObject droppedMagazine = Instantiate(magazineHand, magazineHand.transform.position, magazineHand.transform.rotation);
        droppedMagazine.AddComponent<Rigidbody>();
        droppedMagazine.GetComponent<Rigidbody>().interpolation = RigidbodyInterpolation.Interpolate;
        droppedMagazine.AddComponent<BoxCollider>();
        magazineHand.SetActive(false);
        StartCoroutine(DestroyClip(droppedMagazine));
    }

    private void DetachMagazine()
    {
        GunController weapon = activeWeapon.GetActiveWeapon();
        magazineHand = Instantiate(weapon.Magazine, lefthand, true);
        weapon.Magazine.SetActive(false);
    }
    IEnumerator DestroyClip(GameObject clip)
    {
        yield return new WaitForSeconds(7f);
        Destroy(clip.gameObject);
    }
}
