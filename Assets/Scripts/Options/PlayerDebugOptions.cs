using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Threading.Tasks;
using TMPro;

public class PlayerDebugOptions : MonoBehaviour
{
    public static PlayerDebugOptions Instance {get; private set;} 
    
    private float fps;

    private float frames;
    [SerializeField] private TMPro.TMP_Text _fpsText;
    [SerializeField] private TMPro.TMP_Text _resText;
    [SerializeField] private TMPro.TMP_Text _graphicsText;
    [SerializeField] private TMPro.TMP_Text _perfText;
    [SerializeField] private int _uiUpdatefrequency;

    public LightWeightFPS LightWeightFPS;
    public HeavyWeightFPS HeavyWeightFPS;
    
    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }

        Destroy(this);
        
        
    }


    public void UpdateFPSText(string text)
    {
        StringBuilder sb = new StringBuilder(); 
        sb.AppendLine("Resolution:");
        sb.Append(Screen.currentResolution);
        
        _fpsText.text = text;
        _resText.text = sb.ToString();

        
    }

    public void UpdatePerfText(string text)
    {
        _perfText.text = text;
    }

    public void UpdateDeviceText(string text)
    {
        _graphicsText.text = text;
    }

    public void FPSTextVisibility(bool vis)
    {
        _fpsText.enabled = vis;
    }

    public void DeviceInfoTextVisibility(bool vis)
    {
        _graphicsText.enabled = vis;
    }

    public void PerformenceVisibility(bool vis)
    {
        _perfText.enabled = vis;
    }
}
