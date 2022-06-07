using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    bool Switch;
    private void Start()
    {
        Switch = false;
    }
    private void Update()
    {
        if (transform.position.x >= -0.45f && Switch)
        {
            transform.position = new Vector3(-0.46f, transform.position.y, transform.position.z);
            SwitchDirection();
            Switch = false;
        }
        else if(transform.position.x <= -14.19f && Switch)
        {
            transform.position = new Vector3(-14.18f, transform.position.y, transform.position.z);
            SwitchDirection();
            Switch = false;
        }
        Switch = true;
        GetComponent<Rigidbody>().velocity = speed * direction * Time.deltaTime;
    }
    private void SwitchDirection()
    {
        direction = new Vector3(direction.x * (-1), direction.y, direction.z);
    }
}
