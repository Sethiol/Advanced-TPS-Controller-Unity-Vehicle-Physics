using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject ReplacementObject;
    private Transform SpawnPosition;
    GameObject obj;
    public GameObject ReplaceObj;
    private Transform Parent;
    private MeshRenderer renderer;
    public void DestroyAndReplace()
    {
        SpawnPosition = null;
        SpawnPosition = gameObject.transform;
        Parent = transform.parent;
        obj = Instantiate(ReplacementObject, transform.position, transform.rotation);
        StartCoroutine(Respawn(obj));
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
    }
    IEnumerator Respawn(GameObject obj)
    {
        yield return new WaitForSeconds(2.0f);
        Destroy(obj);
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = true;
    }
}
