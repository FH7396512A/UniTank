using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyBtnControl : MonoBehaviour
{
    public GameObject CreateBtn, CreateFinishBtn, LobbyPanel, StatusText,
        CreateRoom, BackButton;

    public void CreateBtnClicked()
    {
        CreateBtn.gameObject.SetActive(true);
        CreateFinishBtn.gameObject.SetActive(true);
        LobbyPanel.gameObject.SetActive(false);
        StatusText.gameObject.SetActive(false);
        CreateRoom.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
    }
    public void BackButtonClicked()
    {
        Debug.Log("aa");
    }
}
