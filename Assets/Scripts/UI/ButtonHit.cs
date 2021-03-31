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
        Vector3 direction = transform.position - other.gameObject.transform.position;
        Debug.Log("UI Colliding Direction: " + direction);
       
        if (other.gameObject.name == "Hand_IndexTip"  &&  (direction.y > 0))
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
