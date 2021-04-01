using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class handleController : MonoBehaviour
{
    bool grabbed = false;
    public HandGrabbing handR;
    public GameObject mypanel;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed)
        {
            // Vector2 min = new Vector3(handR.transform.position.x , handR.transform.position.y);
            mypanel.transform.position = new Vector3(mypanel.transform.position.x, handR.transform.position.y, mypanel.transform.position.z);
           
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (handR.isPinch)
        {
            grabbed = true;

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
      
            grabbed = false;
        
    }

   


}
