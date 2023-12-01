using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
using TMPro;

public class DisplayOptions : MonoBehaviour
{
    //[SerializeField] private PostProcessProfile _pProfle;

    [SerializeField] private SaveData _saveData;
    
    [Header("Toggles")]
    [SerializeField] private Toggle _vSyncToggle;
    [SerializeField] private Toggle _fpsToggle;

    private FullScreenMode screenMode;

    //private AutoExposure _brightness;
    //private ColorGrading _colorGrading;

    public List<Resolutions> resolution;
    [Header("Text")]
    [SerializeField] private TMPro.TMP_Dropdown _resolutionDimentions;
    [SerializeField] private TMPro.TMP_Dropdown _displayType;

    [Header("Sliders")]
    [SerializeField] private Slider _brightnessSlider;
    [SerializeField] private Slider _gammaSlider;
    
    void Start()
    {
        // _brightness = _pProfle.GetSetting<AutoExposure>();
        // _colorGrading = _pProfle.GetSetting<ColorGrading>();

        // SetBrightnessSlider(_saveData.DisplayValue[0]);
        // SetGammaSlider(_saveData.DisplayValue[1]);

        CalculateRecomendedSizes();
    }

    private void ScreenOptions(int mode)
    {
        if (mode == 0)
        {
            screenMode = FullScreenMode.ExclusiveFullScreen; return;
        }

        if (mode == 1)
        {
            screenMode = FullScreenMode.Windowed; return;
        }

        screenMode = FullScreenMode.FullScreenWindow;

    }

    private void CalculateRecomendedSizes()
    {
        if(Screen.height == 0)
        {
            Screen.SetResolution(1200, 800, Screen.fullScreen);
        }
        
        
        // resolution[0].height = GameData.ScreenHeight * 2;
        // resolution[0].width = GameData.ScreenWidth * 2;
        // _resolutionDimentions.options[0].text = (resolution[0].width + "x" + resolution[0].height);
        
        
        // for (int i = resolution.Capacity - 1; i >= 1; i--)
        // {
        //     resolution[i].height = GameData.ScreenHeight / i;
        //     resolution[i].width = GameData.ScreenWidth / i;
        //     _resolutionDimentions.options[i].text = (resolution[i].width + "x" + resolution[i].height);
        // }

        _resolutionDimentions.value = 1;
        
    }

    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;

        Screen.SetResolution(resolution[index].width, resolution[index].height, fullscreen);
    }

    public void Vertical(bool active)
    {
        if(active) {QualitySettings.vSyncCount = 1; return;}

        QualitySettings.vSyncCount = 0;
       
        
    }

    public void SetResolution(int index)
    {
        ScreenOptions(index);
    }

    public void SetBrightnessSlider(float value)
    {
        //_saveData.DisplayValue[0] = value;

        _brightnessSlider.value = value;

        //_brightness.keyValue.value = value;
    }

    public void SetGammaSlider(float value)
    {
        //_saveData.DisplayValue[1] = value;
        
        _gammaSlider.value = value;

        //_colorGrading.contrast.value = value;
    }
}
