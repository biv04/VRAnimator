using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{
    private Grid grid;
    private Vector3 pOffset, rOffset;
    private float mZCoord;

    public LargeGrid LargeGrid;
    public GameObject objPrefab;
    private GameObject child;

    HandGrabbing handR;
    

   

    private void Awake()
    {
        grid = FindObjectOfType<Grid>();
        LargeGrid = FindObjectOfType<LargeGrid>();

        handR = (HandGrabbing) GameObject.FindObjectOfType(typeof(HandGrabbing));
    }

    private void Update()
    {

        if (child)
        {
            Debug.Log("Has Child");
            //child.transform.position = gameObject.transform.position - pOffset;
            //child.transform.localPosition = gameObject.transform.localPosition - pOffset;
            child.transform.localRotation = gameObject.transform.localRotation;
            child.transform.localScale = gameObject.transform.localScale * 8f;

        }

    }
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Indicator") && child == null)
        {
            gameObject.transform.position = other.transform.position;
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            Debug.Log("Pos:" + other.name);
            child = LargeGrid.Spawnfile("L" + other.name, objPrefab);

            pOffset = gameObject.transform.position - child.transform.position;
            // rOffset = gameObject.transform.localRotation;

            Vector3 temp = gameObject.transform.position;
            gameObject.transform.parent = null;
            gameObject.transform.position = temp;
        }

        else if (other.CompareTag("Indicator"))
        {
            child.transform.position = LargeGrid.GetPosition("L" + other.name).position;
        }

        // Delete on double tap
        else if (other.transform.gameObject.name == "Hand_IndexTip" && handR.isPinch == false)
        {
            Debug.Log("Index Touched");
            gameObject.GetComponent<Renderer>().material.color = Color.red;

        }



    }

    private void OnTriggerStay(Collider other)
    {
        /*
        if (other.CompareTag("Indicator") )
            gameObject.transform.position = other.transform.position;
        */
    }



}
