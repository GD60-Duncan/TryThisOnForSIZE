using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode, ImageEffectAllowedInSceneView]
public class RenderShaderToScreen : MonoBehaviour
{
    [SerializeField] private Material _mat;

    void OnRenderImage(RenderTexture scr, RenderTexture dest)
    {
        RenderTexture main = RenderTexture.GetTemporary(200, 200);
       
        Graphics.Blit(scr, dest, _mat);
    }
}
