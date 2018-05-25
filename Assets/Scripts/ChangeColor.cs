using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
public class ChangeColor : MonoBehaviour
{

    private Image image;
    public Settings settings;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetRed(float value)
    {
        Color c = image.color;
        image.color = new Color(value, c.g, c.b, 1);
    }
    public void SetGreen(float value)
    {
        Color c = image.color;
        image.color = new Color(c.r, value, c.b, 1);
    }
    public void SetBlue(float value)
    {
        Color c = image.color;
        image.color = new Color(c.r, c.g, value, 1);
    }
    public void SetFirstColor()
    {
        settings.firstColor = image.color;
    }
    public void SetSecondColor()
    {
        settings.secondColor = image.color;
    }
}
