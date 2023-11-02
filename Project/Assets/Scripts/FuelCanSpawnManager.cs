using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelCanSpawnManager : MonoBehaviour
{
    [SerializeField] public GameObject[] fuelCanPrefabs;
    [SerializeField] public Transform[] spawnPoints;
    public float respawnTime = 30.0f;

    private void Start()
    {
        InvokeRepeating("SpawnRandomFuelCan", 0f, respawnTime);
    }

    private void SpawnRandomFuelCan()
    {
        foreach( Transform t in spawnPoints)
        {
            int randomIndex = Random.Range(0, fuelCanPrefabs.Length);
            GameObject selectedFuelCan = fuelCanPrefabs[randomIndex];

            Instantiate(selectedFuelCan, t.position, Quaternion.identity);
        }
    }
}
