using UnityEngine;
using System;

public class SystemEventChannel : MonoBehaviour
{
    public event Action<GameObject> ObjectCollide;

    public void DispatchObjectCollideEvent(GameObject obj)
    {
        ObjectCollide?.Invoke(obj);
    }
}