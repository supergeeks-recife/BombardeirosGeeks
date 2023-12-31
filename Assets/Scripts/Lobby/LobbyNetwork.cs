using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Pun.UtilityScripts;
using Photon.Realtime;


public class LobbyNetwork : MonoBehaviourPunCallbacks
{
    [SerializeField] LobbyManager lobbyManager;
    
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnected()
    {
        lobbyManager.connectionStatus.text = "Connected Successfully";
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("OnConnectedToMaster");
        lobbyManager.ActivePanelLogin();
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("OnJoinedLobby");
    }

    public void Ready()
    {
        lobbyManager.ActivePanelLobby();
        //PhotonNetwork.JoinRandomRoom();
        Debug.Log("Ready");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("OnJoinedRoom");
        PhotonNetwork.LoadLevel("Game2");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Error code:" + returnCode + "\nError Message: "+ message);
        string roomName = "Room " + Random.Range(0, 10);
        RoomOptions newOptions = new RoomOptions()
        {
            IsOpen = true,
            IsVisible = true,
            MaxPlayers = 2
        };

        PhotonNetwork.CreateRoom(roomName, newOptions, TypedLobby.Default);
        Debug.Log("Room Name: " + roomName);
        PhotonNetwork.JoinRoom(roomName);

    }

    //Buttons
    public void CreateRoom()
    {
        RoomOptions newOptions = new RoomOptions()
        {
            IsOpen = true,
            IsVisible = true,
            MaxPlayers = 2
        };
        PhotonNetwork.CreateRoom(lobbyManager.createRoomName.text, newOptions, TypedLobby.Default);
        PhotonNetwork.JoinRoom(lobbyManager.createRoomName.text);
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(lobbyManager.joinRoomName.text);
    }
}