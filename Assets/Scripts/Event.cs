using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Event : MonoBehaviour
{
    public static Action<EventKind, Transform> callUnities;
    
    private float _hardness;
    private float _timeToFail;
    private float _timeToSucess;
    private float _fixTime;
    private string _name;
    private EventKind _kind;

    public Action<string, Vector3> eventFail;
    public Action<string, Vector3> eventSuccess;
    
    public void setup(Vector3 eventPoint, EventDefinition eventDefinition)
    {
        transform.localPosition = eventPoint;
        _hardness = eventDefinition.hardness;
        _timeToFail = eventDefinition.timeToFail;
        _timeToSucess = eventDefinition.timeToSuccess;
        _name = eventDefinition.name;
        _kind = eventDefinition.kind;

        GetComponent<SpriteRenderer>().color = eventDefinition.color;
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
            eventFail?.Invoke(_name, transform.position);
            StopAllCoroutines();
        }
        Destroy(gameObject);
    }

    private IEnumerator fix()
    {
        _fixTime = 0f;
        while (_fixTime < _timeToSucess)
        {
            _fixTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        eventSuccess?.Invoke(_name, transform.position);
        StopAllCoroutines();
        Destroy(gameObject);
    }

    public void fail()
    {
        StopAllCoroutines();
        eventFail?.Invoke(_name, transform.position);
        Destroy(gameObject);
    }
    
    public void success()
    {
        StopAllCoroutines();
        eventSuccess?.Invoke(_name, transform.position);
        Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        Debug.Log("Calling unities");
        callUnities?.Invoke(_kind, transform);
    }
}
