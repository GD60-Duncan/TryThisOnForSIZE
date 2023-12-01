using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
//using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class GraphicsOptions : MonoBehaviour
{
    //[SerializeField] private PostProcessProfile _pProfle;

    [SerializeField] private SaveData _saveData;

    //[SerializeField] private SetProssesUIforCamera _setProcessUI;

    [Header("Toggles")]

    [SerializeField] private Toggle _grainToggle;

    [SerializeField] private Toggle _chromToggle;

    [SerializeField] private Toggle _lensToggle;

    [SerializeField] private Toggle _colorToggle;

    [SerializeField] private Toggle _bloomToggle;

    [SerializeField] private Toggle _scanToggle;

    [SerializeField] private Toggle _uipostToggle;

    [Header("Dropdown")]

    [SerializeField] private TMPro.TMP_Dropdown _antialising;

    // private Grain _grain;

    // private ChromaticAberration _chrom;

    // private ColorGrading _color;

    // private Bloom _bloom;

    void Start()
    {
        _grainToggle.isOn = _saveData.Grain;
        _chromToggle.isOn = _saveData.ChromaticAberration;
        _colorToggle.isOn = _saveData.ColorGrading;
        _uipostToggle.isOn = _saveData.UIPostProcess;

        GrainToggle(_saveData.Grain);
        ChromeToggle(_saveData.ChromaticAberration);
        ColorToggle(_saveData.ColorGrading);
        

        _antialising.value = _saveData.antiAliasing;
        
    }

        public void SetAntiasing(int option)
        {
            _saveData.antiAliasing = option;
            
            if(option == 0)
            {
                QualitySettings.antiAliasing = option;
                return;
            }

            if(option == 1)
            {
                QualitySettings.antiAliasing = 2;
                return;
            }

            if(option == 2)
            {
                QualitySettings.antiAliasing = 4;
                return; 
            }
            
             
        }

        public void UIPostToggle(bool toogle)
        {
            _saveData.UIPostProcess = toogle;
            //_setProcessUI.SetCanvasStuff();
        }



       public void GrainToggle(bool Toggle)
       {
            //   _grain = _pProfle.GetSetting<Grain>();

            //   if(_grain == null)
            //   {
            //       _pProfle.AddSettings<Grain>();
            
            //   }

            //   _grain.enabled.value = Toggle;
            //   _saveData.Grain = Toggle;
              
       }

       public void ChromeToggle(bool Toggle)
       {
        //    _chrom = _pProfle.GetSetting<ChromaticAberration>();

        //       if(_chrom == null)
        //       {
        //           _pProfle.AddSettings<ChromaticAberration>();
        //       }

        //       _chrom.enabled.value = Toggle;
        //       _saveData.ChromaticAberration = Toggle;
       }

       public void ColorToggle(bool Toggle)
       {
        //    _color = _pProfle.GetSetting<ColorGrading>();

        //       if(_color == null)
        //       {
        //           _pProfle.AddSettings<ColorGrading>();
        //       }

        //       _color.enabled.value = Toggle;
        //       _saveData.ColorGrading = Toggle;
       }
}
