using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utils;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private bool loadEventPointsManually;
    [SerializeField] private Dictionary<Transform, State> eventPoints;
    [SerializeField] private GameObject eventPrefab;
    
    
    private List<EventDefinition> _eventsBase;
    private Event _currentEvent;
    
    private void Awake()
    {
        loadEventsBase();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!loadEventPointsManually)
        {
            loadPoints();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void loadPoints()
    {
        eventPoints = new Dictionary<Transform, State>();
        eventPoints.Clear();
        foreach (Transform eventPoint in transform.GetComponentsInChildren<Transform>())
        {
            eventPoints.Add(eventPoint, State.Available);
        }
    }

    private void loadEventsBase()
    {
        _eventsBase = Resources.LoadAll<EventDefinition>("events/").ToList();
    }

    public void startEvent()
    {
        Transform eventPoint = eventPoints.Keys.First(key => eventPoints[key] == State.Available);
        eventPoints[eventPoint] = State.Used;
        EventDefinition eventDefinition = _eventsBase[Utils.Functions.randomInt(_eventsBase.Count)];

        GameObject go = Instantiate(eventPrefab);
        _currentEvent = go.GetComponent<Event>();
        _currentEvent.setup(eventPoint, eventDefinition);
        _currentEvent.eventFail += handleFailure;
        _currentEvent.eventSuccess += handleFix;
    }

    private void handleFailure(string eventName)
    {
        Debug.Log(eventName + " fail");
    }

    private void handleFix(string eventName)
    {
        Debug.Log(eventName + " fixed");
    }

    public void fail()
    {
        _currentEvent.fail();
    }
    
    public void fix()
    {
        _currentEvent.success();
    }
}
