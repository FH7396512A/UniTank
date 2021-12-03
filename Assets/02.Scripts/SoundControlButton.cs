using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundControlButton : MonoBehaviour
{
    public AudioMixer _mixer;
    public Slider _slider;
    public GameObject SoundButton;

    void Start()
    {
        _slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
    }

    public void SetLevel(float sliderValue)
    {
        _mixer.SetFloat("MusicVolume", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void SoundControlOnClicked()
    {
        if (_slider.gameObject.activeSelf == true)
        {
            _slider.gameObject.SetActive(false);
        }
        else if (_slider.gameObject.activeSelf == false)
        {
            _slider.gameObject.SetActive(true);
        }
    }
}
