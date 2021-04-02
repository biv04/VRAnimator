using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increasenumber : MonoBehaviour
{
    public CircleSlider circleSliderscript = new CircleSlider();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigered");
        circleSliderscript.LoopNum++;
       
    }
}
