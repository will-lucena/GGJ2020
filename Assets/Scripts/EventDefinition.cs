using System.Collections;
using System.Collections.Generic;
using Utils;
using UnityEngine;

[CreateAssetMenu(fileName = "Calamity", menuName = "Event")]
public class EventDefinition : ScriptableObject
{
    [SerializeField] private EventKind _kind;
    [SerializeField] private float _hardness;
    [SerializeField] private float _timeToFail;
    [SerializeField] private float _timeToSuccess;
    [SerializeField] private string _name;
    [SerializeField] private Color _color;

    public EventKind kind => _kind;
    public new string name => _name;
    public float hardness => _hardness;
    public float timeToFail => _timeToFail;
    public float timeToSuccess => _timeToSuccess;
    public Color color => _color;

}
