using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    public List<Transform> spawnPoints;
    void Start()
    {
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[Random.Range(0, spawnPoints.Count - 1)].position, Quaternion.identity);
    }

}
