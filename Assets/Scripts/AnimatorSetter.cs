using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.PlayerLoop;
using Utils;

public class AnimatorSetter : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AIPath pathAI;
    [SerializeField] private Unit unit;
    
    private void Awake()
    {
        if (!anim)
        {
            anim = GetComponent<Animator>();
        }

        if (!pathAI)
        {
            pathAI = GetComponent<AIPath>();
        }
        
        if (!unit)
        {
            unit = GetComponent<Unit>();
        }
    }

    void Update()
    {
        if (pathAI.hasPath)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (unit.GetState() == State.Used)
        {
            anim.SetBool("Working", true);
        }
        else 
        {
            anim.SetBool("Working", false);
        }
    }
}
