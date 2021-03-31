using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name != "rz")
        Debug.Log(collision.collider.gameObject.name);

    }
}
