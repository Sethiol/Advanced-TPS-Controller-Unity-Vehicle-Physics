using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FootstepSound : MonoBehaviour
{
    [SerializeField] private AudioSource[] Concrete;
    [SerializeField] private AudioSource[] Dirt;
    [SerializeField] private AudioSource[] Grass;
    [SerializeField] private AudioSource[] Gravel;
    [SerializeField] private AudioSource[] Metal;
    [SerializeField] private AudioSource[] Water;
    [SerializeField] private AudioSource[] Wood;
    private string Ground;
    [SerializeField] private TMP_Text GroundType;
    bool IsWalking;
    bool IsRunning;
    bool IsCrouching;
    int WalkedTransition;
    int RunTransition;
    string WalkOrRun;
    private void Update()
    {
        if(Ground == "") { Ground = "Concrete"; }
        if(GetComponentInParent<AdvancedCharacterMovement>().IsWalking == true)
        {
            StartWalkingFootsteps();
        }
        if (GetComponentInParent<AdvancedCharacterMovement>().IsRunning== true)
        {
            StartRunningFootsteps();
        }
        if (GetComponentInParent<AdvancedCharacterMovement>().IsCrouching == true)
        {
            StartCrouchingFootsteps();
        }
        GroundType.text = Ground;
    }
    private void StartWalkingFootsteps()
    {
        if (IsWalking) { return; }
        StartCoroutine(HitFootstepWalk());
    }
    private void StartCrouchingFootsteps()
    {
        if (IsCrouching) { return; }
        StartCoroutine(HitFootstepCrouch());
    }
    private void StartRunningFootsteps()
    {
        if (IsRunning) { return; }
        StartCoroutine(HitFootstepRun());
    }
    IEnumerator HitFootstepRun()
    {
        IsRunning = true;
        if (Ground == "Concrete")
        {
            if (RunTransition == 0)
            {
                RunTransition = 1;
                Concrete[2].Play();
            }
            else if (RunTransition == 1)
            {
                RunTransition = 0;
                Concrete[3].Play();
            }
        }
        if (Ground == "Dirt")
        {
            if (RunTransition == 0)
            {
                RunTransition = 1;
                Dirt[2].Play();
            }
            else if (RunTransition == 1)
            {
                RunTransition = 0;
                Dirt[3].Play();
            }
        }
        if (Ground == "Grass")
        {
            if (RunTransition == 0)
            {
                RunTransition = 1;
                Grass[2].Play();
            }
            else if (RunTransition == 1)
            {
                RunTransition = 0;
                Grass[3].Play();
            }
        }
        if (Ground == "Gravel")
        {
            if (RunTransition == 0)
            {
                RunTransition = 1;
                Gravel[2].Play();
            }
            else if (RunTransition == 1)
            {
                RunTransition = 0;
                Gravel[3].Play();
            }
        }
        if (Ground == "Metal")
        {
            if (RunTransition == 0)
            {
                RunTransition = 1;
                Metal[2].Play();
            }
            else if (RunTransition == 1)
            {
                RunTransition = 0;
                Metal[3].Play();
            }
        }
        if (Ground == "Water")
        {
            if (RunTransition == 0)
            {
                RunTransition = 1;
                Water[2].Play();
            }
            else if (RunTransition == 1)
            {
                RunTransition = 0;
                Water[3].Play();
            }
        }
        if (Ground == "Wood")
        {
            if (RunTransition == 0)
            {
                RunTransition = 1;
                Wood[2].Play();
            }
            else if (RunTransition == 1)
            {
                RunTransition = 0;
                Wood[3].Play();
            }
        }
        yield return new WaitForSeconds(0.3f);
        IsRunning = false;
    }
    IEnumerator HitFootstepCrouch()
    {
        IsCrouching = true;
        if (Ground == "Concrete")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Concrete[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Concrete[1].Play();
            }
        }
        if (Ground == "Dirt")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Dirt[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Dirt[1].Play();
            }
        }
        if (Ground == "Grass")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Grass[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Grass[1].Play();
            }
        }
        if (Ground == "Gravel")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Gravel[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Gravel[1].Play();
            }
        }
        if (Ground == "Metal")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Metal[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Metal[1].Play();
            }
        }
        if (Ground == "Water")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Water[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Water[1].Play();
            }
        }
        if (Ground == "Wood")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Wood[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Wood[1].Play();
            }
        }
        yield return new WaitForSeconds(0.58f);
        IsCrouching = false;
    }
    IEnumerator HitFootstepWalk()
    {
        IsWalking = true;
        if(Ground == "Concrete")
        {
            if(WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Concrete[0].Play();
            }
            else if(WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Concrete[1].Play();
            }
        }
        if(Ground == "Dirt")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Dirt[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Dirt[1].Play();
            }
        }
        if(Ground == "Grass")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Grass[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Grass[1].Play();
            }
        }
        if(Ground == "Gravel")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Gravel[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Gravel[1].Play();
            }
        }
        if(Ground == "Metal")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Metal[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Metal[1].Play();
            }
        }
        if (Ground == "Water")
        {
            if(WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Water[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Water[1].Play();
            }
        }
        if (Ground == "Wood")
        {
            if (WalkedTransition == 0)
            {
                WalkedTransition = 1;
                Wood[0].Play();
            }
            else if (WalkedTransition == 1)
            {
                WalkedTransition = 0;
                Wood[1].Play();
            }
        }
        yield return new WaitForSeconds(0.55f);
        IsWalking = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 17) { Ground = other.tag; }
    } 
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 17) { Ground = other.tag; }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 17) { Ground = ""; }
    }
}
