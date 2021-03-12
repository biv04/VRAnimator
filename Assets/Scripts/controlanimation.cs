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
    float positionOriginalx, positionOriginaly, positionOriginalz;

    public HandGrabbing handR;

    public Slider timeSlider;
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

        curvex = new AnimationCurve(keysx);
        curvey = new AnimationCurve(keysy);
        curvez = new AnimationCurve(keysz);
        clip.SetCurve("", typeof(Transform), "localPosition.x", curvex);

        clip.SetCurve("", typeof(Transform), "localPosition.y", curvey);

        clip.SetCurve("", typeof(Transform), "localPosition.z", curvez);

        anim.AddClip(clip, clip.name);
       

        Debug.Log("================" + curvex.keys[0].value);
    }


    private void Update()
    {
        
        setkeyClick(keyNum);
        Debug.Log("Frame: " + keyNum);
        Debug.Log("CurveValue (X): "  + curvex.keys[keyNum].value + " " + curvey.keys[keyNum].value + " " + curvez.keys[keyNum].value);
        

    }

    public void setkeySlider()
    {
        keyNum = (int)timeSlider.value;

            Vector3 tempPos = new Vector3(curvex.keys[keyNum].value, curvey.keys[keyNum].value, curvez.keys[keyNum].value);
            arm.transform.localPosition = tempPos;
        Debug.Log("TemporaryCurvePos: " + tempPos);

    }

    public void setkeyClick(int num)
    {

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
         */
        

        curvex = new AnimationCurve(keysx);
        curvey = new AnimationCurve(keysy);
        curvez = new AnimationCurve(keysz);

        clip.SetCurve("", typeof(Transform), "localPosition.x", curvex);

        clip.SetCurve("", typeof(Transform), "localPosition.y", curvey);

        clip.SetCurve("", typeof(Transform), "localPosition.z", curvez);

        anim.AddClip(clip, clip.name);
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
