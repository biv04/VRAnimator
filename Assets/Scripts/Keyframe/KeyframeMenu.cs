using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyframeMenu : MonoBehaviour
{
    public GameObject frameCanvas;
    public GameObject keyCanvas;
    public Material highlightMat;
    public GameObject circleSlider;

    GameObject selectedFrame;
    public int keyNum;
    
    bool isOn;
    // Start is called before the first frame update
    void Start()
    {
        frameCanvas.SetActive(false);
        keyCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOn)
        {
            keyNum = int.Parse(selectedFrame.name.Substring(5)) ;
            Vector3 dir = (selectedFrame.transform.position - circleSlider.transform.position).normalized;
            //If there is a key there, display keycanvas
            if(selectedFrame.GetComponent<MeshRenderer>().material.color == highlightMat.color)
            {
                frameCanvas.SetActive(false);
                keyCanvas.SetActive(true);
                keyCanvas.transform.position = circleSlider.transform.position + dir * 0.2f;
            }

            else
            {

                frameCanvas.SetActive(true);
                keyCanvas.SetActive(false);
                frameCanvas.transform.position = circleSlider.transform.position + dir * 0.16f;

            }
        }

        else
        {
            frameCanvas.SetActive(false);
            keyCanvas.SetActive(false);
        }
    } 

    public void CollisionDetected(GameObject child)
    {
        isOn = true;
        selectedFrame = child;
        Debug.Log("Collided With Child: " + child.name);
    }

    public void TurnOffCanvas()
    {
        isOn = false;
    }
}
