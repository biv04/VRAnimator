using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class controlanimation : MonoBehaviour
{
    // Animate the position and color of the GameObject
    public Animation anim;
    //public AnimationCurve curvex,curvey,curvez;
    public AnimationClip clip;
    float positionx, positiony, positionz;

    Dictionary<int, float> prevPosx = new Dictionary<int, float>();
    Dictionary<int, float> prevPosy = new Dictionary<int, float>();
    Dictionary<int, float> prevPosz = new Dictionary<int, float>();
    private GameObject arm;
    public HandGrabbing handR;
    private string path;

    public Slider timeSlider;
    public bool isSet;
    private int keyNum;
    public List<GameObject> GameObjectJoints;
    List<Joint> joints = new List<Joint>();

    int jointIndex = 0;
    GameObject obj;
   // private Joint LeftArmJoint, RightArmJoint, RightLegJoint, LeftLegJoint;;



    public void Start()
    {
      //   List<Joint> joints = new List<Joint>();
        Joint LeftArmJoint = new Joint("LeftArmJoint");        
        Joint RightArmJoint = new Joint("RightArmJoint");
        Joint RightLegJoint = new Joint("RightLegJoint");
        Joint LeftLegJoint = new Joint("LeftLegJoint");
      //  Joint WaistJoint = new Joint("WaistJoint");
      //  Joint NeckJoint = new Joint("NeckJoint");
       


        joints.Add(LeftArmJoint);
        joints.Add(RightArmJoint);
        joints.Add(RightLegJoint);
        joints.Add(LeftLegJoint);
       
        //joints.Add(WaistJoint);
        //joints.Add(NeckJoint);


        for (int i=0; i<joints.Capacity; i++)
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

            clip.SetCurve(joints[i].Path, typeof(Transform),  "localPosition.x", joints[i].CurveX);

            clip.SetCurve(joints[i].Path, typeof(Transform), "localPosition.y", joints[i].CurveY);

            clip.SetCurve(joints[i].Path, typeof(Transform),  "localPosition.z", joints[i].CurveZ);
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
        //Debug.LogError("THIS IS THE NAME OF THE SELECTED JOINT " + arm);


        for(int i = 0; i<joints.Capacity; i++)
        {
            Debug.LogError("INSIDE FOR LOOP TO CPMARE");
            if(joints[i].Name == arm.gameObject.name)
            {
                Debug.LogError("THIS IS THE GRABBED [PART   " +joints[i].Name + "   " + arm.gameObject.name);
                jointIndex = i;
            }
        }


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

        //Vector3 tempPos = new Vector3();

        //Debug.Log("Restore position");

        //tempPos = new Vector3(joints[jointIndex].CurveX.Evaluate(time), joints[jointIndex].CurveY.Evaluate(time), joints[jointIndex].CurveZ.Evaluate(time));

        //arm.transform.localPosition = tempPos;


        // Ines Try

        for (int i = 0; i < joints.Capacity; i++)

        {
            Vector3 tempPos = new Vector3();

            Debug.Log("Restore position");

            tempPos = new Vector3(joints[i].CurveX.Evaluate(time), joints[i].CurveY.Evaluate(time), joints[i].CurveZ.Evaluate(time));

            GameObjectJoints[i].transform.localPosition = tempPos;
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

 
        //If the current frame has a previous position
        if (prevPosx.ContainsKey(num))
        {
            //If position changed
            if (prevPosx[num] != positionx || prevPosy[num] != positiony || prevPosz[num] != positionz)
            {
                int CurrentCurveIndex = 0;
                //Replace key if there's a key
                if (joints[jointIndex].CurveX.AddKey(time, positionx) == -1)
                {
                    for(int i = 0; i < joints[jointIndex].CurveX.length; i++)
                    {
                        if (joints[jointIndex].CurveX.keys[i].time == time)
                            CurrentCurveIndex = i;
                    }

                    joints[jointIndex].CurveX.RemoveKey(CurrentCurveIndex);
                    joints[jointIndex].CurveY.RemoveKey(CurrentCurveIndex);
                    joints[jointIndex].CurveZ.RemoveKey(CurrentCurveIndex);

                    Debug.Log("Replace Key at Index " + CurrentCurveIndex);

                }

                //Add key
                joints[jointIndex].CurveX.AddKey(time, positionx);
                joints[jointIndex].CurveY.AddKey(time, positiony);
                joints[jointIndex].CurveZ.AddKey(time, positionz);

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


        //clip.SetCurve("", typeof(Transform), arm.ToString() + " localPosition.x", curvex);

        //clip.SetCurve("", typeof(Transform), arm.ToString() + " localPosition.y", curvey);

        //clip.SetCurve("", typeof(Transform), arm.ToString() + " localPosition.z", curvez);


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
        }

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
}
