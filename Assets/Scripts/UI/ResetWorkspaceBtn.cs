using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetWorkspaceBtn : MonoBehaviour
{
    public PlaneControl WorkSpace;

    void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        WorkSpace.Reset();
    }
}
