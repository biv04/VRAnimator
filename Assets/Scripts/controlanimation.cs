using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class controlanimation : MonoBehaviour
{
    // Animate the position and color of the GameObject
    public Animation anim;
    //public AnimationCurve curvex,curvey,curvez;
    public AnimationClip clip;
    float positionx, positiony, positionz, rotationx, rotationy, rotationz;

    Dictionary<int, float> prevPosx = new Dictionary<int, float>();
    Dictionary<int, float> prevPosy = new Dictionary<int, float>();
    Dictionary<int, float> prevPosz = new Dictionary<int, float>();


    // rotation //
    Dictionary<int, float> prevRotx = new Dictionary<int, float>();
    Dictionary<int, float> prevRoty = new Dictionary<int, float>();
    Dictionary<int, float> prevRotz = new Dictionary<int, float>();
    // end rotation //

    private GameObject arm;
    public HandGrabbing handR;
    private string path;

    //public Slider timeSlider;
    public CircleSlider CircleSlider;
    public GameObject CircleSliderHandle;
    public bool isSet;
    private int keyNum, prevKeyNum;
    public List<GameObject> GameObjectJoints;
    List<Joint> joints = new List<Joint>();

    int jointIndex = 0;
    GameObject obj;
    // private Joint LeftArmJoint, RightArmJoint, RightLegJoint, LeftLegJoint;;



    public void Start()
    {

        clip.ClearCurves();

        //   List<Joint> joints = new List<Joint>();
        Joint LeftArmJoint = new Joint("LeftArmJoint");
        Joint RightArmJoint = new Joint("RightArmJoint");
        Joint RightLegJoint = new Joint("RightLegJoint");
        Joint LeftLegJoint = new Joint("LeftLegJoint");

        Joint NeckJoint = new Joint("NeckJoint");
        Joint SpineJoint = new Joint("SpineJoint");
        Joint LeftKneeJoint = new Joint("LeftKneeJoint");
        Joint RightKneeJoint = new Joint("RightKneeJoint");
        //  Joint WaistJoint = new Joint("WaistJoint");
        //  Joint NeckJoint = new Joint("NeckJoint");



        joints.Add(LeftArmJoint);
        joints.Add(RightArmJoint);
        joints.Add(RightLegJoint);
        joints.Add(LeftLegJoint);

        joints.Add(NeckJoint);
        joints.Add(SpineJoint);
        joints.Add(LeftKneeJoint);
        joints.Add(RightKneeJoint);

        //joints.Add(WaistJoint);
        //joints.Add(NeckJoint);


        for (int i = 0; i < joints.Capacity; i++)
        {
            Debug.LogError("Inside Loop");
            //(GameObjectJoints[i], i);
            //
            //
            //
            //
            //
            // get path
            obj = GameObjectJoints[i];

            string path = "/" + obj.name;
            while (obj.transform.parent != null)
            {
                obj = obj.transform.parent.gameObject;
                path = "/" + obj.name + path;
            }
            // return path;
            //
            //
            //
            //
            //
            //
            //
            //
            //
            joints[i].Path = path;

            // Debug.LogError("This is the path: " + path);

            // end path
            joints[i].CreateCurves();

            clip.SetCurve(joints[i].Path, typeof(Transform), "localPosition.x", joints[i].CurveX);

            clip.SetCurve(joints[i].Path, typeof(Transform), "localPosition.y", joints[i].CurveY);

            clip.SetCurve(joints[i].Path, typeof(Transform), "localPosition.z", joints[i].CurveZ);

            // start rotation
            clip.SetCurve(joints[i].Path, typeof(Transform), "localRotation.x", joints[i].CurveRotX);

            clip.SetCurve(joints[i].Path, typeof(Transform), "localRotation.y", joints[i].CurveRotY);

            clip.SetCurve(joints[i].Path, typeof(Transform), "localRotation.z", joints[i].CurveRotZ);
            // end rotation
        }

        clip.legacy = true;




        // create a curve to move the GameObject and assign to the clip
        //AnimationCurve curvex = new AnimationCurve();
        //AnimationCurve curvey = new AnimationCurve();
        //AnimationCurve curvez = new AnimationCurve();



        anim.AddClip(clip, clip.name);


        //Debug.Log("================" + curvex.keys[0].value);
    }


    private void Update()
    {

        arm = handR.selectedJoint;
        keyNum = CircleSlider.frameNum;
        //Debug.Log("KeyNum: " + keyNum);
        //Debug.Log("PrevKeyNum: " + prevKeyNum);

        for (int i = 0; i < joints.Capacity; i++)
        {
            if (joints[i].Name == arm.gameObject.name)
            {
                jointIndex = i;
            }
        }

        //Slider moved
        if (keyNum != prevKeyNum)
        {
            Debug.Log("Slider moved");
            setkeySlider();
        }

        if (isSet)
        {
            setkeyClick(keyNum);
        }

        prevKeyNum = keyNum;

    }

    public void setkeySlider()
    {
        //keyNum = (int)timeSlider.value;
        float time = keyNum / 24f;

        //Vector3 tempPos = new Vector3();

        //Debug.Log("Restore position");

        //tempPos = new Vector3(joints[jointIndex].CurveX.Evaluate(time), joints[jointIndex].CurveY.Evaluate(time), joints[jointIndex].CurveZ.Evaluate(time));

        //arm.transform.localPosition = tempPos;


        // Ines Try

        for (int i = 0; i < joints.Capacity; i++)

        {
            Vector3 tempPos = new Vector3();
            Vector3 tempRot = new Vector3();

            Debug.Log("Restore position");

            tempPos = new Vector3(joints[i].CurveX.Evaluate(time), joints[i].CurveY.Evaluate(time), joints[i].CurveZ.Evaluate(time));
            //rotation
           // tempRot = new Quaternion(joints[i].CurveRotX.Evaluate(time), joints[i].CurveRotY.Evaluate(time), joints[i].CurveRotZ.Evaluate(time),0);
            tempRot = new Vector3(joints[i].CurveRotX.Evaluate(time), joints[i].CurveRotY.Evaluate(time), joints[i].CurveRotZ.Evaluate(time));

            //end rotation
            GameObjectJoints[i].transform.localPosition = tempPos;
            GameObjectJoints[i].transform.localEulerAngles = tempRot;
        }

        // Ines try end

        // Debug.Log("TemporaryCurvePos: " + tempPos);

    }

    public void setkeyClick(int num)
    {
        float time = num / 24f;

        // Save the current position
        positionx = arm.transform.localPosition.x;
        positiony = arm.transform.localPosition.y;
        positionz = arm.transform.localPosition.z;
        // Save the current rotation
        rotationx = arm.transform.localEulerAngles.x;
        rotationy = arm.transform.localEulerAngles.y;
        rotationz = arm.transform.localEulerAngles.z;

       // Debug.Log("LocalROtationX: " + rotationx);
        //If the current frame has a previous position
        if (prevPosx.ContainsKey(num) || prevRotx.ContainsKey(num))
        {
            //If position changed
            if (prevPosx[num] != positionx || prevPosy[num] != positiony || prevPosz[num] != positionz
                || prevRotx[num] != rotationx || prevRoty[num] != rotationy || prevRotz[num] != rotationz)
            {
                int CurrentCurveIndex = 0;
                //Replace key if there's a key
                if (joints[jointIndex].CurveX.AddKey(time, positionx) == -1)
                {
                    for (int i = 0; i < joints[jointIndex].CurveX.length; i++)
                    {
                        if (joints[jointIndex].CurveX.keys[i].time == time)
                            CurrentCurveIndex = i;
                    }

                    joints[jointIndex].CurveX.RemoveKey(CurrentCurveIndex);
                    joints[jointIndex].CurveY.RemoveKey(CurrentCurveIndex);
                    joints[jointIndex].CurveZ.RemoveKey(CurrentCurveIndex);


                    // rotation
                    joints[jointIndex].CurveRotX.RemoveKey(CurrentCurveIndex);
                    joints[jointIndex].CurveRotY.RemoveKey(CurrentCurveIndex);
                    joints[jointIndex].CurveRotZ.RemoveKey(CurrentCurveIndex);

                    Debug.Log("Replace Key at Index " + CurrentCurveIndex);

                }

                //Add key
                joints[jointIndex].CurveX.AddKey(time, positionx);
                joints[jointIndex].CurveY.AddKey(time, positiony);
                joints[jointIndex].CurveZ.AddKey(time, positionz);

                //Add rotation key
                joints[jointIndex].CurveRotX.AddKey(time, rotationx);
                joints[jointIndex].CurveRotY.AddKey(time, rotationy);
                joints[jointIndex].CurveRotZ.AddKey(time, rotationz);

                prevPosx.Remove(num);
                prevPosy.Remove(num);
                prevPosz.Remove(num);
                // rotation
                prevRotx.Remove(num);
                prevRoty.Remove(num);
                prevRotz.Remove(num);

                prevPosx.Add(num, positionx);
                prevPosy.Add(num, positiony);
                prevPosz.Add(num, positionz);
                // rotation
                prevRotx.Add(num, rotationx);
                prevRoty.Add(num, rotationy);
                prevRotz.Add(num, rotationz);

                CircleSlider.HighlightKey(num);
                Debug.Log("Add Key");
                //Debug.LogError("Local Rotation: " + joints[jointIndex].CurveRotX.Evaluate(time));

            }
        }

        else
        {
            prevPosx.Add(num, positionx);
            prevPosy.Add(num, positiony);
            prevPosz.Add(num, positionz);
            Debug.Log("Add to previous position");
            prevRotx.Add(num, rotationx);
            prevRoty.Add(num, rotationy);
            prevRotz.Add(num, rotationz);
        }


        //clip.SetCurve("", typeof(Transform), arm.ToString() + " localPosition.x", curvex);

        //clip.SetCurve("", typeof(Transform), arm.ToString() + " localPosition.y", curvey);

        //clip.SetCurve("", typeof(Transform), arm.ToString() + " localPosition.z", curvez);


        SetCurve();


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

    public void DeleteKey(int n)
    {
        float time = n / 24f;
        int CurrentCurveIndex = 0;
        
            for (int j = 0; j < joints[0].CurveX.length; j++)
            {
                Debug.Log("CurveTime: " + joints[0].CurveX.keys[j].time + " Time: " + time);
                if (joints[0].CurveX.keys[j].time == time)
                    CurrentCurveIndex = j;
            }

            Debug.Log("CurveIndex: " + CurrentCurveIndex + " PassedInValue: " + n); 
            joints[0].CurveX.RemoveKey(CurrentCurveIndex);
            joints[0].CurveY.RemoveKey(CurrentCurveIndex);
            joints[0].CurveZ.RemoveKey(CurrentCurveIndex);


            // rotation
            joints[0].CurveRotX.RemoveKey(CurrentCurveIndex);
            joints[0].CurveRotY.RemoveKey(CurrentCurveIndex);
            joints[0].CurveRotZ.RemoveKey(CurrentCurveIndex);

            Debug.Log("After deletion: " + joints[0].CurveX.length);




        int i = 0;

        obj = GameObjectJoints[i];

        string path = "/" + obj.name;
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path = "/" + obj.name + path;
        }
        // return path;
        joints[i].Path = path;

        clip.ClearCurves();
        SetCurve();

    }

    public void CopyKey()
    {

    }

    public void PasteKey()
    {

    }

    void SetCurve()
    {
        for (int i = 0; i < joints.Capacity; i++)
        {
            //GetGameObjectPath(GameObjectJoints[i], i);

            // get path
            obj = GameObjectJoints[i];

            string path = "/" + obj.name;
            while (obj.transform.parent != null)
            {
                obj = obj.transform.parent.gameObject;
                path = "/" + obj.name + path;
            }
            // return path;
            joints[i].Path = path;

            //  Debug.LogError("This is the path: " + path);

            // end path

            clip.SetCurve(joints[i].Path, typeof(Transform), "localPosition.x", joints[i].CurveX);

            clip.SetCurve(joints[i].Path, typeof(Transform), "localPosition.y", joints[i].CurveY);

            clip.SetCurve(joints[i].Path, typeof(Transform), "localPosition.z", joints[i].CurveZ);

            //rotation
            clip.SetCurve(joints[i].Path, typeof(Transform), "localRotation.x", joints[i].CurveRotX);

            clip.SetCurve(joints[i].Path, typeof(Transform), "localRotation.y", joints[i].CurveRotY);

            clip.SetCurve(joints[i].Path, typeof(Transform), "localRotation.z", joints[i].CurveRotZ);
        }

        anim.AddClip(clip, clip.name);
    }

    //public void GetGameObjectPath(GameObject obj, int index)
    //{
    //    string path = "/" + obj.name;
    //    while (obj.transform.parent != null)
    //    {
    //        obj = obj.transform.parent.gameObject;
    //        path = "/" + obj.name + path;
    //    }
    //    // return path;
    //    joints[index].Path = path;

    //    Debug.LogError("This is the path: " + path);

    //}

    public List<Joint> savedJoints()
    {
        return joints;
    }


}
