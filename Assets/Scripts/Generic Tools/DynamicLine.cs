using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DynamicLine : MonoBehaviour
{
    private Graphics graphics;

    public Mesh _mesh;

    [SerializeField] private Material _mat;

    [SerializeField] private float _lineWidth;

    [SerializeField] private Transform _pos;

    [SerializeField] private Vector3 _start;

    [SerializeField] private Vector3 _end;

    [SerializeField] private Matrix4x4 test;

    [SerializeField] private Mesh testMesh;

    private Vector3[] pos;

    //private 

    
    void _Start()
    {
        CreateLine();
    }

    void OnPostRender()
    {
        //RenderLine();
    }

    public void CreateLine()
    {
        Vector3 normal = Vector3.Cross(_start, _end);
        Vector3 side = Vector3.Cross(normal, _end-_start);
        side.Normalize();
        Vector3 a = _start + side * (_lineWidth / 2);
        Vector3 b = _start + side * (_lineWidth / -2);
        Vector3 c = _end + side * (_lineWidth / 2);
        Vector3 d = _end + side * (_lineWidth / -2);

        testMesh = new Mesh();

        //testMesh.name = ":)";

        pos = new Vector3[4];

        pos[0] = a;
        pos[1] = b;
        pos[2] = c;
        pos[3] = d;

        testMesh.vertices = pos; 

        testMesh.triangles = new int[5];

        testMesh.triangles[0] = 0;
        testMesh.triangles[1] = 1;
        testMesh.triangles[2] = 2;
        testMesh.triangles[3] = 0;
        testMesh.triangles[4] = 1;
        testMesh.triangles[5] = 2;

        



        

        //pos = new Vector3()



        
    }

    public void RenderLine()
    {
        _mat.SetPass(0);
        
        Graphics.DrawMeshNow(_mesh, _pos.position, Quaternion.identity);
    } 
}
