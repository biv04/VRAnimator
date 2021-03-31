using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
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

	void Update(){
	if(Input.GetKeyDown("space")){
		controlanimation.SetAnimationClip(newClip);	
		Debug.Log("Update Animation");
	}
	
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hand_IndexTip")
        {

            // Set animation to this clip
            controlanimation.SetAnimationClip(newClip);

        }
    }

	
    private void FindClip(int i)
    {
        // newClip = Resources.Load("SavedClip - " + i + ".anim") as AnimationClip;
        //newClip = Resources.Load<AnimationClip>("SavedClip - " + i);
        newClip= (AnimationClip)AssetDatabase.LoadAssetAtPath("Assets/Resources/SavedClip - " + i + ".anim", typeof(AnimationClip));
        //ResourceRequest request = Resources.LoadAsync("SavedClip - " + i );
        //newClip = request.asset as AnimationClip;

    }
}
