using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using Photon.Realtime;

public class NetWorkLauncherUI : MonoBehaviourPunCallbacks
{
    public GameObject loginUI;
    public GameObject nameUI;
    public InputField roomName;
    public InputField playerName;
    public GameObject roomListUI;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        nameUI.SetActive(false);
        loginUI.SetActive(false);
        roomListUI.SetActive(false);
       
    }
    public override void OnConnectedToMaster()
    {
        nameUI.SetActive(true);
        Debug.Log("链接大厅");
        PhotonNetwork.JoinLobby();
    }
    public void PlayButton()
    {
        if (playerName.text.Length<2)
        {
            return;
        }
        nameUI.SetActive(false);
        PhotonNetwork.NickName = playerName.text;
        loginUI.SetActive(true);
        if (PhotonNetwork.InLobby)
        {
            roomListUI.SetActive(true);
        }
    }
    public void JionRoomButton()
    {
        if (roomName.text.Length < 2)
        {
            return;
        }
        loginUI.SetActive(false);
        RoomOptions options = new RoomOptions { MaxPlayers = 4 };
        PhotonNetwork.JoinOrCreateRoom(roomName.text,options,default);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(1);
        roomListUI.SetActive(false);
    }


}
