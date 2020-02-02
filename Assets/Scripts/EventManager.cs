using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Utils;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static Action<int, string> initQuest;
    public static Action<int> failureReport;
    public static Action<int> successReport;
    
    [SerializeField] private bool loadEventPointsManually;
    [SerializeField] private Dictionary<Vector3, State> eventPoints;
    [SerializeField] private GameObject eventPrefab;
    [SerializeField] private bool autoGenerateEvents;
    [SerializeField] private float eventsInterval;
    [SerializeField] private int gameoverCondition;
    
    private List<EventDefinition> _eventsBase;
    private Event _currentEvent;
    private int questCount;
    private int failCount;
    
    private void Awake()
    {
        loadEventsBase();
        questCount = 0;
        failCount = 0;
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

            initQuest?.Invoke(questCount, eventDefinition.description);
            questCount++;
            
            GameObject go = Instantiate(eventPrefab);
            _currentEvent = go.GetComponent<Event>();
            _currentEvent.setup(eventPoint, eventDefinition, transform, questCount);
            _currentEvent.eventFail += handleFailure;
            _currentEvent.eventSuccess += handleFix;
        }
    }

    private void handleFailure(string eventName, Vector3 key, int id)
    {
        Debug.Log(eventName + " fail");
        failureReport?.Invoke(id);
        failCount++;

        if (failCount >= gameoverCondition)
        {
            Debug.Log("Gameover");
        }
        eventPoints[key] = State.Available;
    }

    private void handleFix(string eventName, Vector3 key, int id)
    {
        Debug.Log(eventName + " fixed");
        successReport?.Invoke(id);
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
