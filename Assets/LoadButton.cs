using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadButton : MonoBehaviour
{
    public Text name;
    int index;
    controlanimation controlanimation;
    AnimationClip newClip;
    LoadPanel loadPanel;

    string[] ClipList;

    // Start is called before the first frame update
    void Start()
    {
        name.text = gameObject.transform.parent.name;
        controlanimation = (controlanimation)GameObject.FindObjectOfType(typeof(controlanimation));
        loadPanel = (LoadPanel)GameObject.FindObjectOfType(typeof(LoadPanel));
        ClipList = loadPanel.ClipList;

        index = int.Parse(gameObject.transform.parent.name.Substring(4));
        // Get the corresponding animation clip
        FindClip(index);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hand_Index")
        {

            // Set animation to this clip
            controlanimation.SetAnimationClip(newClip);

        }
    }

    private void FindClip(int i)
    {
        newClip = Resources.Load("SavedClip - " + i + ".anim") as AnimationClip;
        Debug.LogError("Index: " + index + " NewClipName: " + newClip.name);


    }
}
