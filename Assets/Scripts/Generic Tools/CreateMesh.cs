using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMesh : MonoBehaviour
{
    public Mesh Mesh;

    public RenderType type;

    private MeshFilter filter;

    public enum RenderType
    {
        GameObject, Graphics,
    }


    void Start()
    {
        if(Mesh)
        {
            GenerateMesh();
        }
    }

    public void GenerateMesh()
    {
        Mesh = new Mesh();

        if(type == RenderType.GameObject)
        {
            GameObject gameObject = new GameObject("obj", typeof(MeshRenderer));
            gameObject.transform.localScale = this.gameObject.transform.position;
            filter = gameObject.AddComponent<MeshFilter>();

            if(Mesh == null) return;

            filter.mesh = Mesh;
            Debug.Log("BYE");
            
        }


    }

    
}
