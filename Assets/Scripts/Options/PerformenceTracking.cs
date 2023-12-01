using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Profiling;

public class PerformenceTracking : MonoBehaviour
{
    [SerializeField] private PlayerDebugOptions _options;

    public float AllocatedRam { get; private set; }
    public float ReservedRam { get; private set; }
    public float MonoRam { get; private set; }

    private StringBuilder _stringBuilder;

    void Awake()
    {
        _stringBuilder = new StringBuilder();
    }

    void Update()
    {
        AllocatedRam = Profiler.GetTotalAllocatedMemoryLong()/ 1048576f;
        ReservedRam  = Profiler.GetTotalReservedMemoryLong() / 1048576f;
        MonoRam      = Profiler.GetMonoUsedSizeLong()        / 1048576f;
        
        _stringBuilder.Append("Game Memory Usage ");
        _stringBuilder.Append((AllocatedRam/SystemInfo.systemMemorySize*100).ToString("n4"));
        _stringBuilder.Append("% ");
        _stringBuilder.Append(AllocatedRam);
        _stringBuilder.Append(" MB / ");
        _stringBuilder.Append(SystemInfo.systemMemorySize);
        _stringBuilder.Append("MB");
        _options.UpdatePerfText(_stringBuilder.ToString());
        _stringBuilder.Clear();

    }
}