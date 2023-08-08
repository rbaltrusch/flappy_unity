using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private float spawnX;
    [SerializeField] private float maxSpawnY;
    [SerializeField] private float spawnDelay;
    private float lastSpawnedTime;

    private void Start()
    {
        lastSpawnedTime = 0;
        SpawnObject();
    }

    private void Update()
    {
        lastSpawnedTime += Time.deltaTime;
        if (lastSpawnedTime > spawnDelay)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        lastSpawnedTime = 0;
        float spawnY = Random.Range(-maxSpawnY, maxSpawnY);
        Instantiate(prefab, new Vector3(spawnX, spawnY), Quaternion.identity);
    }
}
