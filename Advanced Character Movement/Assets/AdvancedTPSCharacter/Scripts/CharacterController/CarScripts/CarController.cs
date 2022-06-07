using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CarState
{
    Occupied,
    NotOccupied
}
public class CarController : MonoBehaviour
{
    public CarState carState;
    PlayerControls PlayerControls;
    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;

    public Transform CarExitTransform;
    public GameObject Speedometer;
    public Camera CarCamera;
    private void Awake()
    {
        carState = CarState.NotOccupied;
        PlayerControls = new PlayerControls();
        PlayerControls.Enable();
        PlayerControls.Car.Braking.performed += Ctx =>
        {
            isBreaking = true;
        };
        PlayerControls.Car.Braking.canceled += Ctx =>
        {
            isBreaking = false;
        };
        PlayerControls.Car.Vertical.performed += Ctx =>
        {
            verticalInput = Ctx.ReadValue<float>();
        };
        PlayerControls.Car.Vertical.canceled += Ctx =>
        {
            verticalInput = Ctx.ReadValue<float>();
        };
        PlayerControls.Car.Horizontal.performed += Ctx =>
        {
            horizontalInput = Ctx.ReadValue<float>();
        };
        PlayerControls.Car.Horizontal.canceled += Ctx =>
        {
            horizontalInput = Ctx.ReadValue<float>();
        };
    }
    private void FixedUpdate()
    {
        UpdateWheels();
        if (carState == CarState.NotOccupied) { return; }
        HandleMotor();
        HandleSteering();
    }
    private void Update()
    {
        if (transform.localEulerAngles.z > 1 || transform.localEulerAngles.z < -1)
        {
            KeepCarOnGround();
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {
        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;
    }
    private void KeepCarOnGround()
    {
        transform.rotation = Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, 1.0f);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    private void HandleSteering()
    {
        CarExitTransform.localRotation = Quaternion.Euler(0, transform.rotation.y, 0);
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot
; wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }

}
