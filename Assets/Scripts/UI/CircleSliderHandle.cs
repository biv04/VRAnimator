using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleSliderHandle : MonoBehaviour
{
    public CircleSlider circleSlider;
    public HandGrabbing handR, handL;
    public controlanimation controlanimation;
    public PlayButton PlayButton;
    public GameObject ColliderLeft, ColliderRight;

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

        if (circleSlider.currentHand.isPinch == false && isMove == true)
        {
            isMove = false;
        }




        //Disable the left collider on the first loop
        if (circleSlider.LoopNum == 0)
        {
            ColliderLeft.SetActive(false);
        }
        if (circleSlider.currentHand != null)
        {
            if (circleSlider.currentHand.isPinch == false)
                circleSlider.isDrag = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hand_IndexTip" && handL.isPinch)
        {
            circleSlider.currentHand = handL;

            circleSlider.isDrag = true;

            isMove = true;

        }

        else if (other.gameObject.name == "Hand_IndexTip" && handR.isPinch)
        {
            circleSlider.currentHand = handR;

            circleSlider.isDrag = true;

            isMove = true;

        }

        if (other.gameObject.CompareTag("LeftCollider"))
        {

            ColliderRight.SetActive(false);
            ColliderLeft.SetActive(false);

            Debug.Log("Left Collider, Decrease");
            circleSlider.DecreaseValue();

        }

        if (other.gameObject.CompareTag("RightCollider"))
        {
            ColliderLeft.SetActive(false);
            ColliderRight.SetActive(false);

            Debug.Log("Right Collider, Increase");
            circleSlider.increaseValue();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Hand_IndexTip" && handR.isPinch)
        {
            circleSlider.currentHand = handR;
            circleSlider.isDrag = true;
            isMove = true;
        }

        else if (other.gameObject.name == "Hand_IndexTip" && handL.isPinch)
        {
            circleSlider.currentHand = handL;
            circleSlider.isDrag = true;
            isMove = true;
        }
    }
}