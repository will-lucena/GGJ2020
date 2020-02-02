using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpriteChanger : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image imageToChange;

    [SerializeField] private Sprite regularSprite, pressedSprite;

    public void ChangeSprite()
    { 
        StartCoroutine(SpriteChange());
    }

    private IEnumerator SpriteChange()
    {
        imageToChange.sprite = pressedSprite;
        yield return new WaitForSeconds(0.5f);
        imageToChange.sprite = regularSprite;
    }
}
