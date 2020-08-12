using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //链接服务器设置；
        PhotonNetwork.ConnectUsingSettings();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("链接游戏大厅");
        //创建房间
        PhotonNetwork.JoinOrCreateRoom("Room",new Photon.Realtime.RoomOptions() { MaxPlayers=4},default);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(7,-4,0),Quaternion.identity,0);
    }
}
