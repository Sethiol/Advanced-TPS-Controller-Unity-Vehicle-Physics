using UnityEngine;
using UnityEditor;


public class AdvancedFootIKPlacement : MonoBehaviour
{
    private bool Started = false;
    [HideInInspector] public bool BlockBodyPositioning;
    private Animator anim;
    private RaycastHit LeftHitPlaceBase;
    private RaycastHit RightHitPlaceBase;
    private Transform RightFootPlaceBase;
    private Transform LeftFootPlaceBase;
    private Vector3 SmothedLeftFootPosition;
    private Vector3 SmothedRightFootPosition;
    private Quaternion SmothedLeftFootRotation;
    private Quaternion SmothedRightFootRotation;
    public bool EnableFootPlacement = true;
    public bool AdvancedMode = false;
    [Space]
    public LayerMask GroundLayers;
    private Transform LeftFoot;
    private Transform LeftFootBase_UP;
    private Transform RightFoot;
    private Transform RightFootBase_UP;
    readonly public float RaycastMaxDistance = 2f;
    readonly public float RaycastHeight = 1f;
    [Range(0, 1)]
    public float FootHeight = 0.08f;
    float LeftFootHeight;
    float RightFootHeight;
    public float MaxStepHeight = 0.6f;
    public bool UseDynamicFootPlacing = true;
    public string LeftFootHeightCurveName = "LeftFootHeight";
     public string RightFootHeightCurveName = "RightFootHeight";
    float AnimationLeftFootPositionY, AnimationRightFootPositionY;
    public bool SmoothIKTransition = true;
    public float FootHeightMultiplier = 0.6f;
    [Range(0, 1)]
    public float GlobalWeight = 1;
    private float TransitionIKtoFKWeight;
    [HideInInspector] public float LeftFootHeightFromGround;
    [HideInInspector] public float RightFootHeightFromGround;
    [HideInInspector] public float LeftFootRotationWeight;
    [HideInInspector] public float RightFootRotationWeight;
    bool LeftHit;
    bool RightHit;
    public float radius = 0.1f;
    public bool EnableDynamicBodyPlacing = true;
    public float UpAndDownForce = 10f;
    public float MaxBodyCrouchHeight = 0.65f;
    public bool JustCalculateBodyPosition = false;
    public bool KeepCharacterOnGround = false;
    public float RaycastDistanceToGround = 1.2f;
    public float BodyHeightPosition = 0.01f;
    public float Force = 10f;
    private float MinBodyHeightPosition = 0.005f;
    private float MaxBodyPositionHeight = 1f;
    public bool TheresGroundBelow;
    public float GroundCheckRadius = 0.1f;
    void Start()
    {
        Invoke("StartFootPlacement", 0.1f);
        GetFootPlacementDependencies();
    }
    void LateUpdate()
    {
        if (Started == false) return;

    }

    public void StartFootPlacement()
    {
        Started = true;
        LeftFootPlaceBase.position = LeftFoot.position;
        RightFootPlaceBase.position = RightFoot.position;
    }
    private void GetFootPlacementDependencies()
    {
        if (GroundLayers.value == 0)
            GroundLayers = LayerMask.GetMask("Default");
        if (LeftFoot == null && RightFoot == null)
        {
            anim = GetComponent<Animator>();
            LeftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
            RightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);

            SmothedLeftFootPosition = LeftFoot.position - transform.forward * 0.1f;
            SmothedRightFootPosition = RightFoot.position - transform.forward * 0.1f;
            SmothedLeftFootRotation = LeftFoot.rotation;
            SmothedRightFootRotation = RightFoot.rotation;

            LeftFootPlaceBase = new GameObject("Left Foot Position").transform;
            RightFootPlaceBase = new GameObject("Right Foot Position").transform;
            LeftFootPlaceBase.position = LeftFoot.position;
            RightFootPlaceBase.position = RightFoot.position;
            LeftFootPlaceBase.gameObject.hideFlags = HideFlags.HideAndDontSave;
            RightFootPlaceBase.gameObject.hideFlags = HideFlags.HideAndDontSave;


            LeftFootBase_UP = new GameObject("Left Foot BASE UP").transform;
            RightFootBase_UP = new GameObject("Right Foot BASE UP").transform;
            LeftFootBase_UP.position = LeftFoot.position;
            RightFootBase_UP.position = RightFoot.position;
            LeftFootBase_UP.transform.SetParent(LeftFoot);
            RightFootBase_UP.transform.SetParent(RightFoot);
            LeftFootBase_UP.gameObject.hideFlags = HideFlags.HideAndDontSave;
            RightFootBase_UP.gameObject.hideFlags = HideFlags.HideAndDontSave;
        }
    }
    private void FootPlacementPositions()
    {
        if (UseDynamicFootPlacing == true)
        {
            LeftFootHeightFromGround = FootHeightMultiplier * AnimationLeftFootPositionY;
            RightFootHeightFromGround = FootHeightMultiplier * AnimationRightFootPositionY;
        }
        else
        {
            //Get IK Height per curves
            LeftFootHeightFromGround = Mathf.Lerp(LeftFootHeightFromGround, anim.GetFloat(LeftFootHeightCurveName) / 2, 20 * Time.deltaTime);
            RightFootHeightFromGround = Mathf.Lerp(RightFootHeightFromGround, anim.GetFloat(RightFootHeightCurveName) / 2, 20 * Time.deltaTime);
        }
        //>>> Raycasts
        Physics.SphereCast(LeftFoot.position + transform.up * RaycastHeight + LeftFootBase_UP.forward * 0.12f, radius, -transform.up, out LeftHitPlaceBase, RaycastMaxDistance, GroundLayers);
        Physics.SphereCast(RightFoot.position + transform.up * RaycastHeight + RightFootBase_UP.forward * 0.12f, radius, -transform.up, out RightHitPlaceBase, RaycastMaxDistance, GroundLayers);

        //>>> Hits Checks
        if (LeftHitPlaceBase.point != Vector3.zero)
        {
            LeftFootPlaceBase.position = LeftHitPlaceBase.point;
            LeftFootPlaceBase.rotation = Quaternion.FromToRotation(transform.up, LeftHitPlaceBase.normal) * transform.rotation;
            LeftHit = true;
        }
        else
        {
            LeftFootPlaceBase.position = LeftFoot.position;
            LeftHit = false;
        }
        if (RightHitPlaceBase.point != Vector3.zero)
        {
            RightFootPlaceBase.position = RightHitPlaceBase.point;
            RightFootPlaceBase.rotation = Quaternion.FromToRotation(transform.up, RightHitPlaceBase.normal) * transform.rotation;

            RightHit = true;
        }
        else
        {
            RightFootPlaceBase.position = RightFoot.position;
            RightHit = false;
        }
        //>>> Correct Foot Height
        LeftFootHeight = FootHeight - Vector3.SignedAngle(LeftFootBase_UP.up, transform.up, transform.right) / 500;
        RightFootHeight = FootHeight - Vector3.SignedAngle(RightFootBase_UP.up, transform.up, transform.right) / 500;
        LeftFootHeight = Mathf.Clamp(LeftFootHeight, -0.2f, 0.2f);
        RightFootHeight = Mathf.Clamp(RightFootHeight, -0.2f, 0.2f);

        //>>> Lerp Positions
        if (LeftHit == true)
        {
            if (LeftHitPlaceBase.point.y < transform.position.y + MaxStepHeight)
            {
                SmothedLeftFootPosition = Vector3.Lerp(SmothedLeftFootPosition, LeftFootPlaceBase.position + LeftHitPlaceBase.normal * LeftFootHeight + transform.up * LeftFootHeightFromGround, 15 * Time.deltaTime);
            }
            else
            {
                SmothedLeftFootPosition = Vector3.Lerp(SmothedLeftFootPosition, transform.position + transform.up * FootHeight + transform.up * LeftFootHeightFromGround, 15 * Time.deltaTime);
            }
        }
        else
        {
            SmothedLeftFootPosition = LeftFoot.position;
        }


        if (RightHit == true)
        {
            if (RightHitPlaceBase.point.y < transform.position.y + MaxStepHeight)
            {
                SmothedRightFootPosition = Vector3.Lerp(SmothedRightFootPosition, RightFootPlaceBase.position + RightHitPlaceBase.normal * RightFootHeight + transform.up * RightFootHeightFromGround, 20 * Time.deltaTime);
            }
            else
            {
                SmothedRightFootPosition = Vector3.Lerp(SmothedRightFootPosition, transform.position + transform.up * FootHeight + transform.up * RightFootHeightFromGround, 20 * Time.deltaTime);
            }
        }
        else
        {
            SmothedRightFootPosition = RightFoot.position;
        }

        //Calculate Left Foot Rotation
        Vector3 rotAxisLF = Vector3.Cross(Vector3.up, LeftHitPlaceBase.normal);
        float angleLF = Vector3.Angle(Vector3.up, LeftHitPlaceBase.normal);
        Quaternion rotLF = Quaternion.AngleAxis(angleLF * GlobalWeight, rotAxisLF);
        LeftFootPlaceBase.rotation = rotLF;

        //Smooth Rotation
        SmothedLeftFootRotation = Quaternion.Lerp(SmothedLeftFootRotation, LeftFootPlaceBase.rotation, 20 * Time.deltaTime);

        //Calculate Right Foot Rotation
        Vector3 rotAxisRF = Vector3.Cross(Vector3.up, RightHitPlaceBase.normal);
        float angleRF = Vector3.Angle(Vector3.up, RightHitPlaceBase.normal);
        Quaternion rotRF = Quaternion.AngleAxis(angleRF * GlobalWeight, rotAxisRF);
        RightFootPlaceBase.rotation = rotRF;

        //Smooth Rotation
        SmothedRightFootRotation = Quaternion.Lerp(SmothedRightFootRotation, RightFootPlaceBase.rotation, 20 * Time.deltaTime);


        //>>> Rotation Weight
        if (LeftFootHeightFromGround < 0.3f)
        {
            LeftFootRotationWeight = Mathf.Lerp(LeftFootRotationWeight, 1, 8 * Time.deltaTime);
        }
        else
        {
            LeftFootRotationWeight = Mathf.Lerp(LeftFootRotationWeight, 0, 1 * Time.deltaTime);
        }

        if (RightFootHeightFromGround < 0.3f)
        {
            RightFootRotationWeight = Mathf.Lerp(RightFootRotationWeight, 1, 8 * Time.deltaTime);
        }
        else
        {
            RightFootRotationWeight = Mathf.Lerp(RightFootRotationWeight, 0, 1 * Time.deltaTime);
        }

        //>>> Smooth Transition to IK/FK
        if (SmoothIKTransition)
        {
            TransitionIKtoFKWeight = Mathf.Lerp(TransitionIKtoFKWeight, 1, 5 * Time.deltaTime);
        }
        else
        {
            TransitionIKtoFKWeight = Mathf.Lerp(TransitionIKtoFKWeight, 0, 5 * Time.deltaTime);
        }
    }


    RaycastHit HitGroundBodyPlacement;
    public float LastBodyPositionY;
    public Vector3 NewAnimationBodyPosition;
    private float BodyPositionOffset;
    [HideInInspector] public float Animation_Y_BodyPosition; // Real body position without changes
    private float GroundAngle;
    private void BodyPlacement()
    {

        Physics.SphereCast(transform.position + transform.up * RaycastDistanceToGround, GroundCheckRadius, -transform.up, out HitGroundBodyPlacement, RaycastDistanceToGround + 0.2f, GroundLayers);
        if (HitGroundBodyPlacement.point != Vector3.zero) TheresGroundBelow = true; else TheresGroundBelow = false;
        GroundAngle = Vector3.Angle(Vector3.up, HitGroundBodyPlacement.normal);
        if (KeepCharacterOnGround)
        {
            //Limit Body Height Position
            BodyHeightPosition = Mathf.Clamp(BodyHeightPosition, MinBodyHeightPosition, MaxBodyPositionHeight);

            //Ground Checker
            if (TheresGroundBelow)
            {
                // keeps the character's body on the ground.
                float GroundPosition = HitGroundBodyPlacement.point.y - BodyHeightPosition;
                float SmoothedGroundNewPosition = Mathf.Lerp(transform.position.y, GroundPosition, Force * Time.fixedDeltaTime);
                Vector3 CharacterNewPosition = new Vector3(transform.position.x, SmoothedGroundNewPosition, transform.position.z);
                transform.position = CharacterNewPosition;
            }

        }

        if (TheresGroundBelow && IsInvoking("DisableBlock") == false && BlockBodyPositioning == true)
        {
            Invoke("DisableBlock", 0.5f);
        }

        // >>>> BODY PLACEMENT 
        if (EnableDynamicBodyPlacing && BlockBodyPositioning == false)
        {
            // Animator Center of Mass Position Changer
            if (LeftHitPlaceBase.point == Vector3.zero || RightHitPlaceBase.point == Vector3.zero || LastBodyPositionY == 0) { LastBodyPositionY = Animation_Y_BodyPosition; BodyPositionOffset = 0; NewAnimationBodyPosition = anim.bodyPosition; return; }

            float leftOffsetBodyPosition = LeftHitPlaceBase.point.y - transform.position.y - RightFootHeightFromGround / 2;
            float rightOffsetBodyPosition = RightHitPlaceBase.point.y - transform.position.y - LeftFootHeightFromGround / 2;

            BodyPositionOffset = (leftOffsetBodyPosition < rightOffsetBodyPosition) ? leftOffsetBodyPosition : rightOffsetBodyPosition;
            BodyPositionOffset = Mathf.Clamp(BodyPositionOffset, -MaxBodyCrouchHeight, 0);

            float force = UpAndDownForce + (GroundAngle / 20);
            NewAnimationBodyPosition = anim.bodyPosition + transform.up * BodyPositionOffset;
            NewAnimationBodyPosition.y = Mathf.Lerp(LastBodyPositionY, NewAnimationBodyPosition.y, force * Time.deltaTime);

            float dist = Mathf.Abs(Animation_Y_BodyPosition - LastBodyPositionY);
            if (JustCalculateBodyPosition == false && dist < 1)
            {
                //Apply animator center of mass position
                anim.bodyPosition = NewAnimationBodyPosition;
            }

            LastBodyPositionY = anim.bodyPosition.y;
        }
        else
        {
            if (!TheresGroundBelow || BlockBodyPositioning) return;
            NewAnimationBodyPosition = anim.bodyPosition + transform.up * BodyPositionOffset;
            NewAnimationBodyPosition.y = Mathf.Lerp(LastBodyPositionY, Animation_Y_BodyPosition, UpAndDownForce * Time.deltaTime);
            anim.bodyPosition = NewAnimationBodyPosition;
            LastBodyPositionY = anim.bodyPosition.y;
        }




    }
    void DisableBlock()
    {
        BlockBodyPositioning = false;
        LastBodyPositionY = Animation_Y_BodyPosition;
    }
    public Vector3 GetCalculatedAnimatorCenterOfMass()
    {
        return NewAnimationBodyPosition;
    }


    private void OnAnimatorIK(int layerIndex)
    {
        if (layerIndex == 0)
        {
            FootPlacementPositions();

            Animation_Y_BodyPosition = anim.bodyPosition.y;
            if (TransitionIKtoFKWeight < 0.1f || GlobalWeight < 0.01f || RightHitPlaceBase.point == Vector3.zero || RightHitPlaceBase.point == Vector3.zero) return;
            if (EnableFootPlacement == true)
            {


                //Get position before IK Correction
                AnimationLeftFootPositionY = transform.position.y - (LeftFoot.position.y - FootHeight);
                AnimationRightFootPositionY = transform.position.y - (RightFoot.position.y - FootHeight);



                AnimationLeftFootPositionY = Mathf.Abs(AnimationLeftFootPositionY);
                AnimationRightFootPositionY = Mathf.Abs(AnimationRightFootPositionY);

                AnimationLeftFootPositionY = Mathf.Clamp(AnimationLeftFootPositionY, 0, 1);
                AnimationRightFootPositionY = Mathf.Clamp(AnimationRightFootPositionY, 0, 1);

                BodyPlacement();

                if (LeftHit == true && LeftHitPlaceBase.point.y < transform.position.y + RaycastHeight)
                {

                    Vector3 pos = new Vector3(LeftFoot.position.x, SmothedLeftFootPosition.y, LeftFoot.position.z);
                    anim.SetIKPosition(AvatarIKGoal.LeftFoot, pos);
                    anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, GlobalWeight * TransitionIKtoFKWeight);

                    anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, GlobalWeight * TransitionIKtoFKWeight * LeftFootRotationWeight);
                    anim.SetIKRotation(AvatarIKGoal.LeftFoot, SmothedLeftFootRotation * anim.GetIKRotation(AvatarIKGoal.LeftFoot));
                }

                if (RightHit == true && RightHitPlaceBase.point.y < transform.position.y + RaycastHeight)
                {
                    Vector3 pos = new Vector3(RightFoot.position.x, SmothedRightFootPosition.y, RightFoot.position.z);
                    anim.SetIKPosition(AvatarIKGoal.RightFoot, pos);
                    anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, GlobalWeight * TransitionIKtoFKWeight);

                    anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, GlobalWeight * TransitionIKtoFKWeight * RightFootRotationWeight);
                    anim.SetIKRotation(AvatarIKGoal.RightFoot, SmothedRightFootRotation * anim.GetIKRotation(AvatarIKGoal.RightFoot));
                }

            }
        }
    }
}
