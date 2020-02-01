using System;
using TMPro;
using UnityEngine;

public class CameraPinch : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI T1text, T2text, sText;
    [SerializeField] private Camera cam;
    
    
    private Inputs _inputs;
    private float initialDistance, bufferDistance, initialSize;
    private Vector2 t1Pos, t2Pos;
    private bool canPinch;
    private bool beginPinch;
    private void Awake()
    {
        _inputs = new Inputs();
        /*camInputs.Pinch.Touch1.performed += ctx => t1Pos = ctx.ReadValue<Vector2>() / new Vector2(Screen.width, Screen.height);
        camInputs.Pinch.Touch2.performed += ctx => t2Pos = ctx.ReadValue<Vector2>() / new Vector2(Screen.width, Screen.height);
        */
        _inputs.Pinch.Touch1.performed += ctx =>
        {
            t1Pos = ctx.ReadValue<Vector2>();
        };
        _inputs.Pinch.Touch2.performed += ctx =>
        {
            t2Pos = ctx.ReadValue<Vector2>();
            bufferDistance = (Vector2.Distance(t1Pos, t2Pos) - initialDistance);
            cam.orthographicSize = initialSize - bufferDistance/100;
            sText.SetText(bufferDistance.ToString());
        };
        _inputs.Pinch.Tap2.performed += ctx =>
        {
            initialDistance = Vector2.Distance(t1Pos, t2Pos);
            initialSize = cam.orthographicSize;
            canPinch = true;
        };
        _inputs.Pinch.Touch2.canceled += ctx => { canPinch = false; };

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
        T1text.SetText("T1> " + (t1Pos/ new Vector2(Screen.width, Screen.height)).ToString());
        T2text.SetText("T2> " + (t2Pos/ new Vector2(Screen.width, Screen.height)).ToString());
        /*if (beginPinch)
        {
            initialDistance = Vector2.Distance(t1Pos, t2Pos);
            beginPinch = false;
        }
        if (canPinch)
        {
            bufferDistance = Vector2.Distance(t1Pos, t2Pos) - initialDistance;
            cam.orthographicSize += bufferDistance * Time.deltaTime;
            sText.SetText(bufferDistance.ToString());
        }*/
    }

    private void OnEnable()
    {
        _inputs.Pinch.Enable();
    }

    private void OnDisable()
    {
        _inputs.Pinch.Disable();
    }
}