using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.Touch;

public class CameraScroll : MonoBehaviour
{
    [SerializeField] private Transform camTransform = null;
    [SerializeField] private TextMeshProUGUI T1text, T2text, sText;
    [SerializeField] private Camera cam;
    [SerializeField] private float pinchVelocity = 2.5f;
    
    
    private float initialDistance, bufferDistance, initialSize;
    private Vector2 t1Pos, t2Pos;
    private bool canPinch = false;
    private bool beginPinch;

    private Inputs _inputs;
    private Vector2 bufferVector, mouseBufferVector, screenSize;
    private bool canMouse;

    private void Awake()
    {
        screenSize = new Vector2(Screen.width, Screen.height);
        EnhancedTouchSupport.Enable();
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

        /*_inputs.Pinch.Touch1.performed += ctx =>
        {
            t1Pos = ctx.ReadValue<Vector2>();
        };*/

        if (!cam)
        {
            try
            {
                cam = GetComponent<Camera>();
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }

    private void Update()
    {
        if(Input.touchCount < 2 && Input.touchCount != 0)
            camTransform.position += ((Vector3) (-bufferVector/6) * Time.deltaTime);
        if(canMouse)
            MouseMoveCamera(mouseBufferVector/6);

        if (Input.touchCount >= 2)
        {
            Touch touch = Input.GetTouch(1);
            if (!canPinch)
            {
                t1Pos = Input.GetTouch(0).position / screenSize;
                t2Pos = Input.GetTouch(1).position / screenSize;
                initialDistance = Vector3.Distance(t1Pos, t2Pos);
                initialSize = cam.orthographicSize;
                canPinch = true;
            }
            else
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    t1Pos = Input.GetTouch(0).position / screenSize;
                    t2Pos = Input.GetTouch(1).position / screenSize;
                    bufferDistance = (Vector2.Distance(t1Pos, t2Pos) - initialDistance) * pinchVelocity;
                    cam.orthographicSize = initialSize - bufferDistance;
                    sText.SetText(bufferDistance.ToString());
                }
            }
        }
        else
        {
            canPinch = false;
            sText.SetText("NOT PINCHING");
        }

    }

    private void MouseMoveCamera(Vector3 deltaVector)
    {
        camTransform.position += (-deltaVector * Time.deltaTime);
    }
    
    private void OnEnable()
    {
        _inputs.Movement.Enable();
        _inputs.Pinch.Enable();
    }

    private void OnDisable()
    {
        _inputs.Movement.Disable();
        _inputs.Pinch.Disable();
    }
}

/*
 
        _inputs.Pinch.Touch2.performed += ctx =>
        {
            if (!canPinch)
            {
                initialDistance = Vector2.Distance(t1Pos, t2Pos);
                initialSize = cam.orthographicSize;
                canPinch = true;
            }
            else
            {
                t2Pos = ctx.ReadValue<Vector2>();
                bufferDistance = (Vector2.Distance(t1Pos, t2Pos) - initialDistance);
                cam.orthographicSize = initialSize - bufferDistance / 100;
                sText.SetText(bufferDistance.ToString());
            }
        };

        Touch.onFingerUp += ctx =>
        {
            if (ctx.index == 2)
            {
                canPinch = false; 
                sText.SetText("NOT PINCHING");
            }
        };
        _inputs.Pinch.Tap2.canceled += ctx =>
        {
            canPinch = false; 
            sText.SetText("NOT PINCHING");
        };
 */
