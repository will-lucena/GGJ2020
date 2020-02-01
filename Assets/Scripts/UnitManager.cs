using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utils;

public class UnitManager : MonoBehaviour
{
    [SerializeField] private int policyMaxAmount;
    [SerializeField] private int firemanMaxAmount;
    [SerializeField] private int doctorMaxAmount;
    [SerializeField] private Transform policiesHeadquarter;
    [SerializeField] private Transform firemanHeadquarter;
    [SerializeField] private Transform doctorsHeadquarter;

    [SerializeField] private GameObject policyPrefab;
    [SerializeField] private GameObject firemanPrefab;
    [SerializeField] private GameObject doctorPrefab;

    private int currentPoliciesAmount;
    private int currentFiremanAmount;
    private int currentDoctorsAmount;

    private void OnEnable()
    {
        Event.callUnities += sendUnit;
    }

    private void OnDisable()
    {
        Event.callUnities -= sendUnit;
    }

    private void Awake()
    {
        currentDoctorsAmount = doctorMaxAmount;
        currentFiremanAmount = firemanMaxAmount;
        currentPoliciesAmount = policyMaxAmount;
    }

    public void sendUnit(EventKind kind, Transform target)
    {
        GameObject go;
        Unit unit;
        switch (kind)
        {
            case EventKind.PolicyEvent:
                go = Instantiate(policyPrefab);
                unit = go.GetComponent<Unit>();
                unit.setup(policiesHeadquarter, target);
                Debug.Log("Officer sent"); 
                break;
            case EventKind.FiremanEvent:
                go = Instantiate(firemanPrefab);
                unit = go.GetComponent<Unit>();
                unit.setup(firemanHeadquarter, target);
                Debug.Log("Squirtle sent"); 
                break;
            case EventKind.DoctorEvent:
                go = Instantiate(doctorPrefab);
                unit = go.GetComponent<Unit>();
                unit.setup(doctorsHeadquarter, target);
                Debug.Log("Doctor sent"); 
                break;
            default:
                Debug.Log("gameover");
                break;
        }
    }
}
