using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class RoomData : MonoBehaviour
{
    private Text RoomInfoText;
    private Text RoomInfoText2;
    private RoomInfo _roomInfo;

    public RoomInfo RoomInfo
    {
        get{ return _roomInfo; }
        set 
        {
            _roomInfo = value;
            RoomInfoText.text = $"{RoomInfo.Name}";
            RoomInfoText2.text = $"{_roomInfo.PlayerCount}/{_roomInfo.MaxPlayers}";
            GetComponent<Button>().onClick.AddListener(() => OnEnterRoom(_roomInfo.Name));
        }
    }
    void OnEnterRoom(string roomName)
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 4;

        PhotonNetwork.NickName = UserInfo._DisplayName;
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
    }
}
