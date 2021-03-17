using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class leftAnimain : MonoBehaviour
{
    // Animate the position and color of the GameObject
    public Animation anim;
    public AnimationCurve curvex, curvey, curvez;
    public AnimationClip clip;
    public GameObject arm;
    float positionx, positiony, positionz;

    Dictionary<int, float> prevPosx = new Dictionary<int, float>();
    Dictionary<int, float> prevPosy = new Dictionary<int, float>();
    Dictionary<int, float> prevPosz = new Dictionary<int, float>();
    public HandGrabbing handR;

    public Slider timeSlider;
    public bool isSet;
    private int keyNum;


    public void Start()
    {
        clip.legacy = true;

        // create a curve to move the GameObject and assign to the clip
        curvex = new AnimationCurve();
        curvey = new AnimationCurve();
        curvez = new AnimationCurve();
        clip.SetCurve("", typeof(Transform), "localPosition.x", curvex);

        clip.SetCurve("", typeof(Transform), "localPosition.y", curvey);

        clip.SetCurve("", typeof(Transform), "localPosition.z", curvez);

        anim.AddClip(clip, clip.name);


        //Debug.Log("================" + curvex.keys[0].value);
    }


    private void Update()
    {
        if (isSet)
        {
            setkeyClick(keyNum);

        }
        //Debug.Log("CurveValue (X): "  + curvex.keys[keyNum].value + " " + curvey.keys[keyNum].value + " " + curvez.keys[keyNum].value);

    }

    public void setkeySlider()
    {
        keyNum = (int)timeSlider.value;
        float time = keyNum / 24f;

        Vector3 tempPos = new Vector3();

        Debug.Log("Restore position");
        tempPos = new Vector3(curvex.Evaluate(time), curvey.Evaluate(time), curvez.Evaluate(time));
        arm.transform.localPosition = tempPos;

        // Debug.Log("TemporaryCurvePos: " + tempPos);

    }

    public void setkeyClick(int num)
    {
        float time = num / 24f;

        // Save the current position
        positionx = arm.transform.localPosition.x;
        positiony = arm.transform.localPosition.y;
        positionz = arm.transform.localPosition.z;


        //If the current frame has a previous position
        if (prevPosx.ContainsKey(num))
        {
            //If position changed
            if (prevPosx[num] != positionx || prevPosy[num] != positiony || prevPosz[num] != positionz)
            {
                int CurrentCurveIndex = 0;
                //Replace key if there's a key
                if (curvex.AddKey(time, positionx) == -1)
                {
                    for (int i = 0; i < curvex.length; i++)
                    {
                        if (curvex.keys[i].time == time)
                            CurrentCurveIndex = i;
                    }

                    curvex.RemoveKey(CurrentCurveIndex);
                    curvey.RemoveKey(CurrentCurveIndex);
                    curvez.RemoveKey(CurrentCurveIndex);

                    Debug.Log("Replace Key at Index " + CurrentCurveIndex);

                }

                //Add key
                curvex.AddKey(time, positionx);
                curvey.AddKey(time, positiony);
                curvez.AddKey(time, positionz);

                prevPosx.Remove(num);
                prevPosy.Remove(num);
                prevPosz.Remove(num);

                prevPosx.Add(num, positionx);
                prevPosy.Add(num, positiony);
                prevPosz.Add(num, positionz);

                Debug.Log("Add Key");

            }
        }

        else
        {
            prevPosx.Add(num, positionx);
            prevPosy.Add(num, positiony);
            prevPosz.Add(num, positionz);
            Debug.Log("Add to previous position");
        }


        clip.SetCurve("", typeof(Transform), "localPosition.x", curvex);

        clip.SetCurve("", typeof(Transform), "localPosition.y", curvey);

        clip.SetCurve("", typeof(Transform), "localPosition.z", curvez);

        anim.AddClip(clip, clip.name);


    }

    public void setJoint(string name)
    {

    }

    public void setFrame(int num)
    {
        keyNum = num;
    }


    public void play()
    {
        anim.Play(clip.name);
        // Debug.Log(curvex.keys);
    }

    public void Stop()
    {
        Debug.Log("TODO: Stop Animation");
    }
}
