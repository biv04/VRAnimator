using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public bool isOn;
    public GameObject[] Canvas;
    public Sprite defaultImg, hoverImg, hitImage;

    SpriteRenderer sr;

    void Start()
    {
        sr =  gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = defaultImg;
    }

    // Update is called once per frame
    void Update()
    {
        if (Canvas != null)
        {
            if (!isOn)
            {
                for(int i = 0; i<Canvas.Length; i++)
                {
                    Canvas[i].SetActive(false);
                }
            }
                
            else
                for (int i = 0; i < Canvas.Length; i++)
                {
                    Canvas[i].SetActive(true);
                }
        }
      
    }


   public void SetHoverImg()
    {
        sr.sprite = hoverImg;
    }

    public void SetHitImg()
    {
        sr.sprite = hitImage;
    }

    public void SetDefaultImg()
    {
        sr.sprite = defaultImg;
    }

}
