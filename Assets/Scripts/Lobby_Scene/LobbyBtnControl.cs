using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbyBtnControl : MonoBehaviour
{
    public GameObject CreateBtn, CreateFinishBtn, LobbyPanel, StatusText,
        CreateRoom, SoundControlButton, SoundControlBackButton;
    public Slider VolumeSlider;
    public AudioSource audio;
    private float VolumeValue = 1f;

    public void CreateBtnClicked()
    {
        CreateBtn.gameObject.SetActive(true);
        CreateFinishBtn.gameObject.SetActive(true);
        LobbyPanel.gameObject.SetActive(false);
        StatusText.gameObject.SetActive(false);
        CreateRoom.gameObject.SetActive(true);
        SoundControlButton.gameObject.SetActive(false);
    }
    public void BackButtonOnClicked()
    {
        Debug.Log("Back to Main");
        SceneManager.LoadScene("Main");
    }

    public void SoundControlOnClicked()
    {
        VolumeSlider.gameObject.SetActive(true);
        SoundControlButton.gameObject.SetActive(false);
    }

    public void SoundControlBackOnClicked()
    {
        VolumeSlider.gameObject.SetActive(false);
        SoundControlButton.gameObject.SetActive(true);
    }
    //볼륨 설정
    ////////////////////////////////////////////////////////////
    private void Start()
    {
        VolumeValue = PlayerPrefs.GetFloat("VolumeValue", 1f);
        VolumeSlider.value = VolumeValue;
        audio.volume = VolumeSlider.value;
    }
    void Update()
    {
        SoundSlider();
    }
    public void SoundSlider()
    {
        audio.volume = VolumeSlider.value;
        VolumeValue = VolumeSlider.value;
        PlayerPrefs.SetFloat("VolumeValue", VolumeValue);
    }
}
