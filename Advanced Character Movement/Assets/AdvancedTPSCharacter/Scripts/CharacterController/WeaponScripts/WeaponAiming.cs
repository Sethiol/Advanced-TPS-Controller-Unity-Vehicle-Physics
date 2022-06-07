using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAiming : MonoBehaviour
{
    private Cinemachine.CinemachineFreeLook cam;
    private PlayerControls controls;
    bool Aiming = false;
    float currentFOV;
    float standardFOV;
    public float AimSpeed;
    [HideInInspector] public string currentWeapon;
    bool isScoped = false;
    ActiveWeapon activeWeapon;
    private void Start()
    {
        Aiming = false;
        cam = FindObjectOfType<Cinemachine.CinemachineFreeLook>();
        currentFOV = cam.m_Lens.FieldOfView;
        standardFOV = cam.m_Lens.FieldOfView;
        currentFOV = 50;
        standardFOV = 51;
        cam.m_Lens.FieldOfView = currentFOV;
        controls = new PlayerControls();
        controls.Enable();
        controls.Keyboard.Aim.started += ctx =>
        {
            Aiming = true;
        };
        controls.Keyboard.Aim.canceled += ctx =>
        {
            Aiming = false;
        };
        activeWeapon = GetComponent<ActiveWeapon>();
    }
    private void Update()
    {
        var weapon = activeWeapon.GetActiveWeapon();
        if (weapon && (currentWeapon != "Axe") && (currentWeapon != "Knife"))
        {
                weapon.recoil.RecoilModifier = Aiming ? 0.3f : 1.0f;
        }
        if(currentWeapon == "Axe" || currentWeapon == "") { return;  }
        if(currentWeapon == "Sniper") { SniperAiming(); }
        else { OtherWeaponAiming(); }
    }

    void SniperAiming()
    {
        if (cam == null) { return; }
        if (Aiming && currentFOV > 21)
        {
            currentFOV -= Time.deltaTime * AimSpeed * 1.5f;
            cam.m_Lens.FieldOfView = currentFOV;
        }
        else if (Aiming && currentFOV < 21)
        {
            currentFOV = 20;
            cam.m_Lens.FieldOfView = currentFOV;
            isScoped = true;
        }
        else if (!Aiming && currentFOV < standardFOV)
        {
            currentFOV += Time.deltaTime * AimSpeed * 1.5f;
            cam.m_Lens.FieldOfView = currentFOV;
            isScoped = false;
        }
        else if (!Aiming && currentFOV == 50)
        {
            currentFOV = 50;
            cam.m_Lens.FieldOfView = currentFOV;
        }
    }
    void OtherWeaponAiming()
    {
        if (cam == null) { return; }
        if (Aiming && currentFOV > 35)
        {
            currentFOV -= Time.deltaTime * AimSpeed;
            cam.m_Lens.FieldOfView = currentFOV;
        }
        else if (Aiming && currentFOV == 35)
        {
            currentFOV = 50;
            cam.m_Lens.FieldOfView = currentFOV;
        }
        else if (!Aiming && currentFOV < standardFOV)
        {
            currentFOV += Time.deltaTime * AimSpeed * 1.5f;
            cam.m_Lens.FieldOfView = currentFOV;
            isScoped = false;
        }
        else if (!Aiming && currentFOV == 50)
        {
            currentFOV = 50;
            cam.m_Lens.FieldOfView = currentFOV;
        }
    }
    public void StopAiming()
    {
        Aiming = false;
    }
}
