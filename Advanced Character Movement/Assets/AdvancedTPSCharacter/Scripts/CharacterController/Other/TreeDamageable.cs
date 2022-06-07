using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDamageable : MonoBehaviour
{
    [SerializeField] private GameObject Top;
    [SerializeField] private GameObject Bottom;
    public void Break()
    {
        Instantiate(Top, new Vector3(transform.localPosition.x, Top.transform.position.y, transform.localPosition.z), Quaternion.Euler(5,0,0));
        Instantiate(Bottom, new Vector3(transform.localPosition.x, Top.transform.position.y, transform.localPosition.z), Quaternion.Euler(0, 0, 5));
        Destroy(gameObject);
    }
}