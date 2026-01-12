using UnityEngine;
using System;

public class SystemEventChannel : MonoBehaviour
{
    public event Action<CollidingObject> ObjectCollide;

    public void DispatchObjectCollideEvent(CollidingObject obj)
    {
        ObjectCollide?.Invoke(obj);
    }
}