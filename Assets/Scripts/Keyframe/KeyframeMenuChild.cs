using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyframeMenuChild : MonoBehaviour
{
    public HandGrabbing handR;

    private void Awake()
    {
        handR = (HandGrabbing)GameObject.FindObjectOfType(typeof(HandGrabbing));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hand_IndexTip" && handR.isPinch == false)
        {
            transform.parent.GetComponent<KeyframeMenu>().CollisionDetected(this.gameObject);
        }
    }
}
