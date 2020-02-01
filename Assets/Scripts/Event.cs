using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{
    private float _hardness;
    private float _timeToFail;
    private float _timeToSucess;
    private float _fixTime;
    private string _name;

    public Action<string> eventFail;
    public Action<string> eventSuccess;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setup(Transform eventPoint, EventDefinition eventDefinition)
    {
        transform.localPosition = eventPoint.localPosition;
        _hardness = eventDefinition.hardness;
        _timeToFail = eventDefinition.timeToFail;
        _timeToSucess = eventDefinition.timeToSuccess;
        _name = eventDefinition.name;
        StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        float totalTime = 0f;
        while (totalTime < _timeToFail)
        {
            totalTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        if (_fixTime < _timeToSucess)
        {
            eventFail?.Invoke(_name);
            StopAllCoroutines();
        }
    }

    private IEnumerator fix()
    {
        _fixTime = 0f;
        while (_fixTime < _timeToSucess)
        {
            _fixTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        eventSuccess?.Invoke(_name);
        StopAllCoroutines();
    }

    public void fail()
    {
        StopAllCoroutines();
        eventFail?.Invoke(_name);
    }
    
    public void success()
    {
        StopAllCoroutines();
        eventSuccess?.Invoke(_name);
    }
}
