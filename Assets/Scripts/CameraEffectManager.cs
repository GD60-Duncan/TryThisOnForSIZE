using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffectManager : MonoBehaviour
{
    [SerializeField] private RenderShaderToScreen _shutterSpeed;
    [SerializeField] private SaveData _saveData;

    [SerializeField] private SpriteRenderer _bloodScreen;

    private Color color;


    void Start()
    {
        GameData.CameraEffectManager = this;
    }

    public void ToogleShutterSpeed(bool toggle)
    {
        _shutterSpeed.enabled = toggle;
    }

    public void BloodToggle(bool enabled)
    {
        _bloodScreen.enabled = enabled;
    }

    public void UpdateScreenEffect()
    {
        if(_saveData.CurrentHealth > 10 || _saveData.CurrentHealth == 0) return;
        
        color = new Color(100,100,100,Mathf.Abs((float)_saveData.CurrentHealth / 10 - 1) + 0.1f);

        _bloodScreen.color = color;

        _bloodScreen.enabled = true;
    }

    public void BloodScreenColorOveride(float r, float g, float b, float a)
    {
        color = new Color(r,g,b,a);

        _bloodScreen.color = color;
    }

   
}
