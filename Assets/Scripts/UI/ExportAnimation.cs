using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ExportAnimation : MonoBehaviour
{
    public controlanimation controlanimation;
    List<Joint> joints;

    GameObject obj;
    public List<GameObject> GameObjectJoints;
    public AnimationClip AnimationToSave;
    public string NameOfAimation; 

    int clipCount = 1;

    SpriteRenderer sr;
    // Start is called before the first frame update
 
    // Update is called once per frame
   
    private void OnTriggerEnter(Collider other)
    {
        saveAnimation(AnimationToSave, "SavedClip");
    }

    public void saveAnimation(AnimationClip clip, string clipName)
    {
        AnimationClip newAnimation = new AnimationClip();
        joints = controlanimation.savedJoints();








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

            newAnimation.SetCurve(joints[i].Path, typeof(Transform), "localPosition.x", joints[i].CurveX);

            newAnimation.SetCurve(joints[i].Path, typeof(Transform), "localPosition.y", joints[i].CurveY);

            newAnimation.SetCurve(joints[i].Path, typeof(Transform), "localPosition.z", joints[i].CurveZ);
        }











        clipName = "Assets/SavedAnimation/" + clipName + " - " + clipCount + ".anim";
        AssetDatabase.CreateAsset(newAnimation, clipName);
        AssetDatabase.SaveAssets();
        clipCount++;
    }

   

  


}
