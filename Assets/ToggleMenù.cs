using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleMenù : MonoBehaviour
{

    bool toggle;
    private void Awake()
    {
        toggle = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleVIsibility();
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(toggle);
            }

        }
    }

    void ToggleVIsibility()
    {
        if (toggle)
        {
            toggle = false;
        }
        else if (!toggle)
        {
            toggle = true;
        }
    }
}
