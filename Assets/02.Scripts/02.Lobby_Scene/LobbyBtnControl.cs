using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;


public class LobbyBtnControl : MonoBehaviourPunCallbacks
{
    public GameObject CreateBtn, CreateFinishBtn, LobbyPanel, StatusText,
        CreateRoom, StartBtn;
    

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

    [PunRPC]
    public void StartBtnOnClicked()
    {
        SceneManager.LoadScene("GameScene");
    }
}
  
