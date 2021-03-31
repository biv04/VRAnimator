using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHit : MonoBehaviour
{
    public Buttons buttons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Hand_IndexTip")
        {
            buttons.SetHitImg();
            buttons.isOn = !buttons.isOn;
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        buttons.SetDefaultImg();
       
    }

    
}
