using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestJourney : MonoBehaviour
{
    [SerializeField] private Dictionary<int, TextMeshProUGUI> quests;
    [SerializeField] private TextMeshProUGUI logPrefab;

    private void OnEnable()
    {
        EventManager.initQuest += pushQuest;
        EventManager.failureReport += questFail;
        EventManager.successReport += questSuccess;
    }

    private void OnDisable()
    {
        EventManager.initQuest -= pushQuest;
        EventManager.failureReport -= questFail;
        EventManager.successReport -= questSuccess;
    }


    private void Awake()
    {
        quests = new Dictionary<int, TextMeshProUGUI>();
    }

    public void pushQuest(int key, string value)
    {
        TextMeshProUGUI log = Instantiate(logPrefab, transform);
        log.text = value;
        quests.Add(key, log);
    }

    public void questFail(int key)
    {
        TextMeshProUGUI log = quests[key];
        log.fontStyle = FontStyles.Strikethrough;
        log.color = Color.red;
    }

    private void questSuccess(int key)
    {
        GameObject entry = quests[key].gameObject;
        quests.Remove(key);
        Destroy(entry);
    }
}
