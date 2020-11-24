using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public ProgressBar instance;

    private Slider slider;

    public float value
    {
        get
        {
            return slider.value;
        }
        set
        {
            slider.value = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        slider = gameObject.GetComponent<Slider>();
    }
}
