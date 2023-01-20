using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviourPunCallbacks
{
   public void onClickStart()
   {
        PhotonNetwork.ConnectUsingSettings();
        print("ClickStart");
   }
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("LobbyScene");
        print("Connected!");
    }
}
