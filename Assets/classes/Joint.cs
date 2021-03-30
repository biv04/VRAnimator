using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joint 
{
    private string name;
    private AnimationCurve curvex;
    private AnimationCurve curvey;
    private AnimationCurve curvez;
    // rotation
    private AnimationCurve curverotx;
    private AnimationCurve curveroty;
    private AnimationCurve curverotz;
    private string path;


    public Joint(string _name)
    {
        this.name = _name;
    }

    public void CreateCurves(GameObject joint)
    {
        curvex = new AnimationCurve();
        curvey = new AnimationCurve();
        curvez = new AnimationCurve();

        curvex.AddKey(0, joint.transform.localPosition.x);
        curvey.AddKey(0, joint.transform.localPosition.y);
        curvez.AddKey(0, joint.transform.localPosition.z);


        // rotation
        curverotx = new AnimationCurve();
        curveroty = new AnimationCurve();
        curverotz = new AnimationCurve();
        curverotx.AddKey(0, joint.transform.localEulerAngles.x);
        curveroty.AddKey(0, joint.transform.localEulerAngles.y);
        curverotz.AddKey(0, joint.transform.localEulerAngles.z);

    }

    public string Path
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public AnimationCurve CurveX
    {
        get
        {
            return curvex;
        }
        set
        {
            curvex = value;
        }
    }

    public AnimationCurve CurveY
    {
        get
        {
            return curvey;
        }
        set
        {
            curvey = value;
        }
    }

    public AnimationCurve CurveZ
    {
        get
        {
            return curvez;
        }
        set
        {
            curvez = value;
        }
    }

    //rotation
    public AnimationCurve CurveRotX
    {
        get
        {
            return curverotx;
        }
        set
        {
            curverotx = value;
        }
    }

    public AnimationCurve CurveRotY
    {
        get
        {
            return curveroty;
        }
        set
        {
            curveroty = value;
        }
    }

    public AnimationCurve CurveRotZ
    {
        get
        {
            return curverotz;
        }
        set
        {
            curverotz = value;
        }
    }
    // end rotation
}
