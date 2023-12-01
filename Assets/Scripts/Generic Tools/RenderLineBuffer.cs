using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LineData
{
    Transform[] point;
}

public class RenderLineBuffer : MonoBehaviour
{
    [SerializeField] private ComputeShader _compShader;

    [SerializeField] private Transform _points;

    private ComputeBuffer computeBuffer;
    
    
    void Awake()
    {
       computeBuffer = new ComputeBuffer(1, 6); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable()
    {
        computeBuffer.Release();
    }
}
