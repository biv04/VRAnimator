using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offset : MonoBehaviour
{
    Transform sObject;
    public Transform[] lObject =  new Transform[3];
	public bool fixedPos;
	public PlaneControl plane;
	//int objNum = 1;
	
   
    //Position
    Vector3 oldPosition, newPosition, posDiff;
    //Rotation
    Quaternion oldRotate, newRotate, rotDiff;

    void Start()
    {
		plane= (PlaneControl) GameObject.FindObjectOfType (typeof(PlaneControl));
        sObject = this.gameObject.transform;
        oldPosition = sObject.position;
        oldRotate = sObject.rotation;


    }

    void Update()
    {
				
        //Store new Position & rotation
        newPosition = sObject.position;
        //newRotate = sObject.rotation;

        //Calculte difference in small object
        posDiff = newPosition - oldPosition;
        //rotDiff = newRotate * Quaternion.Inverse(oldRotate);
        
		
		//Apply difference to large object
	    for(int i = 0; i<lObject.Length; i++){
		if(!fixedPos){
		    lObject[i].position += posDiff*4;
		}
		lObject[i].localRotation = sObject.transform.localRotation;
		}
        //Set oldPos to current position
        oldPosition = sObject.position;

       


        // new way
		/*
        lObject[objNum].localRotation = sObject.transform.localRotation;
        lObject[objNum].localPosition = sObject.transform.localPosition;
    */
	}

    public void Reset()
    {
        oldPosition = sObject.position;
        oldRotate = sObject.rotation;
    }
}
