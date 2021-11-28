using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;
    private GameObject[] musics;
    private float VolumeValue = 1f;

    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("BGMMixer");
        if(musics.Length >=2)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayMusic()
    { if (audioSource.isPlaying) return; audioSource.Play(); }
    public void StopMusic()
    { audioSource.Stop(); }
}
    

    //볼륨 설정
    ////////////////////////////////////////////////////////////
/*
    private void Start()
    {
        VolumeValue = PlayerPrefs.GetFloat("VolumeValue", 1f);
        VolumeSlider.value = VolumeValue;
        _audio.volume = VolumeSlider.value;
    }
    void Update()
    {
        SoundSlider();
    }
    public void SoundSlider()
    {
        _audio.volume = VolumeSlider.value;
        VolumeValue = VolumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", VolumeValue);
    }

}
*/