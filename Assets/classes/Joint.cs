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

    public void CreateCurves()
    {
        curvex = new AnimationCurve();
        curvey = new AnimationCurve();
        curvez = new AnimationCurve();

        // rotation
        curverotx = new AnimationCurve();
        curveroty = new AnimationCurve();
        curverotz = new AnimationCurve();
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
            curvex = value;
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
            curvey = value;
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
            curvez = value;
        }
    }
    // end rotation
}
