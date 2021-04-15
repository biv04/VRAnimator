using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlacer : MonoBehaviour
{ 

    public LargeGrid LargeGrid;
    public GameObject objPrefab;
    private GameObject child;

    public HandGrabbing handR;

    GameObject parent;
    bool isAttach;
    
    Color originalColor;
   

    private void Awake()
    {
        LargeGrid = FindObjectOfType<LargeGrid>();
        originalColor = gameObject.GetComponent<Renderer>().material.color;
        handR = (HandGrabbing) GameObject.FindObjectOfType(typeof(HandGrabbing));
    }

    private void Update()
    {
        if(gameObject.GetComponent<Renderer>().material.color == Color.red)
        {
            StartCoroutine(RestoreColor(0.2f));

        }
        if (child)
        {
            //child.transform.position = gameObject.transform.position - pOffset;
            //child.transform.localPosition = gameObject.transform.localPosition - pOffset;
            child.transform.localRotation = gameObject.transform.localRotation;
            child.transform.localScale = gameObject.transform.localScale * 8f;

        }

        if (isAttach)
        {
            Debug.Log("ParentName: " + parent.name);
            gameObject.transform.position = parent.transform.position;
        }

    }
    

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Indicator") && child == null)
        {
            gameObject.transform.position = other.transform.position;
            Vector3 eulerRotation = transform.rotation.eulerAngles;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

            child = LargeGrid.Spawnfile("L" + other.name, objPrefab);

            //pOffset = gameObject.transform.position - child.transform.position;
            // rOffset = gameObject.transform.localRotation;

            Vector3 temp = gameObject.transform.position;
            gameObject.transform.parent = null;
            gameObject.transform.position = temp;

            parent = other.gameObject;
            isAttach = true;
        }

        else if (other.CompareTag("Indicator"))
        {
            child.transform.position = LargeGrid.GetPosition("L" + other.name).position;

            parent = other.gameObject;
            isAttach = true;

        }


        // Delete on double tap
        else if (other.transform.gameObject.name == "Hand_IndexTip" && handR.isPinch == false)
        {
            if (gameObject.GetComponent<Renderer>().material.color == Color.red)
            {
                gameObject.SetActive(false);
                GameObject.Destroy(child);
            }
            else
                gameObject.GetComponent<Renderer>().material.color = Color.red;


        }

        else
            isAttach = false;



    }

    private void OnTriggerStay(Collider other)
    {
        /*
        if (other.CompareTag("Indicator") )
            gameObject.transform.position = other.transform.position;
        */
    }

    IEnumerator RestoreColor(float second)
    {
        yield return new WaitForSeconds(second);
        gameObject.GetComponent<Renderer>().material.color = originalColor;
    }



}
