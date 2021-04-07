using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale : MonoBehaviour
{
    public bool istouch;
    public Material highlightMat, defaultMat;
    public HandGrabbing handLeft, handRight;

    // Start is called before the first frame update
    void Start()
    {
        istouch = false;
        handLeft = GameObject.Find("/OVRCameraRig/TrackingSpace/LeftHandAnchor/OVRHandPrefab").GetComponent<HandGrabbing>();
        handRight = GameObject.Find("/OVRCameraRig/TrackingSpace/RightHandAnchor/OVRHandPrefab").GetComponent<HandGrabbing>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name== "Hand_IndexTip")
        {
                gameObject.GetComponent<MeshRenderer>().material = highlightMat;
        }
        
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Hand_IndexTip")
        {
            if (handLeft.isPinch || handRight.isPinch)
            {
                istouch = true;
                gameObject.GetComponent<MeshRenderer>().material = highlightMat;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (handLeft.isPinch == false || handRight.isPinch == false)
        {
            istouch = false;
            gameObject.GetComponent<MeshRenderer>().material = defaultMat;
        }

    }
}
