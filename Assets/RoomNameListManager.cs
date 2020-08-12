using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class RoomNameListManager : MonoBehaviourPunCallbacks
{
    public GameObject roomNamePrefab;
    public Transform gridLayout;
    public void Start()
    {
        
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //删除
        for (int i = 1; i < gridLayout.childCount; i++)
        {
            if (gridLayout.GetChild(i).gameObject.GetComponentInChildren<Text>().text==roomList[i].Name)
            {
                Destroy(gridLayout.GetChild(i).gameObject);
                if (roomList[i].PlayerCount==1)
                {
                    roomList.Remove(roomList[i]);
                }
            }

        }
       // 刷新
        foreach (var room in roomList)
        {
            GameObject newRoom = Instantiate(roomNamePrefab,gridLayout.position,Quaternion.identity);
            newRoom.GetComponentInChildren<Text>().text = room.Name+"("+room.PlayerCount+")";
            newRoom.transform.SetParent(gridLayout);
        }
    }

}
