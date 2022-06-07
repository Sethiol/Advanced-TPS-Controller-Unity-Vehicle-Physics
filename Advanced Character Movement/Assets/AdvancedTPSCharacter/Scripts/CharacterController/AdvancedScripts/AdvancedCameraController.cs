using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedCameraController : MonoBehaviour
{
    [SerializeField] private bool LockCursor;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void LateUpdate()
    {
        if (FindObjectOfType<UIController>().CancelAllMovement == true)
        {
           Cursor.visible = true;
           Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
