using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollActivation : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponentInParent<AdvancedCharacterMovement>().ActivateRagdoll();
        }
    }
}
