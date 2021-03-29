using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyframeMenuChild : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hand_IndexTip")
        {
            transform.parent.GetComponent<KeyframeMenu>().CollisionDetected(this.gameObject);
        }
    }
}
