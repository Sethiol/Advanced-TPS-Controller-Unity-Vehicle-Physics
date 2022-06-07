using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Animations.Rigging;

public enum CharacterState
{
    Normal,
    Vehicle
}
public class AdvancedCharacterMovement : MonoBehaviour
{
    public CharacterState state;
    Vector3 PlayerMoveInput;
    Vector2 MouseMoveInput;
    Vector3 velocity;
    Animator animator;
    [SerializeField] private Rig aimLayer;
    private float VelocityX;
    private float VelocityZ;
    private float accleration = 3f;
    private float deccleration = 4f;
    private float Speed;
    public float SpeedMultiplier;
    private CharacterController Controller;
    private PlayerControls Controls;
    [SerializeField] private float ConstGravity = -9.81f;
    bool running;
    bool crouching;
    bool jumping;
    bool aiming;
    public bool Crouched;
    [HideInInspector]
    public bool IsWalking;
    public bool IsRunning;
    public bool IsCrouching;
    [SerializeField] private Camera cam;
    UIController controller;
    private ActiveWeapon weapon;
    public float turnSpeed = 15;
    private AmmoWidget widget;
    [SerializeField] private GameObject CameraLookAt;
    [SerializeField] private GameObject CameraLookAtOffset;
    private Vector3 CameraLookAtOffsetVector;
    private void Start()
    {
        widget = transform.parent.gameObject.GetComponentInChildren<AmmoWidget>();
        state = CharacterState.Normal;
        weapon = GetComponent<ActiveWeapon>();
        //Enabling Input Asset
        animator = GetComponent<Animator>();
        controller = GetComponentInChildren<UIController>();
        Controls = InputManager.inputActions;
        Controls.Enable();
        Controls.Keyboard.MovementKeyBinds.performed += ctx =>
        {
            PlayerMoveInput = new Vector3(ctx.ReadValue<Vector2>().x, PlayerMoveInput.y, ctx.ReadValue<Vector2>().y);
        };
        Controls.Keyboard.MovementKeyBinds.canceled += ctx =>
        {
            PlayerMoveInput = new Vector3(ctx.ReadValue<Vector2>().x, PlayerMoveInput.y, ctx.ReadValue<Vector2>().y);
        };
        Controls.Keyboard.Aim.started += ctx =>
        {
            int index = weapon.activeWeaponIndex;
            GunController weaponUsing = weapon.GetWeapon(index);
            if (weaponUsing == null) { return; }
            aiming = true;
        };
        Controls.Keyboard.Aim.canceled += ctx =>
        {
            int index = weapon.activeWeaponIndex;
            GunController weaponUsing = weapon.GetWeapon(index);
            if (weaponUsing == null) { return; }
            aiming = false;
        };
        Controls.Keyboard.Sprint.performed += ctx =>
        {
            if (aiming) { running = false; return; }
            running = true;
        };
        Controls.Keyboard.Sprint.canceled += ctx =>
        {
            if (aiming) { running = false; return; }
            running = false;
        };
        Controls.Keyboard.Crouch.performed += ctx =>
        {
            crouching = !crouching;
        };
        Controls.Keyboard.Jump.performed += ctx =>
        {
            jumping = true;
        };
        Controls.Keyboard.Equip.performed += ctx =>
        {
            if (state == CharacterState.Normal)
            {
                EnterOrEquipVehicle();
            }
        };
        Controls.Car.ExitVehicle.performed += ctx =>
        {
            if (state == CharacterState.Vehicle)
            {
                ExitOrLeaveVehicle();
            }
        };
        Controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Crouched = crouching;
        if (state == CharacterState.Vehicle) { IsWalking = false; IsCrouching = false; IsRunning = false; return; }
        HandleAnimations();
        HandleGravity();
        HandleMovement();
        HandleCharacterRotation();
    }
    //Move Character On Input
    private void HandleMovement()
    {
        //Establish Direction
        Vector3 MoveVec = transform.TransformDirection(PlayerMoveInput).normalized;
        //Establish Inputs
        bool forwardPressed = PlayerMoveInput.z > 0.5;
        bool backwardPressed = PlayerMoveInput.z < -0.5;
        bool leftPressed = PlayerMoveInput.x < -0.5;
        bool rightPressed = PlayerMoveInput.x > 0.5;
        if (controller.CancelAllMovement == true) return;
        if (weapon.CancelAllMovement == true) { return; }
        if (crouching)
        {
            Speed = 0.75f;
            Controller.Move(MoveVec * (Speed * SpeedMultiplier) * Time.deltaTime);
            if (forwardPressed || backwardPressed || leftPressed || rightPressed)
            {
                IsCrouching = true;
                IsRunning = false;
                IsWalking = false;
            }
        }
        else
        {
            if (forwardPressed && !running && !backwardPressed)
            {
                IsCrouching = false;
                IsWalking = true;
                IsRunning = false;
                Speed = 1.2f;
                Controller.Move(MoveVec * (Speed * SpeedMultiplier) * Time.deltaTime);
            }
            if (!forwardPressed && !running && (leftPressed || rightPressed || backwardPressed))
            {
                IsCrouching = false;
                IsWalking = true;
                IsRunning = false;
                Speed = 1f;
                Controller.Move(MoveVec * (Speed * SpeedMultiplier) * Time.deltaTime);
            }
            if (forwardPressed && running && !backwardPressed && !leftPressed && !rightPressed)
            {
                IsCrouching = false;
                IsWalking = false;
                IsRunning = true;
                Speed = 2f;
                Controller.Move(MoveVec * (Speed * SpeedMultiplier) * Time.deltaTime);
            }
            if (!forwardPressed && running && (backwardPressed))
            {
                IsCrouching = false;
                IsWalking = false;
                IsRunning = true;
                Speed = 1.4f;
                Controller.Move(MoveVec * (Speed * SpeedMultiplier) * Time.deltaTime);
            }
            if (!forwardPressed && running && (leftPressed || rightPressed) && !backwardPressed)
            {
                IsCrouching = false;
                IsWalking = false;
                IsRunning = true;
                Speed = 1f;
                Controller.Move(MoveVec * (Speed * SpeedMultiplier) * Time.deltaTime);
            }
            if (forwardPressed && running && !backwardPressed && (leftPressed || rightPressed))
            {
                IsCrouching = false;
                IsWalking = false;
                IsRunning = true;
                Speed = 1.8f;
                Controller.Move(MoveVec * (Speed * SpeedMultiplier) * Time.deltaTime);
            }
        }
    }
    private bool IsGrounded()
    {
        return Controller.isGrounded;
    }
    private void HandleGravity()
    {

        if (IsGrounded() && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += ConstGravity * Time.deltaTime;
        Controller.Move(velocity * Time.deltaTime);
    }
    private void HandleAnimations()
    {
        if (jumping)
        {
            animator.SetTrigger("Jumping");
            StartCoroutine(JumpAnimate());
            return;
        }
        if (weapon.CancelAllMovement == true) { return; }
        if (controller.CancelAllMovement == true) return;
        bool forwardPressed = PlayerMoveInput.z > 0.5;
        bool backwardPressed = PlayerMoveInput.z < -0.5;
        bool leftPressed = PlayerMoveInput.x < -0.5;
        bool rightPressed = PlayerMoveInput.x > 0.5;

        if (crouching)
        {
            animator.SetBool("Crouching", true);
            if (forwardPressed && VelocityZ < 0.5f)
            {
                VelocityZ += Time.deltaTime * accleration;
            }
            if (leftPressed && VelocityX > -0.5f)
            {
                VelocityX -= Time.deltaTime * accleration;
            }
            if (rightPressed && VelocityX < 0.5f)
            {
                VelocityX += Time.deltaTime * accleration;
            }
            if (backwardPressed && VelocityZ > -0.5f)
            {
                VelocityZ -= Time.deltaTime * accleration;
            }
            //decrease velocity on axis
            if (!forwardPressed && VelocityZ > 0.0f)
            {
                VelocityZ -= Time.deltaTime * deccleration;
            }
            if (!backwardPressed && VelocityZ < 0.0f)
            {
                VelocityZ += Time.deltaTime * deccleration;
            }
            if (!leftPressed && VelocityX < 0.0f)
            {
                VelocityX += Time.deltaTime * deccleration;
            }
            if (!rightPressed && VelocityX > 0.0f)
            {
                VelocityX -= Time.deltaTime * deccleration;
            }
            // reset VelocityZ
            if (!forwardPressed && !backwardPressed && VelocityZ != 0.0f && (VelocityZ > -0.05f && VelocityZ < 0.05f))
            {
                IsCrouching = false;
                VelocityZ = 0.0f;
            }
            // reset VelocityX
            if (!leftPressed && !rightPressed && VelocityX != 0.0f && (VelocityX > -0.05f && VelocityX < 0.05f))
            {
                IsCrouching = false;
                VelocityX = 0.0f;
            }
            // set the parameters to our local variable values
            animator.SetFloat("CrouchingVelocityZ", VelocityZ);
            animator.SetFloat("VelocityX", VelocityX);
        }
        else
        {
            animator.SetBool("Crouching", false);
            //increase velocity on axis
            if (forwardPressed && VelocityZ < 0.5f && !running)
            {
                VelocityZ += Time.deltaTime * accleration;
            }
            if (leftPressed && VelocityX > -0.5f)
            {
                VelocityX -= Time.deltaTime * accleration;
            }
            if (rightPressed && VelocityX < 0.5f)
            {
                VelocityX += Time.deltaTime * accleration;
            }
            if (backwardPressed && VelocityZ > -0.5f && !running)
            {
                VelocityZ -= Time.deltaTime * accleration;
            }
            if (forwardPressed && VelocityZ < 1f && running)
            {
                VelocityZ += Time.deltaTime * accleration;
            }
            if (backwardPressed && VelocityZ > -1f && running)
            {
                VelocityZ -= Time.deltaTime * accleration;
            }
            //Make sure velocity isn't increasing/decreasing
            if (forwardPressed && leftPressed && !running && VelocityZ > 0.5)
            {
                VelocityZ -= Time.deltaTime * deccleration;
            }
            if (forwardPressed && rightPressed && !running && VelocityZ > 0.5)
            {
                VelocityZ -= Time.deltaTime * deccleration;
            }
            if (backwardPressed && leftPressed && !running && VelocityZ < -0.5)
            {
                VelocityZ += Time.deltaTime * deccleration;
            }
            if (backwardPressed && rightPressed && !running && VelocityZ < -0.5)
            {
                VelocityZ += Time.deltaTime * deccleration;
            }
            if (forwardPressed && !running && VelocityZ > 0.5)
            {
                VelocityZ -= Time.deltaTime * deccleration;
            }
            if (backwardPressed && !running && VelocityZ < -0.5)
            {
                VelocityZ += Time.deltaTime * deccleration;
            }
            //decrease velocity on axis
            if (!forwardPressed && VelocityZ > 0.0f)
            {
                VelocityZ -= Time.deltaTime * deccleration;
            }
            if (!backwardPressed && VelocityZ < 0.0f)
            {
                VelocityZ += Time.deltaTime * deccleration;
            }
            if (!leftPressed && VelocityX < 0.0f)
            {
                VelocityX += Time.deltaTime * deccleration;
            }
            if (!rightPressed && VelocityX > 0.0f)
            {
                VelocityX -= Time.deltaTime * deccleration;
            }
            // reset VelocityZ
            if (!forwardPressed && !backwardPressed && VelocityZ != 0.0f && (VelocityZ > -0.05f && VelocityZ < 0.05f))
            {
                IsCrouching = false;
                IsRunning = false;
                IsWalking = false;
                VelocityZ = 0.0f;
            }
            // reset VelocityX
            if (!leftPressed && !rightPressed && VelocityX != 0.0f && (VelocityX > -0.05f && VelocityX < 0.05f))
            {
                IsCrouching = false;
                IsWalking = false;
                IsRunning = false;
                VelocityX = 0.0f;
            }
            // set the parameters to our local variable values
            animator.SetFloat("StandingVelocityZ", VelocityZ);
            animator.SetFloat("VelocityX", VelocityX);
        }
    }
    IEnumerator JumpAnimate()
    {
        yield return new WaitForSeconds(2.333f);
        jumping = false;
        animator.ResetTrigger("Jumping");
    }
    private void HandleCharacterRotation()
    {
        if (controller.CancelAllMovement == true) return;
        float yawCamera = cam.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Euler(0, yawCamera, 0);
    }

    // Car Code Start
    void EnterOrEquipVehicle()
    {
        CarCheck carCheck = GetComponentInChildren<CarCheck>();
        if (carCheck == null) { return; }
        if (carCheck.CanEnterVehicle == true && carCheck.CarCheckUI.gameObject.activeSelf == true)
        {
            Debug.Log("We Can Enter Vehicle");
            carCheck.EnterVehicle();
        }
        else
        {
            return;
        }
    }
    public void EnterCar()
    {
        widget.gameObject.SetActive(false);
        SkinnedMeshRenderer[] meshRenders;
        meshRenders = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer renderer in meshRenders)
        {
            renderer.enabled = false;
        }
        gameObject.GetComponent<CharacterController>().enabled = false;
        GetComponentInChildren<CarCheck>().gameObject.GetComponent<CapsuleCollider>().enabled = false;
        state = CharacterState.Vehicle;
        GunController[] gunControllers = GetComponentsInChildren<GunController>();
        foreach (GunController controller in gunControllers)
        {
            MeshRenderer[] renderers = controller.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }
        }
    }
    public void EnterMotorcycle(GameObject CarEnter)
    {
        animator.Play("Driving");
        animator.SetBool("Driving", true);
        widget.gameObject.SetActive(false);
        gameObject.GetComponent<CharacterController>().enabled = false;
        GetComponentInChildren<CarCheck>().gameObject.GetComponent<CapsuleCollider>().enabled = false;
        state = CharacterState.Vehicle;
        GunController[] gunControllers = GetComponentsInChildren<GunController>();
        foreach (GunController controller in gunControllers)
        {
            MeshRenderer[] renderers = controller.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = false;
            }
        }
        GetComponent<AdvancedFootIKPlacement>().enabled = false;
        transform.localRotation = Quaternion.identity;
        transform.localPosition = Vector3.zero;
        transform.parent.transform.localPosition = new Vector3(CarEnter.transform.localPosition.x, CarEnter.transform.localPosition.y - 30f, CarEnter.transform.localPosition.z);
        transform.parent.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        GetComponentInChildren<WeaponAnimationEvents>().gameObject.GetComponent<Animator>().enabled = false;
    }
    void ExitOrLeaveVehicle()
    {
        CarCheck carCheck = GetComponentInChildren<CarCheck>();
        if (carCheck == null) { return; }
        if (carCheck.CanEnterVehicle == false && carCheck.CarCheckUI.gameObject.activeSelf == false)
        {
            carCheck.ExitVehicle();
        }
        else
        {
            return;
        }
    }
    public void ExitCar()
    {
        widget.gameObject.SetActive(true);
        SkinnedMeshRenderer[] meshRenders;
        meshRenders = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer renderer in meshRenders)
        {
            renderer.enabled = true;
        }
        gameObject.GetComponent<CharacterController>().enabled = true;
        GetComponentInChildren<CarCheck>().gameObject.GetComponent<CapsuleCollider>().enabled = true;
        state = CharacterState.Normal;
        GunController[] gunControllers = GetComponentsInChildren<GunController>();
        foreach (GunController controller in gunControllers)
        {
            MeshRenderer[] renderers = controller.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = true;
            }
        }
    }
    public void ExitMotorcycle()
    {
        widget.gameObject.SetActive(true);
        gameObject.GetComponent<CharacterController>().enabled = true;
        GetComponentInChildren<CarCheck>().gameObject.GetComponent<CapsuleCollider>().enabled = true;
        state = CharacterState.Normal;
        GunController[] gunControllers = GetComponentsInChildren<GunController>();
        foreach (GunController controller in gunControllers)
        {
            MeshRenderer[] renderers = controller.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = true;
            }
        }
        animator.SetBool("Driving", false);
        GetComponent<AdvancedFootIKPlacement>().enabled = true;
    }
    // Car Code End

    public void ActivateRagdoll()
    {
        Debug.Log("Died");
    }

}
