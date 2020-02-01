using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utils;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private bool loadEventPointsManually;
    [SerializeField] private Dictionary<Vector3, State> eventPoints;
    [SerializeField] private GameObject eventPrefab;
    [SerializeField] private bool autoGenerateEvents;
    [SerializeField] private float eventsInterval;
    
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

        if (autoGenerateEvents)
        {
            InvokeRepeating("startEvent", 0f, eventsInterval);
        }
    }
    
    private void loadPoints()
    {
        eventPoints = new Dictionary<Vector3, State>();
        eventPoints.Clear();
        foreach (Transform eventPoint in transform.GetComponentsInChildren<Transform>())
        {
            eventPoints.Add(eventPoint.position, State.Available);
        }

        eventPoints.Remove(transform.position);
    }

    private void loadEventsBase()
    {
        _eventsBase = Resources.LoadAll<EventDefinition>("events/").ToList();
    }

    public void startEvent()
    {
        Vector3 eventPoint = eventPoints.Keys.FirstOrDefault(key => eventPoints[key] == State.Available);
        if (eventPoint != Vector3.zero)
        {
            eventPoints[eventPoint] = State.Used;
            EventDefinition eventDefinition = _eventsBase[Utils.Functions.randomInt(_eventsBase.Count)];

            GameObject go = Instantiate(eventPrefab);
            _currentEvent = go.GetComponent<Event>();
            _currentEvent.setup(eventPoint, eventDefinition, transform);
            _currentEvent.eventFail += handleFailure;
            _currentEvent.eventSuccess += handleFix;
        }
    }

    private void handleFailure(string eventName, Vector3 key)
    {
        Debug.Log(eventName + " fail");
        eventPoints[key] = State.Available;
    }

    private void handleFix(string eventName, Vector3 key)
    {
        Debug.Log(eventName + " fixed");
        eventPoints[key] = State.Available;
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
