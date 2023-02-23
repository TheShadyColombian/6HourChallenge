using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public GameObject[] prefabs;
    public int[] countPerPrefab;
    public float burstStagger;
    public float horizontalRange = 10.0f;
    public float verticalRange = 5.0f;
    public float spawnRate = 1.0f;
    public float spawnTimeVariation;
    private float timeUntilSpawn = 0.0f;

    void Update() {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn < 0) {
            StartCoroutine("BurstCoroutine");
            timeUntilSpawn = spawnRate + Random.Range(-spawnTimeVariation, spawnTimeVariation);
        }
    }

    public IEnumerator BurstCoroutine () {

        for (int i = 0; i < prefabs.Length; i++)
            for (int count = 0; count < countPerPrefab[i]; count++) {
                SpawnEntity(i);
                yield return new WaitForSeconds(burstStagger);
            }
    
    }

    public void SpawnEntity(int entityID) {
        Vector3 spawnPosition = new Vector3(Random.Range(-horizontalRange, horizontalRange), Random.Range(-verticalRange, verticalRange), 0);
        Instantiate(prefabs[entityID], spawnPosition, Quaternion.identity);
    }

}
