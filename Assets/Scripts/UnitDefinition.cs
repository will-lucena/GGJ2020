using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utils;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "Unit")]
public class UnitDefinition : ScriptableObject
{
    [SerializeField] private UnitKind _kind;
    [SerializeField] private float _movementSpeed;

    [SerializeField] private SkillDict[] _skills;

    public UnitKind kind => _kind;
    public float movementSpeed => _movementSpeed;
    
    public float skillValue(EventKind kind)
    {
        return _skills.First(item =>
        {
            return item.kind == kind;
        }).value;
    }
    
    [Serializable]
    private class SkillDict
    {
        public EventKind kind;
        public float value;
    }
}