using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWorkspaceBtn : MonoBehaviour
{
    public GameObject WorkSpace;
    Vector3 originalPos;
    Quaternion originalRot;
    void Start()
    {
        originalPos = WorkSpace.transform.position;
        originalRot = WorkSpace.transform.rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        WorkSpace.transform.position = originalPos;
        WorkSpace.transform.rotation = originalRot;
    }
}
