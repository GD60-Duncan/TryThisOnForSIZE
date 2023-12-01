using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExtraOptions : MonoBehaviour
{
    [SerializeField] private GameObject _debugObject;

    [Header("Toggles")]

    [SerializeField] private Toggle _debugToggle;

    [SerializeField] private Toggle _helpToggle;

    [SerializeField] private Toggle _extraInfoToggle;

    [SerializeField] private Toggle _perfToogle;

    [SerializeField] private TMPro.TMP_Dropdown _fpsTrackingType;

    [SerializeField] private Toggle _resetToogle;

    [SerializeField] private SaveData _saveData;

    [Header("")]

    public static GameObject gameObjectInstance; 

    private static PlayerDebugOptions playerOptions;

    void Start()
    {
       _helpToggle.isOn = _saveData.Help; 
        
        ObjectToggle(_saveData.Info);

        _perfToogle.isOn = _saveData.PerformenceTracking;

        _extraInfoToggle.isOn = _saveData.ExtraInfo;
        
        _debugToggle.isOn = gameObjectInstance.activeInHierarchy;

        SetFPSTracking(_saveData.FPSTrackingType);

    }
    
    public void ObjectToggle(bool toogle)
    {
        if(gameObjectInstance == null)
        {
            gameObjectInstance = Instantiate(_debugObject);
            playerOptions = gameObjectInstance.GetComponent<PlayerDebugOptions>();
        }

        _fpsTrackingType.interactable = toogle;
        _extraInfoToggle.interactable = toogle;
        _perfToogle.interactable = toogle;

        _saveData.Info = toogle;

        gameObjectInstance.SetActive(toogle);
    }

    public void ExtraInfoToggle(bool toogle)
    {
        _saveData.ExtraInfo = toogle;
        playerOptions.DeviceInfoTextVisibility(toogle);
        
    }

    public void HelpToggle(bool toogle)
    {
        _saveData.Help = toogle;
    }

    public void PerfToggle(bool toggle) 
    {
        _saveData.PerformenceTracking = toggle;
        playerOptions.PerformenceVisibility(toggle);
    }

    public void SetFPSTracking(int index)
    {
        _saveData.FPSTrackingType = ((byte)index);
        playerOptions.FPSTextVisibility(true);
        if(index == 0)
        {
            playerOptions.LightWeightFPS.enabled = true;
            playerOptions.HeavyWeightFPS.enabled = false;
            return;
        }

        if(index == 1)
        {
            playerOptions.HeavyWeightFPS.enabled = true;
            playerOptions.LightWeightFPS.enabled = false;
            return;
        }

        playerOptions.LightWeightFPS.enabled = false;
        playerOptions.HeavyWeightFPS.enabled = false;
        playerOptions.FPSTextVisibility(false);
    }

}
