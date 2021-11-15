using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyBtnControl : MonoBehaviour
{
    public GameObject CreateBtn, CreateFinishBtn, LobbyPanel, StatusText,
        CreateRoom;

    public void CreateBtnClicked()
    {
        CreateBtn.gameObject.SetActive(true);
        CreateFinishBtn.gameObject.SetActive(true);
        LobbyPanel.gameObject.SetActive(false);
        StatusText.gameObject.SetActive(false);
        CreateRoom.gameObject.SetActive(true);
    }
    public void BackButtonOnClicked()
    {
        Debug.Log("Back to Main");
        SceneManager.LoadScene("Main");
    }
}
