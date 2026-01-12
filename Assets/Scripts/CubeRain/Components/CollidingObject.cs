using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CollidingObject : MonoBehaviour
{
    private Renderer _renderer;
    private bool _canChangeColor = true;
    public Action OnDisableRequest;
    public bool _isColide { get; private set; } = false;

    private void Awake()
    {

        if(gameObject.TryGetComponent<Renderer>(out var renderer))
        {
            _renderer = renderer;
        }

    }
    private void OnEnable()
    {
        _isColide = false;
        _canChangeColor = true;
    }

    public void SetIsColide(bool value = false)
    {
        _isColide = value;
    }

    public void SetCanChangeColor(bool value = true)
    {
        _canChangeColor = value;
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