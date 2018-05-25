using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetNumber : MonoBehaviour
{

    public Slider slider;
    public Text textUI;

    // Update is called once per frame
    void Update()
    {
        slider = GetComponent<Slider>();
        Debug.Log(slider);
        if (slider)
        {

        }
        float f = (slider.normalizedValue * 255f);
        Debug.Log(f);
        textUI = GetComponent<Text>();
        textUI.text = f.ToString();

    }
}
