using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public float horizontalRange = 10.0f;
    public float verticalRange = 5.0f;
    public float spawnRate = 1.0f;

    private float timeSinceLastSpawn = 0.0f;

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnRate)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-horizontalRange, horizontalRange), Random.Range(-verticalRange, verticalRange), 0);
            Instantiate(prefabs[Random.Range(0, prefabs.Length)], spawnPosition, Quaternion.identity);

            timeSinceLastSpawn = 0.0f;
        }
    }
}
