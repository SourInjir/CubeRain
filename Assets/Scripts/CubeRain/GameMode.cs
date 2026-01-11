using UnityEngine;
using System.Collections.Generic;

public class GameMode : MonoBehaviour
{
    private const float SpawnChanse = 100f;
    private const int MinSpawnCount = 2;
    private const int MaxSpawnCount = 6;
    private const float SpawnDelay = 1.0f;

    [Header("Dependencies")]
    [SerializeField] private SystemEventChannel _systemEventChannel;
    [SerializeField] private CubePool _cubePool;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private float _spawnRadius = 10.0f;

    private float spawnFactor = 1f;
   

    private CubeSpawner _cubeSpawner;

    private void Awake()
    {
        _cubeSpawner = new CubeSpawner(_cubePool);
    }

    private void Start()
    {
        StartCoroutine(CubeRain());
    }

    private bool CanSpawn()
    {
        float chanse = Random.Range(0, SpawnChanse);
        float currentChanse = SpawnChanse / spawnFactor;
        return currentChanse >= chanse;
    }

    protected System.Collections.IEnumerator CubeRain()
    {
        while (true)
        {
            if(_spawnPoint != null)
            {
                _cubeSpawner.SpawnRandomQuantity(MinSpawnCount, MaxSpawnCount, _spawnPoint.transform.position, _spawnRadius);
            }

            yield return new WaitForSeconds(SpawnDelay);

        }
    }
}