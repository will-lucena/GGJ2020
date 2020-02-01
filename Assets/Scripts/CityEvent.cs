using System;
using UnityEngine;

public class CityEvent : MonoBehaviour
{
    public delegate void CityEventDelegate();

    public static event CityEventDelegate OnEventSelect;

    protected virtual void OnMouseDown()
    {
        OnEventSelect?.Invoke();
    }
}