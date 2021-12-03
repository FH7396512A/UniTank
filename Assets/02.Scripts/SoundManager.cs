using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioMixer _mixer;
    public AudioMixerGroup _mixergroup;
    public Slider _slider;
    public GameObject SoundButton;
    private string SceneName;
    public Action SceneCheck = null;

    [System.Serializable]
    public struct Bgm
    {
        public string name;
        public AudioClip audio;
    }

    public Bgm[] BgmList;
    private string Bgmname="";    

    private void Awake()
    {      
        SceneName = SceneManager.GetActiveScene().name;
        SceneCheck -= PlayMusic;
        SceneCheck += PlayMusic;
        DontDestroyOnLoad(transform.gameObject);
        _slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        DontDestroyOnLoad(gameObject);
        audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.outputAudioMixerGroup = _mixergroup;
        audioSource.loop = true;
        if(BgmList.Length > 0)
        {
            PlayMusic();
        }
    }

    private void Update()
    {
        OnUpdate();
    }

    public void PlayMusic()
    { 
        if (Bgmname.Equals(SceneName))
        {
            return;
        }

        for(int i = 0; i < BgmList.Length; i++)
        {
            if (BgmList[i].name.Equals(SceneName))
            {
                audioSource.clip = BgmList[i].audio;
                audioSource.Play();
                Bgmname = SceneName;
            }
        }
    }
    public void StopMusic()
    { 
        audioSource.Stop(); 
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

    void OnUpdate()
    {
        if (SceneName == SceneManager.GetActiveScene().name)
        {
            return;
        }
        if (SceneCheck != null)
        {
            SceneName = SceneManager.GetActiveScene().name;
            SceneCheck.Invoke();         
        }
    }
}  