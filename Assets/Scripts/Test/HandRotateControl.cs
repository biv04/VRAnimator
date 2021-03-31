using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandRotateControl : MonoBehaviour
{

    public GameObject rHand;
    public Vector3 offset;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      
        //transform.position = new Vector3 (rHand.transform.position.x, rHand.transform.position.y, rHand.transform.position.z) + offset;

        transform.rotation = new Quaternion(rHand.transform.rotation.x, rHand.transform.rotation.y, rHand.transform.rotation.z, 1);
    }
}
