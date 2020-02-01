using System.Collections;
using System.Collections.Generic;
using Definitions;
using UnityEngine;

[CreateAssetMenu(fileName = "Calamity", menuName = "Event")]
public class EventDefinition : ScriptableObject
{
    [SerializeField] private EventKind _kind;
    [SerializeField] private float _hardness;
    [SerializeField] private float _timeToFail;
    [SerializeField] private float _timeToSuccess;
    [SerializeField] private string _name;

    public EventKind kind => _kind;
    public new string name => _name;
    
}
