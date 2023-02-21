using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;
using System.Text;

public class LobbySceneManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    InputField inputRoomName;
    [SerializeField]
    Text textRoomList;

    void Start()
    {
        if(PhotonNetwork.IsConnected == false)
        {
            SceneManager.LoadScene("StartScene");
        }
        else
        {
            PhotonNetwork.JoinLobby();
        }
    }
    public override void OnJoinedLobby()
    {
        print("Lobby joined.");
    }
    public string GetRoomName()
    {
        string roomName = inputRoomName.text;
        return roomName.Trim();
    }
    public void OnClickCreateRoom()
    {
        string roomName = GetRoomName();
        if (roomName.Length > 0)
        {
            PhotonNetwork.CreateRoom(roomName);
        }
        else
        {
            print("Invaild RoomName");
        }
    }

    public void OnClickJoinRoom()
    {
        string roomName = GetRoomName();
        if (roomName.Length > 0)
        {
            PhotonNetwork.JoinRoom(roomName);
        }
        else
        {
            print("Invaild RoomName!");
        }
    }
    public override void OnJoinedRoom()
    {
        print("Room Joined!");
        SceneManager.LoadScene("RoomScene");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        print("update");
        StringBuilder sb = new StringBuilder();
        foreach (RoomInfo roomInfo in roomList)
        {
            print(roomInfo.PlayerCount);
            if (roomInfo.PlayerCount > 0)
            {
                sb.AppendLine(">" + roomInfo.Name + roomInfo.PlayerCount);
            }
        }
        textRoomList.text = sb.ToString();
    }
}
