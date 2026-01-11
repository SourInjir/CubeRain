using UnityEngine;
public class CubeSpawner: ObjectSpawner
{
    private const int MinSpawnCount = 2;
    private const int MaxSpawnCount = 6;
    private const float ScaleFactor = 0.5f;
    private const float ObjectLifeTime = 20.0f;

    public CubeSpawner(CubePool pool) : base(pool)
    {
       
    }

    public GameObject SpawnObject(Vector3 position, Vector3 scale)
    {
        var obj = _pool.Get();
        obj.transform.position = position;
        obj.transform.localScale = scale * ScaleFactor;

        if (obj.TryGetComponent<Renderer>(out var renderer))
        {
            renderer.material.color = new Color(1, 1, 1);
        }

        return obj;
    }

    public void SpawnRandomQuantity(int min, int max, Vector3 spawnPosition, float radius)
    {
        
        int count = Random.Range(MinSpawnCount, MaxSpawnCount);

        for (int i = 0; i < count; i++)
        {
            var objInstance = SpawnObject(GetRandomPositionInCircle(spawnPosition, radius), new Vector3(1,1,1));
        }

    }

    private Vector3 GetRandomPositionInCircle(Vector3 center, float radius)
    {
        Vector2 randomPointInCircle = Random.insideUnitCircle * radius;
        return center + new Vector3(randomPointInCircle.x, 0f, randomPointInCircle.y);
    }
}