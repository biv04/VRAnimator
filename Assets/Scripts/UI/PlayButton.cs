using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public controlanimation controlanimation;
    public VideoPlayer videoPlayer;
    public Slider timeSlider;
    public GameObject btnPause;
    public GameObject btnPlay;
    bool isPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        btnPause.SetActive(false);
        btnPlay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
       if(isPlaying)
        {
            if (timeSlider.value == 24) timeSlider.value = 0;
            else timeSlider.value += 1;     
        }
    }

    private void OnTriggerEnter(Collider other)
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
