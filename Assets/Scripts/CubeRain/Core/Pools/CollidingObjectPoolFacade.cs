using UnityEngine;
using UnityEngine.Pool;

public class CollidingObjectPoolFacade : MonoBehaviour
{
    [SerializeField] private CollidingObject _prefab;
    [SerializeField] private SystemEventChannel _eventChannel;

    private float _minLifeTime = 2.0f;
    private float _maxLifeTime = 5.0f;
    private int _defaultCapacity = 20;
    private int _maxSize = 100;

    public ObjectPool<CollidingObject> _pool;

    private void Awake()
    {
        _eventChannel.ObjectCollide += ObjectCollideHandler;
        _pool = new ObjectPool<CollidingObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolItem, true, _defaultCapacity, _maxSize);

        for (int i = 0; i < _defaultCapacity; i++)
        {
            _pool.Release(CreatePooledItem());
        }
    }

    private void OnDestroy()
    {
        _eventChannel.ObjectCollide -= ObjectCollideHandler;
    }

    private void ObjectCollideHandler(CollidingObject obj)
    {

        if (obj.IsCollide == false)
        {
            obj.SetIsCollide(true);
            ReturnWithDelay(obj, Random.Range(_minLifeTime, _maxLifeTime));
        }

    }

    private CollidingObject CreatePooledItem()
    {
        CollidingObject obj = Instantiate(_prefab);
        obj.SetEventChannel(_eventChannel);
        return obj;
    }

    private void OnTakeFromPool(CollidingObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    private void OnReturnedToPool(CollidingObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void OnDestroyPoolItem(CollidingObject obj)
    {
        Destroy(obj.gameObject);
    }

    public CollidingObject Spawn()
    {
        CollidingObject obj = _pool.Get();
        return obj;
    }

    public void ReturnWithDelay(CollidingObject obj, float delay)
    {
        StartCoroutine(ReturnCoroutine(obj, delay));
    }

    protected System.Collections.IEnumerator ReturnCoroutine(CollidingObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        _pool.Release(obj);
    }
}
