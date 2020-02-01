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

    private CameraMovements camInputs;
    private MouseMovements mouseInputs;
    private Vector2 bufferVector, mouseBufferVector;
    private bool canMouse;

    private void Awake()
    {
        camInputs = new CameraMovements();
        mouseInputs = new MouseMovements();
        if (!camTransform)
        {
            camTransform = transform;
        }

        camInputs.Movement.Scroll.performed += ctx => bufferVector = ctx.ReadValue<Vector2>();
        camInputs.Movement.Scroll.canceled += ctx => bufferVector = Vector2.zero;
        
        mouseInputs.Movement.MouseScrollDelta.performed += ctx => mouseBufferVector = ctx.ReadValue<Vector2>();
        mouseInputs.Movement.MouseScrollDelta.canceled += ctx => mouseBufferVector = Vector2.zero;

        mouseInputs.Movement.MousePress.performed += ctx => canMouse = true;
        mouseInputs.Movement.MousePress.canceled += ctx => canMouse = false;
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
        camInputs.Movement.Enable();
        mouseInputs.Movement.Enable();
    }

    private void OnDisable()
    {
        camInputs.Movement.Disable();
        mouseInputs.Movement.Disable();
    }
}
