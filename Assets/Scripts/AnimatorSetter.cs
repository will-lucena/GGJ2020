using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
    }
}
