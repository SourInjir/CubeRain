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
    [SerializeField] private CollidingObjectPoolFacade _poolFacade;
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private float _spawnRadius = 10.0f;

    private CubeSpawner _cubeSpawner;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _cubeSpawner = new CubeSpawner(_poolFacade);
        _waitForSeconds = new WaitForSeconds(SpawnDelay);
    }

    private void Start()
    {
        StartCoroutine(CubeRain());
    }

    protected System.Collections.IEnumerator CubeRain()
    {
        while (true)
        {
            if(_spawnPoint != null)
            {
                _cubeSpawner.SpawnRandomQuantity(MinSpawnCount, MaxSpawnCount, _spawnPoint.transform.position, _spawnRadius);
            }

            yield return _waitForSeconds;

        }
    }
}