using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyframeMenu : MonoBehaviour
{
    public GameObject frameCanvas;
    public GameObject keyCanvas;
    public Material highlightMat;

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
            //If there is a key there, display keycanvas
            if(gameObject.GetComponent<MeshRenderer>().material.color == highlightMat.color)
            {
                frameCanvas.SetActive(false);
                keyCanvas.SetActive(true);
            }

            else
            {
                frameCanvas.SetActive(true);
                keyCanvas.SetActive(false);
            }
        }

        else
        {
            frameCanvas.SetActive(false);
            keyCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hand_IndexTip")
        {
            isOn = !isOn;
        }
    }
}
