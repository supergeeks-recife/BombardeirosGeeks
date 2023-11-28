using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GeradorDeCenario : MonoBehaviour
{
    [Header("Configurations")]
    public int gridX;
    public int gridZ;
    public float gridSpacingOffset = 1f;
    [SerializeField] Vector3 gridOrigin = Vector3.zero;

    [Header("Piso")]
    [SerializeField] GameObject[] ListaPiso;

    [Header("Paredes")]
    [SerializeField] GameObject[] ListaParedes;
    public List<Transform> ListaSpawn;
    [Range(0f, 1f)]
    [SerializeField] float chanceDeGerarParede;


    void Start()
    {
        GerarGradePiso();
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
            }
        }
    }

    void GerarPiso(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int indiceAleatorio = Random.Range(0, ListaPiso.Length);
        GameObject clone = Instantiate(ListaPiso[indiceAleatorio], positionToSpawn, rotationToSpawn);
    }

    void GerarParedes(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        float chanceDeGerar = Random.Range(0f, 1f);
        if(chanceDeGerar <= chanceDeGerarParede)
        {
            int indiceAleatorio = Random.Range(0, ListaParedes.Length);
            GameObject clone = Instantiate(ListaParedes[indiceAleatorio], positionToSpawn, rotationToSpawn);
            if(clone.gameObject.name == "SpawnPoint(Clone)")
            {
                ListaSpawn.Add(clone.transform);
            }
        }

    }
}
