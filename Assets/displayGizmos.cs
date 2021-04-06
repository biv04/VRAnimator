using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[ExecuteInEditMode()]

public class displayGizmos : MonoBehaviour
{
    public Color color = Color.green;

    private Vector3 v3FrontTopLeft;
    private Vector3 v3FrontTopRight;
    private Vector3 v3FrontBottomLeft;
    private Vector3 v3FrontBottomRight;
    private Vector3 v3BackTopLeft;
    private Vector3 v3BackTopRight;
    private Vector3 v3BackBottomLeft;
    private Vector3 v3BackBottomRight;
    private LineRenderer lr;
    private Transform[] points;
    public int lengthOfLineRenderer = 16;
    private Vector3[] positionList = new Vector3[16];
   

    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.widthMultiplier = 0.2f;
        lr.positionCount = lengthOfLineRenderer;
        positionList = new Vector3[lengthOfLineRenderer];

    }
    void Update()
    {
        

        Bounds bounds = GetComponent<MeshFilter>().sharedMesh.bounds;

        

        Vector3 v3Center = bounds.center;
        Vector3 v3Extents = bounds.extents;

        v3FrontTopLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  // Front top left corner
        v3FrontTopRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z - v3Extents.z);  // Front top right corner
        v3FrontBottomLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  // Front bottom left corner
        v3FrontBottomRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z - v3Extents.z);  // Front bottom right corner
        v3BackTopLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  // Back top left corner
        v3BackTopRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y + v3Extents.y, v3Center.z + v3Extents.z);  // Back top right corner
        v3BackBottomLeft = new Vector3(v3Center.x - v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);  // Back bottom left corner
        v3BackBottomRight = new Vector3(v3Center.x + v3Extents.x, v3Center.y - v3Extents.y, v3Center.z + v3Extents.z);  // Back bottom right corner

        v3FrontTopLeft = transform.TransformPoint(v3FrontTopLeft);
        v3FrontTopRight = transform.TransformPoint(v3FrontTopRight);
        v3FrontBottomLeft = transform.TransformPoint(v3FrontBottomLeft);
        v3FrontBottomRight = transform.TransformPoint(v3FrontBottomRight);
        v3BackTopLeft = transform.TransformPoint(v3BackTopLeft);
        v3BackTopRight = transform.TransformPoint(v3BackTopRight);
        v3BackBottomLeft = transform.TransformPoint(v3BackBottomLeft);
        v3BackBottomRight = transform.TransformPoint(v3BackBottomRight);


        positionList[0] = v3FrontTopLeft;
        positionList[1] = v3FrontBottomLeft;
        positionList[2] = v3FrontBottomRight;
        positionList[3] = v3FrontTopRight;
        positionList[4] = v3FrontTopLeft;
        positionList[5] = v3BackTopLeft;
        positionList[6] = v3BackBottomLeft;
        positionList[7] = v3FrontBottomLeft;


        positionList[8] = v3FrontBottomRight;
        positionList[9] = v3BackBottomRight;
        positionList[10] = v3BackBottomLeft;


        positionList[11] = v3BackBottomRight;
        positionList[12] = v3BackTopRight;
        positionList[13] = v3BackTopLeft;


        positionList[14] = v3BackTopRight;
        positionList[15] = v3FrontTopRight;
        //positionList[16] = v3BackTopLeft;
        lr.SetPositions(positionList);
    }

   
    

}
     