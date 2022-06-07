using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Advanced TPS/ ActiveWeapon")]
public class ActiveWeapon : MonoBehaviour
{
    public enum WeaponSlot
    {
        SMG = 0,
        Pistol = 1,
        Axe = 2,
        Rifle = 3,
        Shotgun = 4,
        Sniper = 5,
        Knife = 6
    }
    [Header("Customizables")]
    public bool HideInventoryWeapons = false;
    [Header("Variables")]
    GunController[] Equipped_Weapons = new GunController[7];
    public int activeWeaponIndex;
    GunController currentWeapon;
    public Transform[] weaponSlots;
    public Transform WeaponLeftGrip;
    public Transform WeaponRightGrip;
    public Animator rigController;
    private Animator TPSLocomotion;
    private PlayerControls Controls;
    bool HolsteredWeapon;
    bool WasHolstered;
    bool RemoveWeaponCurrent;
    public TrailRenderer renderer;
    public AmmoWidget ammoWidget;
    WeaponAiming aiming;
    [SerializeField] private Cinemachine.CinemachineFreeLook playerCamera;
    public bool CancelAllMovement { get; set; }
    float punchcombo;
    // Start is called before the first frame update
    void Start()
    {
        punchcombo = 0;
        aiming = GetComponent<WeaponAiming>();
        activeWeaponIndex = 0;
        TPSLocomotion = GetComponent<Animator>();
        HolsteredWeapon = false;
        Controls = InputManager.inputActions;
        Controls.Enable();
        Controls.Keyboard.HolsterEquip.performed += ctx =>
        {
            if (GetComponent<AdvancedCharacterMovement>().state == CharacterState.Vehicle) { return; }
            var controller = FindObjectOfType<UIController>();
            if (controller.CancelAllMovement == true) { return; }
                bool isHolstered = rigController.GetBool("Holster_Weapon");
                HolsteredWeapon = !isHolstered;
                rigController.SetBool("Holster_Weapon", HolsteredWeapon);
        };
        Controls.Keyboard.MoveThrough.performed += ctx =>
            {
                if (GetComponent<AdvancedCharacterMovement>().state == CharacterState.Vehicle) { return; }
                var controller = FindObjectOfType<UIController>();
                if (controller.CancelAllMovement == true) { return; }
                int x = 0;
                for (int i = activeWeaponIndex; i < Equipped_Weapons.Length + 1; i++)
                {
                    x++;
                    if (i == Equipped_Weapons.Length) { i = 0; }
                    if (Equipped_Weapons[i] != null && i != activeWeaponIndex)
                    {
                        SetActiveWeapon((WeaponSlot)i);
                        return;
                    }
                    if (x == Equipped_Weapons.Length) { return; }
                }
            };
        Controls.Keyboard.MoveBack.performed += ctx =>
            {
                if (GetComponent<AdvancedCharacterMovement>().state == CharacterState.Vehicle) { return; }
                var controller = FindObjectOfType<UIController>();
                if (controller.CancelAllMovement == true) { return; }
                int x = 0;
                for (int i = activeWeaponIndex; i > -2; i--)
                {
                    x++;
                    if (i == -1) { i = Equipped_Weapons.Length - 1; }
                    if (Equipped_Weapons[i] != null && i != activeWeaponIndex)
                    {
                        SetActiveWeapon((WeaponSlot)i);
                        return;
                    }
                    if (x == Equipped_Weapons.Length) { return; }
                }
            };
        Controls.Keyboard.RemoveWeapon.performed += ctx =>
            {
                if (GetComponent<AdvancedCharacterMovement>().state == CharacterState.Vehicle) { return; }
                var controller = FindObjectOfType<UIController>();
                if (controller.CancelAllMovement == true) { return; }
                RemoveWeaponCurrent = true;
            };
        Controls.Keyboard.Shoot.started += ctx =>
         {
                if(GetComponent<AdvancedCharacterMovement>().state == CharacterState.Vehicle) { return; }
                GetComponent<AdvancedCharacterMovement>().IsRunning = false;
                GetComponent<AdvancedCharacterMovement>().IsCrouching = false;
                GetComponent<AdvancedCharacterMovement>().IsWalking = false;
                var controller = FindObjectOfType<UIController>();
                if (controller.CancelAllMovement == true) { return; }
                if (FindObjectOfType<UIController>().CancelAllMovement == true) { return; }
                if (currentWeapon != null && !HolsteredWeapon)
                {
                    if (currentWeapon.WeaponSlotType.ToString() == "Axe")
                    {
                     if(GetComponent<AdvancedCharacterMovement>().Crouched == true) { return; }
                        if (currentWeapon.AxeAttack == true) return;
                        currentWeapon.StartAxeAttack(TPSLocomotion, rigController);
                    }
                    else if (currentWeapon.WeaponSlotType.ToString() != "Knife")
                    {
                        currentWeapon.StartFiring();
                    }
                    else if (currentWeapon.WeaponSlotType.ToString() == "Knife")
                    {
                        currentWeapon.KnifeAttack(TPSLocomotion, rigController);
                    }
                }
                else if (currentWeapon != null && HolsteredWeapon || currentWeapon == null)
                {
                    if (punchcombo == 0)
                    {
                        punchcombo = 1;
                        StartPunchAttack(punchcombo);
                    }
                    else if (punchcombo == 1)
                    {
                        punchcombo = 2;
                        StartPunchAttack(punchcombo);
                    }
                    else if (punchcombo == 2)
                    {
                        punchcombo = 1;
                        StartPunchAttack(punchcombo);
                    }
                }
            };
        Controls.Keyboard.Shoot.canceled += ctx =>
            {
                if (GetComponent<AdvancedCharacterMovement>().state == CharacterState.Vehicle) { return; }
                var controller = FindObjectOfType<UIController>();
                if (controller.CancelAllMovement == true) { return; }
                if (FindObjectOfType<UIController>().CancelAllMovement == true) { return; }
                if (HolsteredWeapon) { return; }
                if (currentWeapon != null)
                {
                    if (currentWeapon.WeaponSlotType.ToString() == "Axe") { return; }
                    currentWeapon.StopFiring();
                }
            };
        rigController.updateMode = AnimatorUpdateMode.AnimatePhysics;
        rigController.cullingMode = AnimatorCullingMode.CullUpdateTransforms;
        rigController.cullingMode = AnimatorCullingMode.AlwaysAnimate;
        rigController.updateMode = AnimatorUpdateMode.Normal;
        GunController exsistingWeapon = GetComponentInChildren<GunController>();
        if (exsistingWeapon)
            Equip(exsistingWeapon, true);
    }
    void SetHolstered()
    {
        bool isHolstered = rigController.GetBool("Holster_Weapon");
        HolsteredWeapon = !isHolstered;
        rigController.SetBool("Holster_Weapon", HolsteredWeapon);
    }
    private void Update()
    {
        if (TPSLocomotion.GetCurrentAnimatorStateInfo(0).IsName("PunchRight") && TPSLocomotion.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f || TPSLocomotion.GetCurrentAnimatorStateInfo(0).IsName("PunchLeft") && TPSLocomotion.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f) { CancelAllMovement = true; } else
        {
            CancelAllMovement = false;
        }
        if (currentWeapon != null)
        {
            aiming.currentWeapon = currentWeapon.WeaponSlotType.ToString();
        }
        else
        {
            aiming.currentWeapon = "";
        }
        if (currentWeapon == null) { return; } else if (currentWeapon.AxeAttack) { CancelAllMovement = true; } else { CancelAllMovement = false; }
        var weapon = GetWeapon(activeWeaponIndex);
        currentWeapon = weapon;
        RemoveWeapon();
        if (currentWeapon == null) return;
        if (currentWeapon.isFiring)
        {
            weapon.UpdateFiring(Time.deltaTime);
        }
    }
    // Update is called once per frame
    void LateUpdate()
    {
        SetRigLayerWeight();
    }
    private void SetRigLayerWeight()
    {
        if (currentWeapon == null)
        {
            TPSLocomotion.SetLayerWeight(0, 1f);
            TPSLocomotion.SetLayerWeight(1, 0f);
            TPSLocomotion.SetLayerWeight(2, 0f);
            rigController.Play("Weapon_Unarmed");
            activeWeaponIndex = 0;
            return;
        }
        if (HolsteredWeapon && activeWeaponIndex == 0)
        {
            TPSLocomotion.SetLayerWeight(0, 1f);
            TPSLocomotion.SetLayerWeight(1, 0f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        if (HolsteredWeapon && activeWeaponIndex == 1)
        { 
            TPSLocomotion.SetLayerWeight(0, 1f);
            TPSLocomotion.SetLayerWeight(1, 0f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        if (HolsteredWeapon && activeWeaponIndex == 2)
        {
            TPSLocomotion.SetLayerWeight(0, 1f);
            TPSLocomotion.SetLayerWeight(1, 0f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        if (HolsteredWeapon && activeWeaponIndex == 3)
        {
            TPSLocomotion.SetLayerWeight(0, 1f);
            TPSLocomotion.SetLayerWeight(1, 0f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        if (HolsteredWeapon && activeWeaponIndex == 4)
        {
            TPSLocomotion.SetLayerWeight(0, 1f);
            TPSLocomotion.SetLayerWeight(1, 0f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        if (HolsteredWeapon && activeWeaponIndex == 5)
        {
            TPSLocomotion.SetLayerWeight(0, 1f);
            TPSLocomotion.SetLayerWeight(1, 0f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        if (HolsteredWeapon && activeWeaponIndex == 6)
        {
            TPSLocomotion.SetLayerWeight(0, 1f);
            TPSLocomotion.SetLayerWeight(1, 0f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        else if (!HolsteredWeapon && activeWeaponIndex == 2)
        {
            TPSLocomotion.SetLayerWeight(0, 0f);
            TPSLocomotion.SetLayerWeight(1, 0f);
            TPSLocomotion.SetLayerWeight(2, 1f);
        }
        else if (!HolsteredWeapon && activeWeaponIndex == 1)
        {
            TPSLocomotion.SetLayerWeight(0, 0f);
            TPSLocomotion.SetLayerWeight(1, 1f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        else if (!HolsteredWeapon && activeWeaponIndex == 0)
        {
            TPSLocomotion.SetLayerWeight(0, 0f);
            TPSLocomotion.SetLayerWeight(1, 1f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        else if (!HolsteredWeapon && activeWeaponIndex == 3)
        {
            TPSLocomotion.SetLayerWeight(0, 0f);
            TPSLocomotion.SetLayerWeight(1, 1f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        else if (!HolsteredWeapon && activeWeaponIndex == 4)
        {
            TPSLocomotion.SetLayerWeight(0, 0f);
            TPSLocomotion.SetLayerWeight(1, 1f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        else if (!HolsteredWeapon && activeWeaponIndex == 5)
        {
            TPSLocomotion.SetLayerWeight(0, 0f);
            TPSLocomotion.SetLayerWeight(1, 1f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        else if (!HolsteredWeapon && activeWeaponIndex == 6)
        {
            TPSLocomotion.SetLayerWeight(0, 0f);
            TPSLocomotion.SetLayerWeight(1, 1f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
        else
        {
            TPSLocomotion.SetLayerWeight(0, 1f);
            TPSLocomotion.SetLayerWeight(1, 0f);
            TPSLocomotion.SetLayerWeight(2, 0f);
        }
    }
    public void Equip(GunController newWeapon, bool destroy)
    {
        var controller = FindObjectOfType<UIController>();
        if (controller.CancelAllMovement == true) { return; }
        rigController.ResetTrigger("reload_Weapon");
        WasHolstered = HolsteredWeapon;
        SetHolstered();
        int weaponSlotIndex = (int)newWeapon.WeaponSlotType;
        var weapon = GetWeapon(weaponSlotIndex);
        if (destroy)
        {
            if (weapon)
            {
               Destroy(weapon.gameObject);
            }
        }
        weapon = newWeapon;
        currentWeapon = newWeapon;
        if(weapon.WeaponSlotType.ToString() != "Axe" && weapon.WeaponSlotType.ToString() != "Knife")
        {
            weapon.recoil.playerCamera = playerCamera;
            weapon.recoil.RigController = rigController;
        }
        weapon.transform.SetParent(weaponSlots[weaponSlotIndex], false);
        Equipped_Weapons[weaponSlotIndex] = weapon;
        ammoWidget.Refresh(weapon.ammoCount, weapon.ClipSize, weapon.WeaponSlotType.ToString());
        SetActiveWeapon(newWeapon.WeaponSlotType);
    }
    void SetActiveWeapon(WeaponSlot weaponSlot)
    {
        int holsterIndex = activeWeaponIndex;
        int activateIndex = (int)weaponSlot;
        if(holsterIndex == activateIndex)
        {
            holsterIndex = -1;
        }
        StartCoroutine(SwitchWeapon(holsterIndex, activateIndex));
    }
    private void EquipNewWeapon()
    {
        if (RemoveWeaponCurrent)
            return;
        var weapon = GetWeapon(activeWeaponIndex);
        if (weapon == null)
        {
            foreach (GunController controller in Equipped_Weapons)
            {
                if (controller != null)
                {
                    Equip(controller, false);
                }
            }
        }
        if (currentWeapon == null)
        {
            HolsteredWeapon = false;
        }
    }
    private void RemoveWeapon()
    {
        if (RemoveWeaponCurrent)
        {
            gameObject.GetComponent<WeaponAiming>().StopAiming();
            ammoWidget.Refresh(0, 0, null);
            RemoveWeaponCurrent = false;
            var weapon = GetWeapon(activeWeaponIndex);
            Destroy(weapon.gameObject);
            Invoke("EquipNewWeapon", 0.01f);
        }
    }
    public GunController GetWeapon(int index)
    {
        if(index < 0 || index >= Equipped_Weapons.Length)
        {
            return null;
        }
        return Equipped_Weapons[index];
    }
    public GunController GetActiveWeapon()
    {
        return GetWeapon(activeWeaponIndex);
    }
    IEnumerator SwitchWeapon(int holsterindex, int activeindex)
    {
        rigController.ResetTrigger("reload_Weapon");
        activeWeaponIndex = activeindex;
        yield return StartCoroutine(HolsterWeapon(holsterindex));
        yield return StartCoroutine(ActivateWeapon(activeindex));
    }
    IEnumerator HolsterWeapon(int index)
    {
        rigController.ResetTrigger("reload_Weapon");
        HolsteredWeapon = true;
        var weapon = GetWeapon(index);
        rigController.SetBool("Holster_Weapon", true);
        if (weapon == null || weapon != null && WasHolstered)
        {
           yield return new WaitForSeconds(0f);
        }
        else
        {
           yield return new WaitForSeconds(0.583f + 0.25f);
        }
        if (HideInventoryWeapons)
        {
            if(weapon != null)
            weapon.gameObject.SetActive(false);
        }
    }
    IEnumerator ActivateWeapon(int index)
    {
        rigController.ResetTrigger("reload_Weapon");
        SetHolstered();
        WasHolstered = HolsteredWeapon;
        var weapon = GetWeapon(index);
        if (HideInventoryWeapons)
        {
            weapon.gameObject.SetActive(true);
        }
        if (weapon)
        {
            rigController.SetBool("Holster_Weapon", false);
            rigController.Play("equip_" + weapon.WeaponSlotType);
            do
            {
                yield return new WaitForEndOfFrame();
            } while (rigController.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f);
        }
        HolsteredWeapon = false;
    }
    void StartPunchAttack(float combo)
    {
        TPSLocomotion.SetFloat("PunchSide", combo);
        TPSLocomotion.SetTrigger("Punch");
    }
}
