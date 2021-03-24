using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonHover : MonoBehaviour
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
        buttons.SetHoverImg();
    }

    private void OnTriggerExit(Collider other)
    {
        buttons.SetDefaultImg();
    }
}
