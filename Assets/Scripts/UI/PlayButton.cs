using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public controlanimation controlanimation;
    public VideoPlayer videoPlayer;
    //public Slider timeSlider;
    public CircleSlider circleSlider;
    public GameObject handle;
    public GameObject btnPause;
    public GameObject btnPlay;
    public bool isPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        btnPause.SetActive(false);
        btnPlay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        //Get current max frame
        if (isPlaying)
        {
            if (circleSlider.frameNum == controlanimation.maxFrame) circleSlider.frameNum = 0;
            else circleSlider.frameNum += 1;

            // handle.SetActive(false);
        }

        else
        {
            handle.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Hand_IndexTip")
        {
            isPlaying = !isPlaying;

            if (isPlaying)
            {
                controlanimation.play();
                btnPause.SetActive(true);
                btnPlay.SetActive(false);
            }

            if (!isPlaying)
            {
                //videoPlayer.Pause();
                controlanimation.Stop();
                btnPause.SetActive(false);
                btnPlay.SetActive(true);
            }
        }
      

    }
}
