using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject creditsPanel, menuPanel;
    [SerializeField] private Vector3 outOfScreenPos;
    [SerializeField] private float seconds;

    private float bufferTime;

    public void LoadSceneByName(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadCredits()
    {
        bufferTime = 0;
        StartCoroutine(MenuLerp(creditsPanel, menuPanel));
    }
    
    public void LoadMenu()
    {
        bufferTime = 0;
        StartCoroutine(MenuLerp(menuPanel, creditsPanel));
    }

    private IEnumerator MenuLerp(GameObject MakeOn, GameObject MakeOff)
    {
        MakeOn.SetActive(true);
        while (MakeOff.transform.localPosition != outOfScreenPos)
        {
            bufferTime += Time.deltaTime / seconds;
            MakeOn.transform.localPosition = Vector2.Lerp(outOfScreenPos, Vector3.zero, bufferTime);
            MakeOff.transform.localPosition = Vector2.Lerp(Vector2.zero, outOfScreenPos, bufferTime);
            yield return new WaitForEndOfFrame();
        }
        
        MakeOff.SetActive(false);
    }
}
