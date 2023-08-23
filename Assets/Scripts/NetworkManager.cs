using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        Debug.Log("Conexão concluída com sucesso");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("O mestre chegou!");
        Debug.Log("Servidor: " + PhotonNetwork.CloudRegion + " Ping: " + PhotonNetwork.GetPing());
    }

}
