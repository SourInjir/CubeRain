using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CollidingObject : MonoBehaviour
{
    [SerializeField] private SystemEventChannel _eventChannel;

    private Renderer _renderer;
    private bool _canChangeColor = true;

    public bool IsCollide { get; private set; } = false;

    private void Awake()
    {

        if(gameObject.TryGetComponent<Renderer>(out var renderer))
        {
            _renderer = renderer;
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<Platform>(out var platform))
        {
            ChangeColor();

            if (_eventChannel != null)
            {
                _eventChannel.DispatchObjectCollideEvent(this);
            }

        }

    }

    private void OnEnable()
    {
        IsCollide = false;
        _canChangeColor = true;
    }

    public void SetIsCollide(bool value = false)
    {
        IsCollide = value;
    }

    public void SetCanChangeColor(bool value = true)
    {
        _canChangeColor = value;
    }

    public void SetEventChannel(SystemEventChannel eventChannel)
    {
        _eventChannel = eventChannel;
    }

    public void ChangeColor()
    {

        if(_canChangeColor == true && _renderer != null)
        {
            _canChangeColor = false;
            _renderer.material.color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        }

    }

}