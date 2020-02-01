using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] private UnitDefinition unit;
    
    private AIPath _aiPath;
    private AIDestinationSetter _destinationSetter;
    
    public void setup(Transform headquarter, Transform target)
    {
        var position = headquarter.position;
        transform.position = new Vector3(position.x, position.y, -2f);
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _aiPath = GetComponent<AIPath>();
        _aiPath.maxSpeed = unit.movementSpeed;

        _destinationSetter.target = target;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError(other.GetComponent<Event>().name);
    }
}
