using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class CollidingObject : MonoBehaviour
{
    private bool _isColide = false;
    private bool _canChangeColor = true;

    public bool GetIsColide() => _isColide;

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
        if(_canChangeColor == true && gameObject.TryGetComponent<Renderer>(out var renderer))
        {
            _canChangeColor = false;
            renderer.material.color = new Color(Random.value, Random.value, Random.value);
        }
    }

}