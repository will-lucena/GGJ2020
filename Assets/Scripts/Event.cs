using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Event : MonoBehaviour
{
    public static Action<EventKind, Transform> callUnities;
    public Action<string, Vector3, int> eventFail;
    public Action<string, Vector3, int> eventSuccess;

    [SerializeField] private EventBar failBarController;
    [SerializeField] private EventBar fixBarController;
    [SerializeField] private AnimationRunner policyButton;
    [SerializeField] private AnimationRunner medicButton;
    [SerializeField] private AnimationRunner firemanButton;
    
    private float _hardness;
    private float _timeToFail;
    private float _timeToSucess;
    private float _fixTime;
    private string _name;
    private int _id;
    private Animator _animator;
    private bool _isOpen;

    private bool firemanButtonAnimationFinished;
    private bool policyButtonAnimationFinished;
    private bool medicButtonAnimationFinished;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        firemanButtonAnimationFinished = true;
        medicButtonAnimationFinished = true;
        policyButtonAnimationFinished = true;
    }

    private void OnEnable()
    {
        policyButton.callUnities += requestUnities;
        policyButton.animationState += updatePolicyButtonState;
        medicButton.callUnities += requestUnities;
        medicButton.animationState += updateMedicButtonState;
        firemanButton.callUnities += requestUnities;
        firemanButton.animationState += updateFiremanButtonState;
    }

    private void OnDisable()
    {
        policyButton.callUnities += requestUnities;
        policyButton.animationState -= updatePolicyButtonState;
        medicButton.callUnities += requestUnities;
        medicButton.animationState -= updateMedicButtonState;
        firemanButton.callUnities += requestUnities;
        firemanButton.animationState -= updateFiremanButtonState;
    }

    private void updatePolicyButtonState(bool state)
    {
        policyButtonAnimationFinished = state;
    }
    
    private void updateMedicButtonState(bool state)
    {
        medicButtonAnimationFinished = state;
    }
    
    private void updateFiremanButtonState(bool state)
    {
        firemanButtonAnimationFinished = state;
    }
    
    public void setup(Vector3 eventPoint, EventDefinition eventDefinition, Transform parent, int id)
    {
        transform.SetParent(parent);
        transform.position = eventPoint;
        _hardness = eventDefinition.hardness;
        _timeToFail = eventDefinition.timeToFail;
        _timeToSucess = eventDefinition.timeToSuccess;
        _name = eventDefinition.description;
        _id = id;
        _animator.SetTrigger(eventDefinition.kind.ToString());
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        float totalTime = 0f;
        while (totalTime < _timeToFail)
        {
            totalTime += Time.deltaTime;
            failBarController.updateBar(1 - Mathf.Clamp(totalTime / _timeToFail, 0f, 1f));
            yield return new WaitForEndOfFrame();
        }

        if (_fixTime < _timeToSucess)
        {
            eventFail?.Invoke(_name, transform.position, _id);
            StopAllCoroutines();
        }
        Invoke("destroy", 1);;
    }

    private IEnumerator fix()
    {
        _fixTime = 0f;
        fixBarController.initBar();
        while (_fixTime < _timeToSucess)
        {
            _fixTime += Time.deltaTime;
            fixBarController.updateBar(Mathf.Clamp(_fixTime / _timeToSucess, 0f, 1f));
            yield return new WaitForEndOfFrame();
        }
        eventSuccess?.Invoke(_name, transform.position, _id);
        StopAllCoroutines();
        Invoke("destroy", 1);
    }

    private void destroy()
    {
        Destroy(gameObject);
    }

    public void fail()
    {
        Debug.Log("Event fail");
        StopAllCoroutines();
        eventFail?.Invoke(_name, transform.position, _id);
        Destroy(gameObject);
    }
    
    public void success()
    {
        Debug.Log("Event success");
        StopAllCoroutines();
        eventSuccess?.Invoke(_name, transform.position, _id);
        Destroy(gameObject);
    }

    private bool canClick()
    {
        return firemanButtonAnimationFinished && medicButtonAnimationFinished && policyButtonAnimationFinished;
    }
    
    private void OnMouseDown()
    {
        if (canClick())
        {
            if (_isOpen)
            {
                Debug.Log("FAB close");
                policyButton.closeButton();
                firemanButton.closeButton();
                medicButton.closeButton();
                _isOpen = false;
            }
            else
            {
                _isOpen = true;
                Debug.Log("FAB open");
                policyButton.openAnimation();
                firemanButton.openAnimation();
                medicButton.openAnimation();
            }
        }
    }

    private void requestUnities(EventKind kind)
    {
        Debug.Log("Calling unities");
        policyButton.closeButton();
        firemanButton.closeButton();
        medicButton.closeButton();
        callUnities?.Invoke(kind, transform);
        _isOpen = false;
    }
    
    public void unitArrive()
    {
        Debug.Log("Unit arrived");
        if (_fixTime <= 0f)
        {
            StartCoroutine(fix());
        }
    }
}
