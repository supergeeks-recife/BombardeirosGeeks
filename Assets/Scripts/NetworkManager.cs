using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public TMP_Text status;
    public TMP_Text rooName;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {
        status.text = "Servidor: " + PhotonNetwork.CloudRegion + "\nPing: " + PhotonNetwork.GetPing();
        rooName.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnConnected()
    {
        Debug.Log("Conexão concluida com sucesso");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("O mestre chegou!");
        Debug.Log("Servidor: " + PhotonNetwork.CloudRegion + " Ping: " + PhotonNetwork.GetPing());
    }

    public override void OnJoinedRoom()
    {
        rooName.text = PhotonNetwork.CurrentRoom.Name;
    }
}
