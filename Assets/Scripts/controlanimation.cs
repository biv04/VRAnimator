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
    public Vector3 copiedPos, copiedRot;

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
    public Material defaultMat;
    private string path;

    //public Slider timeSlider;
    public CircleSlider CircleSlider;
    public GameObject CircleSliderHandle;
    public bool isSet;
    private int keyNum, prevKeyNum;
    public List<GameObject> GameObjectJoints;
    List<Joint> joints = new List<Joint>();
    List<CircleSlider> sliders = new List<CircleSlider>();
    Joint prevJoint = new Joint("PrevJoint");


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
        

        /*
        for(int i = 0; i<joints.Capacity; i ++)
        {
            CircleSlider circleSlider = new CircleSlider();
            sliders.Add(circleSlider);

        }
        */
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
            joints[i].CreateCurves(GameObjectJoints[i]);

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

        for (int i = 0; i < joints.Capacity; i++)
        {
            if (joints[i].Name == arm.gameObject.name)
            {
                jointIndex = i;
                GameObjectJoints[i].GetComponentInChildren<MeshRenderer>().material.color = Color.cyan;
                CircleSlider.SetJointName(joints[jointIndex].Name);
            }

            else
                GameObjectJoints[i].GetComponentInChildren<MeshRenderer>().material = defaultMat;
        }

        //Slider moved
        if (keyNum != prevKeyNum)
            setkeySlider();

        if (isSet)
            setkeyClick(keyNum);

        prevKeyNum = keyNum;
        SetColor(joints[jointIndex]);

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

        //If the current frame has a previous position
        if (prevPosx.ContainsKey(num) || prevRotx.ContainsKey(num))
        {
            //If position changed
            if (prevPosx[num] != positionx || prevPosy[num] != positiony || prevPosz[num] != positionz
                || prevRotx[num] != rotationx || prevRoty[num] != rotationy || prevRotz[num] != rotationz)
            {
                //Replace key if there's a key
                if (joints[jointIndex].CurveX.AddKey(time, positionx) == -1)
                    ReplaceKey(time);

                AddKey(num, new Vector3(positionx, positiony, positionz), new Vector3(rotationx, rotationy, rotationz));

            }
        }

        else
        {
            prevPosx.Add(num, positionx);
            prevPosy.Add(num, positiony);
            prevPosz.Add(num, positionz);
            prevRotx.Add(num, rotationx);
            prevRoty.Add(num, rotationy);
            prevRotz.Add(num, rotationz);
        }


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
        
            for (int j = 0; j < joints[jointIndex].CurveX.length; j++)
            {
                Debug.Log("CurveTime: " + joints[jointIndex].CurveX.keys[j].time + " Time: " + time);
                if (joints[jointIndex].CurveX.keys[j].time == time)
                    CurrentCurveIndex = j;
            }

                Debug.Log("CurveIndex: " + CurrentCurveIndex + " PassedInValue: " + n);
                joints[jointIndex].CurveX.RemoveKey(CurrentCurveIndex);
                joints[jointIndex].CurveY.RemoveKey(CurrentCurveIndex);
                joints[jointIndex].CurveZ.RemoveKey(CurrentCurveIndex);


                // rotation
                joints[jointIndex].CurveRotX.RemoveKey(CurrentCurveIndex);
                joints[jointIndex].CurveRotY.RemoveKey(CurrentCurveIndex);
                joints[jointIndex].CurveRotZ.RemoveKey(CurrentCurveIndex);

                Debug.Log("After deletion: " + joints[jointIndex].CurveX.length);
      

        CircleSlider.DefaultColor(n);
        clip.ClearCurves();
        SetCurve();

    }

    public void CopyKey(int n)
    {
        float time = n / 24f;
        copiedPos = new Vector3(joints[jointIndex].CurveX.Evaluate(time), joints[jointIndex].CurveY.Evaluate(time), joints[jointIndex].CurveZ.Evaluate(time));
        copiedRot = new Vector3(joints[jointIndex].CurveRotX.Evaluate(time), joints[jointIndex].CurveRotY.Evaluate(time), joints[jointIndex].CurveRotZ.Evaluate(time));
    }

    public void PasteKey(int n)
    {
        float time = n / 24f;
        AddKey(n, copiedPos, copiedRot);
        SetCurve();

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

    void ReplaceKey(float time)
    {
        int CurrentCurveIndex = 0;

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

    void AddKey( int num, Vector3 Pos, Vector3 Rot)
    {
        float time = num / 24f;
        //Add key
        joints[jointIndex].CurveX.AddKey(time, Pos.x);
        joints[jointIndex].CurveY.AddKey(time, Pos.y);
        joints[jointIndex].CurveZ.AddKey(time, Pos.z);

        //Add rotation key
        joints[jointIndex].CurveRotX.AddKey(time, Rot.x);
        joints[jointIndex].CurveRotY.AddKey(time, Rot.y);
        joints[jointIndex].CurveRotZ.AddKey(time, Rot.z);

        prevPosx.Remove(num);
        prevPosy.Remove(num);
        prevPosz.Remove(num);
        // rotation
        prevRotx.Remove(num);
        prevRoty.Remove(num);
        prevRotz.Remove(num);

        prevPosx.Add(num, Pos.x);
        prevPosy.Add(num, Pos.y);
        prevPosz.Add(num, Pos.z);
        // rotation
        prevRotx.Add(num, Rot.x);
        prevRoty.Add(num, Rot.y);
        prevRotz.Add(num, Rot.z);

    }


    public List<Joint> savedJoints()
    {
        return joints;
    }

    
    void SetColor(Joint selectedJoint)
    {
        if (prevJoint == null)
            prevJoint = selectedJoint;

        //Loop through all the frames, set color to yellow if there is a key on the curve
        for(int i = 0; i< 24; i++)
        {

            float time = i / 24f;

            for (int j = 0; j < joints[jointIndex].CurveX.length; j++)
            {
                if (joints[jointIndex].CurveX.keys[j].time == time)
                    CircleSlider.HighlightKey(i);

                else if(CircleSlider.GetColor(i) == CircleSlider.HighLightColor() && prevJoint == selectedJoint)
                    CircleSlider.HighlightKey(i);

                else
                    CircleSlider.DefaultColor(i);

            }
        }

        prevJoint = selectedJoint;
    }

    public void SetAnimationClip(AnimationClip newClip)
    {
        clip = newClip;
        anim.clip = newClip;
    }

}
