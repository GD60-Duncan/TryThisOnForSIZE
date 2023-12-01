using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatSetting : ScriptableObject
{
    [Header("Setting")]
    [SerializeField] private string _name;
    [SerializeField] private float _default = 0f;

    [SerializeField] private float _floatValue;

    private float sliderValue;

    public void SetSliderValue(float value)
    {
        sliderValue = value;
    }

}