using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;

public class HandGrabbing : OVRGrabber
{
    private OVRHand m_hand;
    public OVRHand other_hand;
    private float pinchThreshhold = 0.85f;
    public bool rotationOnly;
    public bool isPinch;
    public bool isGrabbed;

    public GameObject selectedJoint;


    protected override void Start()
    {
        base.Start();
        m_hand = GetComponent<OVRHand>();

    }

    public override void Update()
    {
        base.Update();
        CheckIndexPinch();
        if (m_hand.GetFingerPinchStrength(OVRHand.HandFinger.Index) > pinchThreshhold )
        {
            isPinch = true;
        }
        else isPinch = false;
    }

    void CheckIndexPinch()
    {
        float pinchStrength = m_hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
        if(!m_grabbedObj && pinchStrength > pinchThreshhold && m_grabCandidates.Count > 0)
        {
            Debug.Log("Pinched Detected");
            GrabBegin();

            //Scale environment object
            if (m_grabbedObj.tag == "EObj")
            {
                isGrabbed = true;

                //Debug.Log("DecoObj");
               float other_pinchStrength = other_hand.GetFingerPinchStrength(OVRHand.HandFinger.Index);
               if(other_pinchStrength> pinchThreshhold)
                {
                   // Debug.Log("BothHand");

                    float m_scale = (m_hand.transform.position - other_hand.transform.position).magnitude;
                    m_grabbedObj.transform.localScale = new Vector3(m_scale, m_scale, m_scale);
                }
            }

            if (m_grabbedObj.tag == "joint")
            {
                isGrabbed = true;

                Debug.Log("Grabbed Joint " + m_grabbedObj);
                selectedJoint = m_grabbedObj.gameObject;

            }

        }

        


        else if(m_grabbedObj && !(pinchStrength > pinchThreshhold))
        {
            isPinch = false;
            isGrabbed = false;
            GrabEnd();
        }

    }

 
}
