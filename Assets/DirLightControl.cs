using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirLightControl : MonoBehaviour
{
    public Light DirectionalLight;
    public HandGrabbing handL, handR;
    public GameObject handLObj, handRObj;
    float prevX, prevY, prevZ;

    bool isRotate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(isRotate)   RotateThis();
        if (isRotate && handR.isPinch == false) isRotate = false;
     

        prevX = handRObj.transform.localPosition.x;
        prevY = handRObj.transform.localPosition.y;
        prevZ = handRObj.transform.localPosition.z;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hand_IndexTip" && handR.isPinch)
            isRotate = true;

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Hand_IndexTip" && handR.isPinch)
            isRotate = true;

    }
    void RotateThis()
    {
        
       float deltaX = handRObj.transform.localPosition.x - prevX;
       float deltaY = handRObj.transform.localPosition.y - prevY;
       float deltaZ = handRObj.transform.localPosition.z - prevZ;


       //float delta = handR.transform.localPosition.x - prevX;
       gameObject.transform.Rotate(0, -deltaY * 360, deltaX * 360);
       DirectionalLight.transform.Rotate(0, -deltaY * 360, deltaX * 360);

       Debug.Log("deltaX = " + deltaX);
        Debug.Log("prevX = " + prevX);



        /*
       transform.localRotation = handR.transform.localRotation;
       DirectionalLight.transform.localRotation = handR.transform.localRotation;
       

        transform.rotation = new Quaternion(handR.transform.rotation.x, handR.transform.rotation.y, handR.transform.rotation.z, 1);
        DirectionalLight.transform.rotation = new Quaternion(handR.transform.rotation.x, handR.transform.rotation.y, handR.transform.rotation.z, 1);
    */
    }

    public void ControlIntensity(float num)
    {
        DirectionalLight.intensity = num +0.5f;
    }
}
