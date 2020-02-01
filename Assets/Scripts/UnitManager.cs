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

    private Stack<GameObject> policiesPool;
    private Stack<GameObject> firemanPool;
    private Stack<GameObject> doctorsPool;
    
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
        policiesPool = initPool(policyMaxAmount, UnitKind.Policy);
        doctorsPool = initPool(doctorMaxAmount, UnitKind.Doctor);
        firemanPool = initPool(firemanMaxAmount, UnitKind.Fireman);
    }

    public void sendUnit(EventKind kind, Transform target)
    {
        Unit unit;
        switch (kind)
        {
            case EventKind.PolicyEvent:
                if (policiesPool.Count > 0)
                {
                    unit = policiesPool.Pop().GetComponent<Unit>();
                    unit.gameObject.SetActive(true);
                    unit.setup(policiesHeadquarter, target);
                    Debug.Log("Officer sent"); 
                }
                break;
            case EventKind.FiremanEvent:
                if (firemanPool.Count > 0)
                {
                    unit = firemanPool.Pop().GetComponent<Unit>();
                    unit.gameObject.SetActive(true);
                    unit.setup(firemanHeadquarter, target);
                    Debug.Log("Squirtle sent");
                }
                break;
            case EventKind.DoctorEvent:
                if (doctorsPool.Count > 0)
                {
                    unit = doctorsPool.Pop().GetComponent<Unit>();
                    unit.gameObject.SetActive(true);
                    unit.setup(doctorsHeadquarter, target);
                    Debug.Log("Doctor sent"); 
                }
                break;
            default:
                Debug.Log("gameover");
                break;
        }
    }

    private Stack<GameObject> initPool(int poolSize, UnitKind unitKind)
    {
        GameObject prefab = null;

        switch (unitKind)
        {
            case UnitKind.Policy:
                prefab = policyPrefab;
                break;
            case UnitKind.Fireman:
                prefab = firemanPrefab;
                break;
            case UnitKind.Doctor:
                prefab = doctorPrefab;
                break;
        }
        
        Stack<GameObject> pool = new Stack<GameObject>(poolSize);
    
        for (int i = 0; i < poolSize; i++)
        {
            GameObject go = Instantiate(prefab);
            go.transform.SetParent(transform);
            go.SetActive(false);
            go.GetComponent<Unit>().recall += recall;
            pool.Push(go);
        }

        return pool;
    }

    private void recall(GameObject unit, UnitKind kind)
    {
        switch (kind)
        {
            case UnitKind.Policy:
                unit.SetActive(false);
                policiesPool.Push(unit);
                break;
            case UnitKind.Fireman:
                unit.SetActive(false);
                firemanPool.Push(unit);
                break;
            case UnitKind.Doctor:
                unit.SetActive(false);
                doctorsPool.Push(unit);
                break;
        }
    }
}
