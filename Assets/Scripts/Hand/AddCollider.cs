using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollider : MonoBehaviour
{
    bool hasCollider;

    void Start()
    {


        // Add collider to tip of index finger
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.Find("Bones") && hasCollider == false)
        {

            Debug.Log("found");
            Transform parent = transform.Find("Bones");

            //var test = parent.Find("Hand_Start/Hand_ForearmStub");
            var target0 = parent.Find("Hand_Start/Hand_Thumb0/Hand_Thumb1/Hand_Thumb2/Hand_Thumb3/Hand_ThumbTip");
            var target1 = parent.Find("Hand_Start/Hand_Index1/Hand_Index2/Hand_Index3/Hand_IndexTip");
            var target2 = parent.Find("Hand_Start/Hand_Middle1/Hand_Middle2/Hand_Middle3/Hand_MiddleTip");
            var target3 = parent.Find("Hand_Start/Hand_Ring1/Hand_Ring2/Hand_Ring3/Hand_RingTip");
            var target4 = parent.Find("Hand_Start/Hand_Pinky0/Hand_Pinky1/Hand_Pinky2/Hand_Pinky3/Hand_PinkyTip");

            if(target0 != null)
            {
                Debug.Log("not null");
            }
            
            
            target0.gameObject.AddComponent<CapsuleCollider>();
            target0.GetComponent<CapsuleCollider>().radius = 0.01f;
            target0.GetComponent<CapsuleCollider>().height = 0.01f;

            
            target1.gameObject.AddComponent<CapsuleCollider>();
            target1.GetComponent<CapsuleCollider>().radius = 0.01f;
            target1.GetComponent<CapsuleCollider>().height = 0.01f;

            target2.gameObject.AddComponent<CapsuleCollider>();
            target2.GetComponent<CapsuleCollider>().radius = 0.01f;
            target2.GetComponent<CapsuleCollider>().height = 0.01f;

            target3.gameObject.AddComponent<CapsuleCollider>();
            target3.GetComponent<CapsuleCollider>().radius = 0.01f;
            target3.GetComponent<CapsuleCollider>().height = 0.01f;

            target4.gameObject.AddComponent<CapsuleCollider>();
            target4.GetComponent<CapsuleCollider>().radius = 0.01f;
            target4.GetComponent<CapsuleCollider>().height = 0.01f;
           

            hasCollider = true;
        }
        
    }
}
