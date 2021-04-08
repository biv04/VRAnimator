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
    public float distance;
    private float currentDistance;
    public GameObject handLeft,handRight;
    public GameObject sphere1, sphere2;
    scale sphere1Script, sphere2Script;

    float prevScale = 0;


    private void Start()
    {
        
        sphere1 = Instantiate(Resources.Load("SpherePrefab") as GameObject);
        sphere2 = Instantiate(Resources.Load("SpherePrefab") as GameObject);
        sphere1.transform.SetParent(gameObject.transform);
        sphere2.transform.SetParent(gameObject.transform);

        sphere1Script = sphere1.GetComponent<scale>();
        sphere2Script = sphere2.GetComponent<scale>();

        //sphere1 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere1.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);

        //sphere2 = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere2.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        //sphere1.transform.position = new Vector3(0, 1.5f, 0);
        distance = 0.4f;
        handLeft = GameObject.Find("/OVRCameraRig/TrackingSpace/LeftHandAnchor/OVRHandPrefab");
        handRight = GameObject.Find("/OVRCameraRig/TrackingSpace/RightHandAnchor/OVRHandPrefab");
        lr = GetComponent<LineRenderer>();
        lr.widthMultiplier = 0.2f;
        lr.positionCount = lengthOfLineRenderer;
        positionList = new Vector3[lengthOfLineRenderer];


    }
    void Update()
    {

        currentDistance = Vector3.Distance(transform.position, handLeft.transform.position);

       // Debug.Log(currentDistance);

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
        sphere1.transform.position = v3BackTopRight;
        sphere2.transform.position = v3FrontBottomLeft;



        if (currentDistance < distance)
        {
            if (!lr.enabled)
            {
                lr.enabled = !lr.enabled;
                sphere1.SetActive(true);
                sphere2.SetActive(true);

            }
            
        }
        else 
        {
            if (lr.enabled)
            {
                lr.enabled = !lr.enabled;
                sphere1.SetActive(false);
                sphere2.SetActive(false);
            }

        }

        if (sphere1Script.istouch && sphere2Script.istouch)
        {

            float m_scale = (handLeft.transform.position - handRight.transform.position).magnitude;
            //Vector3 m_scale = handLeft.transform.position - handRight.transform.position;
            if (prevScale == 0)
            {
                prevScale = m_scale;
            }
            float scaleDiff = m_scale - prevScale;
            gameObject.transform.localScale += new Vector3 (scaleDiff, scaleDiff, scaleDiff);
           
            prevScale = m_scale;
        }

        if (!gameObject.activeSelf)
        {
           sphere1.SetActive(false);
            sphere2.SetActive(false);
        }
    }




}
