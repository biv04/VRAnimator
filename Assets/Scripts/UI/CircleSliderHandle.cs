using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSliderHandle : MonoBehaviour
{
    public CircleSlider circleSlider;
    public HandGrabbing handR;
    public controlanimation controlanimation;
    public PlayButton PlayButton;

    bool isMove;


    private void Update()
    {
        if (isMove || PlayButton.isPlaying)
        {
            controlanimation.isSet = false;
        }
        else
        {
            controlanimation.isSet = true;
        }

        if(handR.isPinch == false && isMove == true)
        {
            isMove = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (handR.isPinch)
        {
            circleSlider.isDrag = true;
            isMove = true;

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (handR.isPinch)
        {
            circleSlider.isDrag = true;
            isMove = true;
        }
    }
}
