using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class GameplayController : MonoBehaviour
{
    [SerializeField] GameObject myPlayer;
    [SerializeField] GeradorDeCenario geradorInstance;
    public List<Transform> spawnPoints; 
    void Start()
    {
        spawnPoints = geradorInstance.ListaSpawn;
        PhotonNetwork.Instantiate(myPlayer.name, spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
    }
}
