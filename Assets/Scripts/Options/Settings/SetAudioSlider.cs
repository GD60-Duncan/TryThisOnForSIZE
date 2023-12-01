using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetAudioSlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private MixerParameterSetting _floatSetting;
    [SerializeField] private SaveData _saveData;
    [SerializeField] private FloatSetting[] _mixerParameter;

    private int number;

    void Awake()
    {
       int l = _mixerParameter.Length;

       
        
        for(int i = 0; i < l; i++)
        {
            number = i;
            
            if(_floatSetting == _mixerParameter[i])
            {
                break;
            }

        }

        //Debug.Log(_floatSetting.GetSliderValue());
    }
    
    void OnEnable()
    {
        
        //_slider.SetValueWithoutNotify(_saveData.SliderValue[number]);
        //Debug.Log(number + " " + this.gameObject);
        //_slider.value = _saveData.SliderValue[number];   
    }

    void OnDisable()
    {
        //  if(_slider.value != _saveData.SliderValue[number])
        //  {
        //     _saveData.SliderValue[number] = _slider.value;
        //  }
    }
}
