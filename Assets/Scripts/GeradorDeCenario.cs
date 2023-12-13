using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class GeradorDeCenario : MonoBehaviour
{
    [Header("Configurations")]
    public int gridX;
    public int gridZ;
    public float gridSpacingOffset = 1f;
    [SerializeField] Vector3 gridOrigin = Vector3.zero;

    [Header("Piso")]
    [SerializeField] GameObject[] ListaPiso;
    GameObject blocoPiso;

    [Header("Paredes")]
    [SerializeField] GameObject[] ListaParedes;
    GameObject blocoParede;

    [Range(0f, 1f)]
    [SerializeField] float chanceDeGerarParede;

    [Header("Spawn")]
    public List<Transform> ListaSpawn;

    [Header("Map")]
    public List<PartMap> map;

    [Header("Player")]
    Player player;

    void Awake()
    {
        map = new List<PartMap>();
        player = PhotonNetwork.LocalPlayer;
        
        if(player.IsMasterClient && player != null)
        {
            GerarGradePiso();
        }
        
    }

    void Start()
    {
        //GerarGradePiso();
    }

    void Update()
    {
        
    }

    void GerarGradePiso()
    {
        for(int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 spawnPositionFloor = new Vector3 (x * gridSpacingOffset, 0, z * gridSpacingOffset) + gridOrigin;
                GerarPiso(spawnPositionFloor, Quaternion.identity);

                Vector3 spawnPositionEnvironment = new Vector3(x * gridSpacingOffset, 2f, z * gridSpacingOffset) + gridOrigin;
                GerarParedes(spawnPositionEnvironment, Quaternion.identity);

                PartMap partMap = new PartMap
                {
                    chao = blocoPiso,
                    spawnPositionChao = spawnPositionFloor,
                    parede = blocoParede,
                    spawnPositionParede = spawnPositionEnvironment
                };

                map.Add(partMap);
            }
        }
    }

    void GerarPiso(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int indiceAleatorio = Random.Range(0, ListaPiso.Length);
        blocoPiso = PhotonNetwork.Instantiate(ListaPiso[indiceAleatorio].name, positionToSpawn, rotationToSpawn);

        //blocoPiso = Instantiate(ListaPiso[indiceAleatorio], positionToSpawn, rotationToSpawn);
    }

    void GerarParedes(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        float chanceDeGerar = Random.Range(0f, 1f);
        if(chanceDeGerar <= chanceDeGerarParede)
        {
            int indiceAleatorio = Random.Range(0, ListaParedes.Length);
            blocoParede = PhotonNetwork.Instantiate(ListaParedes[indiceAleatorio].name, positionToSpawn, rotationToSpawn);
            //blocoParede = Instantiate(ListaParedes[indiceAleatorio], positionToSpawn, rotationToSpawn);

            //Select spawn points
            if (blocoParede.gameObject.name == "SpawnPoint(Clone)")
            {
                ListaSpawn.Add(blocoParede.transform);
            }
        }

    }
}

[System.Serializable]
public class PartMap
{
    public GameObject chao;
    public Vector3 spawnPositionChao;
    public GameObject parede;
    public Vector3 spawnPositionParede;
}