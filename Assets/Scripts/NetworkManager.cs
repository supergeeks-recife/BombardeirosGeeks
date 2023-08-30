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
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void Update()
    {
        status.text = "Servidor: " + PhotonNetwork.CloudRegion + "\nPing: " + PhotonNetwork.GetPing();
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

}
