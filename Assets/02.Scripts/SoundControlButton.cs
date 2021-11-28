using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControlButton : MonoBehaviour
{
    public Slider VolumeSlider;
    public AudioSource _audio;
    public GameObject SoundButton;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SoundControlOnClicked()
    {
        if (VolumeSlider.gameObject.activeSelf == true)
        {
            VolumeSlider.gameObject.SetActive(false);
        }
        else if (VolumeSlider.gameObject.activeSelf == false)
        {
            VolumeSlider.gameObject.SetActive(true);
        }
    }
}
