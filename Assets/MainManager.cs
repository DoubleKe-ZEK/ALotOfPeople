using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MainManager : MonoBehaviourPunCallbacks
{
    public GameObject readyUI;
    public void Start()
    {
        readyUI.SetActive(true);
    }
    public void ReadyToPlay()
    {
        readyUI.SetActive(false);
        PhotonNetwork.Instantiate("Player",new Vector3(-7,-4,0),Quaternion.identity,0);
    }
}
