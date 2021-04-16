using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHit : MonoBehaviour
{
    public Buttons buttons;
    private Image Image;

    // Start is called before the first frame update
    void Start()
    {
        if (buttons.isImage)
            Image = gameObject.GetComponentInParent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.name == "Hand_IndexTip" )
        {
            if (buttons.isImage == false) buttons.SetHitImg();
            else
            {
                Image.color = new Color(0,0,0, 0.8f);

            }
            buttons.isOn = !buttons.isOn;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (buttons.isImage == false) buttons.SetDefaultImg();
        else
            Image.color = new Color(0, 0, 0, 0.5f);
    }

 
}
