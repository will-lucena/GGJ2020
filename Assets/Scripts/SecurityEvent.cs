using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityEvent : CityEvent
{
    protected override void OnMouseDown()
    {
        base.OnMouseDown();
        Debug.Log("Test2");
    }
}
