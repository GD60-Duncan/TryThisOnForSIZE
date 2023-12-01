using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu]
public class MixerParameterSetting : FloatSetting
{
    [Header("Mixer")]
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _parameterName = "Parameter Name";

    [Range(0,1)]
    public float SliderValue;

    public void SetValue(float newValue)
    {

        _audioMixer.SetFloat(_parameterName, Mathf.Log10(newValue) * 20);
        SliderValue = newValue;
        SetSliderValue(newValue);
        //Debug.Log(newValue + "" + this);
    }
}
