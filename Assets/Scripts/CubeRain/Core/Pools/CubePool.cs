using UnityEngine;

public class CubePool : Pool
{
    [SerializeField] private int _poolSize = 10;
    [SerializeField] private string _poolName = "CubeContainer";
    [SerializeField] private SystemEventChannel _eventChannel;

    private float _minLifeTime = 2.0f;
    private float _maxLifeTime = 5.0f;
    protected override string GetPoolName => _poolName;
    protected override int GetInitialPoolSize => _poolSize;

    private void Awake()
    {
        base.Awake();
        _eventChannel.ObjectCollide += ObjectCollideHandler;
    }

    private void OnDestroy()
    {
        _eventChannel.ObjectCollide -= ObjectCollideHandler;
    }

    private void ObjectCollideHandler(GameObject obj)
    {

        if(obj.TryGetComponent<CollidingObject>(out var colidingObj))
        {

            if (colidingObj.GetIsColide() == false) {
                colidingObj.SetIsColide(true);
                ReturnWithDelay(obj, Random.Range(_minLifeTime, _maxLifeTime));
            }

        }

    }
}