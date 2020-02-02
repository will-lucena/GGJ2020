using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Utils;

public class AnimationRunner : MonoBehaviour
{
    public Action<EventKind> callUnities;
    public Action<bool> animationState;
    
    [SerializeField] private Vector3 initialPosition;
    [SerializeField] private Vector3 finalPosition;
    [SerializeField] private float duration;
    [SerializeField] private AnimationCurve curve;
    [SerializeField] private EventKind unit;

    private Image _image;
    
    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.enabled = false;
        _image.raycastTarget = false;
    }

    public void openAnimation()
    {
        Debug.Log(unit + " Running open animation");
        runAnimation(initialPosition, finalPosition, duration, curve);
    }

    public void closeButton()
    {
        Debug.Log(unit + " Running close animation");
        runAnimation(finalPosition, initialPosition, duration, curve, false);
    }
    
    private void runAnimation(Vector3 initialPosition, Vector3 finalPosition, float duration, AnimationCurve curve, bool disableButton = true)
    {
        StartCoroutine(translateObject(initialPosition, finalPosition, duration, curve, disableButton));
    }
    
    private IEnumerator translateObject (Vector3 initialPosition, Vector3 finalPosition, float duration, AnimationCurve curve, bool disableButton = true)
    {
        _image.enabled = true;
        _image.raycastTarget = false;
        animationState?.Invoke(false);
        float i = 0;
        float rate = 1 / duration;
        while (i < 1) {
            i += rate * Time.deltaTime;
            transform.localPosition = Vector3.Lerp (initialPosition, finalPosition, curve.Evaluate (i));
            yield return null;
        }
        
        if (!disableButton)
        {
            _image.enabled = false;
        }
        _image.raycastTarget = disableButton;
        animationState?.Invoke(true);
    }

    public void callUnit()
    {
        Debug.Log("Call " + unit);
        callUnities?.Invoke(unit);
    }
}
