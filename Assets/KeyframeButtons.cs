using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyframeButtons : MonoBehaviour
{
    public int buttonNum;
    public controlanimation controlanimation;
    public KeyframeMenu keyframeMenu;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (buttonNum)
        {
            //Delete Keyframe
            case 0:
                Debug.LogError("Delete Keyframe");
                controlanimation.DeleteKey(keyframeMenu.keyNum);
                break;


        }
    }
}
