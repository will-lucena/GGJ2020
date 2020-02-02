using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using Utils;

public class Unit : MonoBehaviour
{
    public Action<GameObject, UnitKind> recall;
    
    [SerializeField] private UnitDefinition unit;

    private State state;
    private AIPath _aiPath;
    private AIDestinationSetter _destinationSetter;
    private Event _task;
    
    public void setup(Transform headquarter, Transform target)
    {
        var position = headquarter.position;
        transform.position = new Vector3(position.x, position.y, -2f);
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _aiPath = GetComponent<AIPath>();
        _aiPath.maxSpeed = unit.movementSpeed;

        state = State.Available;
        _destinationSetter.target = target;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.position == _destinationSetter.target.position)
        {
            _task = other.GetComponent<Event>();
            _task.eventSuccess += freeUnit;
            _task.eventFail += freeUnit;
            _task.unitArrive(unit.skillValue(_task.getEventKind));
            Debug.Log("Starting to work");
            state = State.Used;
        }
    }

    private void freeUnit(string eventName, Vector3 eventPosition, int id)
    {
        _task.eventSuccess -= freeUnit;
        _task.eventFail -= freeUnit;
        recall?.Invoke(gameObject, unit.kind);
        state = State.Available;
    }

    public Utils.State GetState()
    {
        return state;
    }

    public Event GetTask()
    {
        return _task;
    }
}
