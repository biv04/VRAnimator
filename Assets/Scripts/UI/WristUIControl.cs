using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristUIControl : MonoBehaviour
{
    SkinnedMeshRenderer skinnedMesh;
    public GameObject WristUI;
    public GameObject customizationCanvas, workspaceCanvas;
    private void Start()
    {
        skinnedMesh = GetComponent<SkinnedMeshRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        //Deactivate if can't find SkinMeshRenderer
        if (skinnedMesh.enabled)
            WristUI.SetActive(true);

        else
            WristUI.SetActive(false);

        //Only display the closest canvas
        if(customizationCanvas.transform.position.z < workspaceCanvas.transform.position.z)
        {
            workspaceCanvas.SetActive(false);
            customizationCanvas.SetActive(true);
        }

        else
        {
            
            customizationCanvas.SetActive(false);
            workspaceCanvas.SetActive(true);
        }

    }
}
