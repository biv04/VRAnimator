using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increasenumber : MonoBehaviour
{
    public CircleSlider circleSliderscript = new CircleSlider();
    public bool isRight;
    public GameObject ColliderLeft, ColliderRight;

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

        if (other.gameObject.CompareTag("Handle"))
        {
            if (isRight)
            {
                ColliderLeft.SetActive(false);
                Debug.Log("Right Collider, Increase");
                circleSliderscript.increaseValue();
            }

            else
            {
                ColliderRight.SetActive(false);
                Debug.Log("Left Collider, Decrease");
                circleSliderscript.DecreaseValue();
            }

        }
    }
}
