using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventBar : MonoBehaviour
{
    [SerializeField] private Image bar;

    public void initBar()
    {
        Image image = GetComponent<Image>();
        Color color = image.color; 
        image.color = new Color(color.r, color.g, color.b, 159f / 255f);
    }
    
    public void updateBar(float value)
    {
        bar.fillAmount = value;
    }
}
