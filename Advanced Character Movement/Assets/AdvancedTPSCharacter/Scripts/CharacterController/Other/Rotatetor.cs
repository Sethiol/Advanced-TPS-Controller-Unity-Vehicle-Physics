using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatetor : MonoBehaviour
{
    public float Speed;
    public bool Forward = true;
    void FixedUpdate()
    {
        if (Forward)
        {
            transform.Rotate(0, Speed * Time.deltaTime, 0); //rotates 50 degrees per second around z axis
        }
        else
        {
            transform.Rotate(0, -Speed * Time.deltaTime, 0);
        }
    }
}
