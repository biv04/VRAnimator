using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class handleController : MonoBehaviour
{
    bool grabbed = false;
    public HandGrabbing handR;
    public GameObject mypanel;

    Vector3 PanelStartPos, HandStartPos;
    float PanelMinY = -10f;


    // Start is called before the first frame update
    void Start()
    {
        mypanel.transform.position = new Vector3(mypanel.transform.position.x, PanelMinY, mypanel.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            // Vector2 min = new Vector3(handR.transform.position.x , handR.transform.position.y);
            mypanel.transform.position = new Vector3(mypanel.transform.position.x, PanelStartPos.y + ( handR.transform.position.y - HandStartPos.y), mypanel.transform.position.z);
            if (mypanel.transform.position.y < PanelMinY)
            {
                Debug.Log("Clamp");
                mypanel.transform.position = new Vector3(mypanel.transform.position.x, PanelMinY, mypanel.transform.position.z);
            }
        }



        if (!handR.isPinch)
            grabbed = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (handR.isPinch)
        {
            grabbed = true;
            PanelStartPos = mypanel.transform.position;
            HandStartPos = handR.transform.position;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (handR.isPinch)
        {
            grabbed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
      
           // grabbed = false;
        
    }

   


}
