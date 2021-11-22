using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    [Header("LobbyPanel")]
    public GameObject LobbyPanel;
    public TMP_Text LobbyInfoText;

    private Dictionary<string, GameObject> roomDict = new Dictionary<string, GameObject>();
    public InputField RoomInput;
    public GameObject RoomPrefab;
    public Transform scrollContent;

    [Header("RoomPanel")]
    public GameObject RoomPanel;
    public GameObject StatusPanel;
    public Text ListText;
    public TMP_Text RoomInfoText;
    public Text[] ChatText;
    public InputField ChatInput;
    public Transform UserContent;
    public GameObject UserPrefab;
    private List<GameObject> userPrefabs = new List<GameObject>();
    private List<GameObject> roomPrefabs = new List<GameObject>();

    [Header("ETC")]
    public PhotonView PV;

    public GameObject _CreateRoom;
    public GameObject _StatusText;
    public TMP_Text _StatusT;

    List<RoomInfo> myList = new List<RoomInfo>();

    #region 방리스트 갱신
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "0.01";
        PhotonNetwork.ConnectUsingSettings();
    }

    void Start()
    {
        OnConnectedToMaster();
        PhotonNetwork.NickName = UserInfo._DisplayName;
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("랜덤룸 접속 실패");

        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 4;

        RoomInput.text = $"Room_{Random.Range(1, 100):000}";
        PhotonNetwork.CreateRoom("room_1", ro);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("방 생성 완료");
    }
    void MyListRenewal()
    {
        if (roomPrefabs.Count > 0)
        {
            for (int i = 0; i < roomPrefabs.Count; i++)
            {
                Destroy(roomPrefabs[i]);
            }
            roomPrefabs.Clear();
        }
        for (int i = 0; i < myList.Count; i++)
        {
            GameObject _room = Instantiate(RoomPrefab, scrollContent);
            roomDict.Add(myList[i].Name, _room);
            _room.transform.GetChild(0).GetComponent<Text>().text = myList[i].Name;
            _room.transform.GetChild(1).GetComponent<Text>().text = myList[i].PlayerCount + "/" + myList[i].MaxPlayers;
            _room.GetComponent<Button>().onClick.AddListener
            (
                delegate
                {
                    OnEnterRoom(myList[i].Name);
                }
            );
            roomPrefabs.Add(_room);
        }
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        
        int roomCount = roomList.Count;
        for (int i = 0; i < roomCount; i++)
        {
            if (!roomList[i].RemovedFromList)
            {
                if (!myList.Contains(roomList[i])) myList.Add(roomList[i]);
                else myList[myList.IndexOf(roomList[i])] = roomList[i];
            }
            else if (myList.IndexOf(roomList[i]) != -1) myList.RemoveAt(myList.IndexOf(roomList[i]));
        }
        MyListRenewal();
    }

    void OnEnterRoom(string roomName)
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 4;

        PhotonNetwork.NickName = UserInfo._DisplayName;
        LobbyPanel.gameObject.SetActive(false);
        RoomPanel.gameObject.SetActive(true);
        StatusPanel.gameObject.SetActive(true);
        _CreateRoom.gameObject.SetActive(false);
        _StatusText.gameObject.SetActive(true);
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
    }

    #endregion

    #region 버튼 클릭
    public void OnRandomBtn()
    {
        PlayerPrefs.SetString("USER_ID", UserInfo._DisplayName);
        PhotonNetwork.NickName = UserInfo._DisplayName;
        LobbyPanel.gameObject.SetActive(false);
        RoomPanel.gameObject.SetActive(true);
        StatusPanel.gameObject.SetActive(true);
        _CreateRoom.gameObject.SetActive(false);
        _StatusText.gameObject.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }
    #endregion

    #region 서버연결 //

        void Update()
        {
            _StatusT.text = PhotonNetwork.NetworkClientState.ToString();
            LobbyInfoText.text = (PhotonNetwork.CountOfPlayers - PhotonNetwork.CountOfPlayersInRooms) + "로비 / " + PhotonNetwork.CountOfPlayers + "접속";
        }

        public void Connect() => PhotonNetwork.ConnectUsingSettings();

        public override void OnConnectedToMaster() => PhotonNetwork.JoinLobby();

        public override void OnJoinedLobby()
        {
            LobbyPanel.gameObject.SetActive(true);
            RoomPanel.gameObject.SetActive(false);
            _CreateRoom.gameObject.SetActive(false);
            _StatusText.gameObject.SetActive(true);
            PhotonNetwork.LocalPlayer.NickName = UserInfo._DisplayName;
            myList.Clear();
        }

        public void Disconnect() => PhotonNetwork.Disconnect();

        public override void OnDisconnected(DisconnectCause cause)
        {
            SceneManager.LoadScene("Main");
        }

    #endregion

    #region 방 //

    public void CreateRoom() => PhotonNetwork.CreateRoom(RoomInput.text == "" ? "Room" + Random.Range(0, 100) : RoomInput.text, new RoomOptions { MaxPlayers = 4 });

    public void JoinRandomRoom() => PhotonNetwork.JoinRandomRoom();

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }


    public override void OnJoinedRoom()
    {
        RoomPanel.gameObject.SetActive(true);
        _CreateRoom.gameObject.SetActive(false);
        _StatusText.gameObject.SetActive(true);
        RoomRenewal();
        ChatInput.text = "";
        for (int i = 0; i < ChatText.Length; i++) ChatText[i].text = "";
    }

    public override void OnCreateRoomFailed(short returnCode, string message) { RoomInput.text = ""; CreateRoom(); }

    public override void OnJoinRandomFailed(short returnCode, string message) { RoomInput.text = ""; CreateRoom(); }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        RoomRenewal();
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RoomRenewal();
    }
    void RoomRenewal()
    {
        if (userPrefabs.Count > 0)
        {
            for (int i = 0; i < userPrefabs.Count; i++)
            {
                Destroy(userPrefabs[i]);
            }
            userPrefabs.Clear();
        }
        ListText.text = "";
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            ListText.text += PhotonNetwork.PlayerList[i].NickName + ((i + 1 == PhotonNetwork.PlayerList.Length) ? "" : ", ");
            GameObject UserCheck = Instantiate(UserPrefab, UserContent);
            UserCheck.transform.GetChild(0).GetComponent<Text>().text = PhotonNetwork.PlayerList[i].NickName;
            userPrefabs.Add(UserCheck);
        }
        RoomInfoText.text = PhotonNetwork.CurrentRoom.Name + " / " + PhotonNetwork.CurrentRoom.PlayerCount + "명 / " + PhotonNetwork.CurrentRoom.MaxPlayers + "최대";
    }
    #endregion


    #region 채팅 //
    public void Send()
    {
        if (ChatInput.text != "")
        {
            PV.RPC("ChatRPC", RpcTarget.All, PhotonNetwork.NickName + " : " + ChatInput.text);
            ChatInput.text = "";
        }
    }

    [PunRPC] // RPC는 플레이어가 속해있는 방 모든 인원에게 전달한다
    void ChatRPC(string msg)
    {
        bool isInput = false;
        for (int i = 0; i < ChatText.Length; i++)
            if (ChatText[i].text == "")
            {
                isInput = true;
                ChatText[i].text = msg;
                break;
            }
        if (!isInput) // 꽉차면 한칸씩 위로 올림
        {
            for (int i = 1; i < ChatText.Length; i++) ChatText[i - 1].text = ChatText[i].text;
            ChatText[ChatText.Length - 1].text = msg;
        }
    }
    #endregion
}
