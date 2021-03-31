using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirror : MonoBehaviour
{
    public GameObject FakeParent;
    private Transform _thisChild;
    private Vector3 _positionOffset;
    private Quaternion _rotationOffset;

    private void Start()
    {
        _thisChild = this.transform;

       
            SetFakeParent(FakeParent);
        
    }

    private void Update()
    {
        if (FakeParent == null)
            return;

        // Position the object on top of the parent
        _thisChild.position = FakeParent.transform.position;
        // Set the rotation based on the parent and stored offset rotation
        _thisChild.rotation = FakeParent.transform.rotation * _rotationOffset;
        // Move the child back to the reference location
        _thisChild.Translate(_positionOffset);
    }

    public void SetFakeParent(GameObject parent)
    {
        //Offset vector
        _positionOffset = _thisChild.InverseTransformPoint(_thisChild.position) - _thisChild.InverseTransformPoint(parent.transform.position) + new Vector3(0, 0, -0.345442f/2);
        //Offset rotation
        _rotationOffset = Quaternion.Inverse(parent.transform.rotation) * transform.rotation;
        //Our fake parent
        //FakeParent = parent;
    }
}
