using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    Camera camera;
    Ray ray;
    RaycastHit hitinfo;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = camera.transform.position;
        ray.direction = camera.transform.forward;
        if (Physics.Raycast(ray, out hitinfo))
        {
            transform.position = hitinfo.point;
        }
        else
        {
            transform.position = ray.origin + ray.direction * 1000.0f;
        }
    }
}
