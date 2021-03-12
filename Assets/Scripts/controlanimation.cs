using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class controlanimation : MonoBehaviour
{
    // Animate the position and color of the GameObject
    public Animation anim;
    public AnimationCurve curvex,curvey,curvez;
    public Keyframe[] keysx;
    public Keyframe[] keysy;
    public Keyframe[] keysz;
    public AnimationClip clip;
    public GameObject arm;
    float positionx, positiony, positionz;
    //float prevPosX, prevPosY, prevPosZ;

    public float[] prevPosx;
    public float[] prevPosy;
    public float[] prevPosz;

    public HandGrabbing handR;

    public Slider timeSlider;
    public bool isMove;
    private int keyNum;

    public void Start()
    {
     
        // create a new AnimationClip
        //clip = new AnimationClip();
        clip.legacy = true;

        // create a curve to move the GameObject and assign to the clip

        Keyframe[] keysx = new Keyframe[]{};
        Keyframe[] keysy = new Keyframe[]{};
        Keyframe[] keysz = new Keyframe[]{};

        prevPosx = new float[240] ;
        prevPosy = new float[240] ;
        prevPosz = new float[240] ;

        Debug.Log("PrevPosList: " + prevPosx[0]);

        //keysx = new Keyframe[24]; keysy = new Keyframe[24]; keysz = new Keyframe[24];



        /*
     for(int i = 0; i < keysx.Length; i++)
     {
         keysx[i] = new Keyframe((float)i, 1);
         keysy[i] = new Keyframe((float)i, 2);
         keysz[i] = new Keyframe((float)i, 3);

     }

     Debug.Log("====================" + keysx[0].value);
     Debug.Log("====================" + keysx[1].value);
     Debug.Log("====================" + keysx[2].value);
      */

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
        
        setkeyClick(keyNum);
        //Debug.Log("CurveValue (X): "  + curvex.keys[keyNum].value + " " + curvey.keys[keyNum].value + " " + curvez.keys[keyNum].value);

    }

    public void setkeySlider()
    {

        keyNum = (int)timeSlider.value;
        Vector3 tempPos = new Vector3();

        // Check if there was a previous key, if not just add a key
        if (keyNum < curvex.length)
        {
            Debug.Log("Please work");
            tempPos = new Vector3(curvex.keys[keyNum].value, curvey.keys[keyNum].value, curvez.keys[keyNum].value);
            arm.transform.localPosition = tempPos;
        }

       // Debug.Log("TemporaryCurvePos: " + tempPos);

    }

    public void setkeyClick(int num)
    {
        float time = num / 24f;


        positionx = arm.transform.localPosition.x;
        positiony = arm.transform.localPosition.y;
        positionz = arm.transform.localPosition.z;

        Debug.Log("Num: " + num);
        // Debug.Log("ArmPosition: " + positionx);


        Debug.Log("PrevPosList: " + prevPosx[0]);

            //If position changed
            if (prevPosx[num] != positionx || prevPosy[num] != positiony || prevPosz[num] != positionz)
            {
                //Add key if index does not exist
                if (num >= curvex.length)
                {
                    curvex.AddKey(time, positionx);
                    curvey.AddKey(time, positiony);
                    curvez.AddKey(time, positionz);
                    Debug.Log("Add Value: " + curvex.keys[num].value);

                }


                //Replace key if there's a key
                else if (curvex.AddKey(curvex.keys[num]) == -1)
                {
                    curvex.RemoveKey(num);
                    curvey.RemoveKey(num);
                    curvez.RemoveKey(num);

                    curvex.AddKey(time, positionx);
                    curvey.AddKey(time, positiony);
                    curvez.AddKey(time, positionz);
                    Debug.Log("Arm Value: " + positionx);

                    Debug.Log("Replaced Value: " + curvex.keys[num].value);


                }
            }


        else
        {
            //  Debug.LogError("Index?" + curvex.AddKey(curvex.keys[0]));
            Debug.Log("ELSEEEEEE");
        }

        /*
        positionx = arm.transform.localPosition.x;
        keysx[num].value = positionx;

        positiony = arm.transform.localPosition.y;
        keysy[num].value = positiony;

        //keysy[num] = new Keyframe((float)num, positiony);

        positionz = arm.transform.localPosition.z;
        keysz[num].value = positionz;

        //keysz[num] = new Keyframe((float)num, positionz);
        Debug.Log("KeySet " + keyNum);




        /*
        curve.keys[num] = new Keyframe((float)num, positionx);
        curve.keys[num] = new Keyframe((float)num, positiony);
        curve.keys[num] = new Keyframe((float)num, positionz);

        curvex.keys[num].value = positionx;
            curvey.keys[num].value = positiony;
            curvez.keys[num].value = positionz;
        */


        clip.SetCurve("", typeof(Transform), "localPosition.x", curvex);

        clip.SetCurve("", typeof(Transform), "localPosition.y", curvey);

        clip.SetCurve("", typeof(Transform), "localPosition.z", curvez);

        anim.AddClip(clip, clip.name);

        prevPosx[num] = arm.transform.localPosition.x;
        prevPosy[num] = arm.transform.localPosition.y;
        prevPosz[num] = arm.transform.localPosition.z;

        // Debug.Log("CurveLength: " + curvex.length);
        // Debug.Log("Time: " + time);
        // Debug.Log("Frame: " + keyNum);



    }

    public void setJoint(string name)
    {
      
    }

    /*
    public void setkey0()
    {
       
        positionx = arm.transform.localPosition.x;
        Debug.LogError(positionx);
        keys[0] = new Keyframe(0.0f, positionx);

        positiony = arm.transform.localPosition.y;
        keysy[0] = new Keyframe(0.0f, positiony);

        positionz = arm.transform.localPosition.z;
        keysz[0] = new Keyframe(0.0f, positionz);
        Debug.Log("KeySet1");
    }
    public void setkey1()
    {
       
        positionx = arm.transform.localPosition.x;
        keys[1] = new Keyframe(1.0f, positionx);

        positiony = arm.transform.localPosition.y;
        keysy[1] = new Keyframe(1.0f, positiony);

        positionz = arm.transform.localPosition.z;
        keysz[1] = new Keyframe(1.0f, positionz);
    }
    public void setkey2()
    {
       
        positionx = arm.transform.localPosition.x;
        keys[2] = new Keyframe(2.0f, positionx);

        positiony = arm.transform.localPosition.y;
        keysy[2] = new Keyframe(2.0f, positiony);

        positionz = arm.transform.localPosition.z;
        keysz[2] = new Keyframe(2.0f, positionz);
    }

    public void setkey3()
    {

        positionx = arm.transform.localPosition.x;
        keys[3] = new Keyframe(3.0f, positionx);

        positiony = arm.transform.localPosition.y;
        keysy[3] = new Keyframe(3.0f, positiony);

        positionz = arm.transform.localPosition.z;
        keysz[3] = new Keyframe(3.0f, positionz);
    }
    */

    

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
