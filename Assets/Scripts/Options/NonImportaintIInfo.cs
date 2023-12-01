using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class NonImportaintIInfo : MonoBehaviour
{
    [SerializeField] private PlayerDebugOptions _options;

    private StringBuilder _stringBuilder;

    void Awake()
    {
        _stringBuilder = new StringBuilder();
    }

    void OnEnable()
    {
        _stringBuilder.Clear();
        _stringBuilder.AppendLine("System Info:");
        _stringBuilder.AppendLine(SystemInfo.operatingSystem);
        _stringBuilder.AppendLine(SystemInfo.graphicsDeviceName);
        _stringBuilder.AppendLine(SystemInfo.graphicsDeviceVersion);
        _stringBuilder.AppendLine(SystemInfo.processorType);

        _options.UpdateDeviceText(_stringBuilder.ToString());
    }
    
}
