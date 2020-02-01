using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class CameraScroll : MonoBehaviour
{
    [SerializeField] private Transform camTransform = null;

    private Inputs _inputs;
    private Vector2 bufferVector, mouseBufferVector;
    private bool canMouse;

    private void Awake()
    {
        _inputs = new Inputs();
        if (!camTransform)
        {
            camTransform = transform;
        }

        _inputs.Movement.Scroll.performed += ctx => bufferVector = ctx.ReadValue<Vector2>();
        _inputs.Movement.Scroll.canceled += ctx => bufferVector = Vector2.zero;
        
        _inputs.MouseMovement.MouseScrollDelta.performed += ctx => mouseBufferVector = ctx.ReadValue<Vector2>();
        _inputs.MouseMovement.MouseScrollDelta.canceled += ctx => mouseBufferVector = Vector2.zero;

        _inputs.MouseMovement.MousePress.performed += ctx => canMouse = true;
        _inputs.MouseMovement.MousePress.canceled += ctx => canMouse = false;
    }

    private void Update()
    {
        camTransform.position += ((Vector3) (-bufferVector/6) * Time.deltaTime);
        if(canMouse)
            MouseMoveCamera(mouseBufferVector/6);
    }

    private void MouseMoveCamera(Vector3 deltaVector)
    {
        camTransform.position += (-deltaVector * Time.deltaTime);
    }
    
    private void OnEnable()
    {
        _inputs.Movement.Enable();
    }

    private void OnDisable()
    {
        _inputs.Movement.Disable();
    }
}
