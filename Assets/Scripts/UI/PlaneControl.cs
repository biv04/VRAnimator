using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    Transform sObject;
    Vector3 originalPos;
    Quaternion originalRotate;
    public Transform lObject;

    public HandGrabbing handGrabbingL, handGrabbingR;
    public GameObject handL, handR, cube;
    public bool GrabThis;
    float prevX, prevY, prevZ;

    void Start()
    {
        sObject = this.gameObject.transform;
        originalPos = sObject.transform.position;
        originalRotate = sObject.transform.rotation;

    }

    void Update()
    {

        
        if (GrabThis)
        {
            DisableOffset();
            RotateThis();
            TranslateThis();
        }

        else
        {
            EnableOffset();
        }

        prevX = handR.transform.localPosition.x;
        prevY = handR.transform.localPosition.y;
        prevZ = handR.transform.localPosition.z;


        //Update large grid rotation;
        lObject.transform.localRotation = sObject.transform.localRotation;

        if (handGrabbingR.isPinch == false)
        {
            GrabThis = false;
            handGrabbingR.isGrabbed = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if ( handGrabbingR.isPinch == true && handGrabbingR.isGrabbed == false)
        {
            GrabThis = true;
            handGrabbingR.isGrabbed = true;
        }

        else
            Debug.Log("Not Pinching");
    }

    private void OnTriggerExit(Collider other)
    {
    }

    void RotateThis()
    {

        float delta = handR.transform.localPosition.x - prevX;

        //float delta = handR.transform.localPosition.x - prevX;
        sObject.transform.Rotate(0, -delta * 360, 0);

        Debug.Log("Rotated!");

    }


    void TranslateThis()
    {
        float delta = handR.transform.localPosition.y - prevY;
        float deltaz = handR.transform.localPosition.z - prevZ;
        sObject.transform.Translate(0, delta, -deltaz);

        Debug.Log("Translated!");
    }
    public void Reset()
    {
        Debug.Log("reset");
        sObject.transform.position = originalPos;
        sObject.transform.rotation = originalRotate;
    }

    void DisableOffset()
    {
        GameObject[] varGameObject = GameObject.FindGameObjectsWithTag("joint");
        foreach(GameObject joint in varGameObject)
            joint.GetComponent<Offset>().enabled = false;
    }

    void EnableOffset()
    {

        GameObject[] varGameObject = GameObject.FindGameObjectsWithTag("joint");
        foreach(GameObject joint in varGameObject)
            joint.GetComponent<Offset>().enabled = true;

    }
}
