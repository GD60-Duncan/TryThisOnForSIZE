using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRenderLayer : MonoBehaviour
{
   [SerializeField] Renderer _render;
   [SerializeField] private string _layername; 
   [SerializeField] private int _order;

   void Awake()
   {
       _render.sortingLayerName = _layername;
       _render.sortingOrder = _order;
   }
}
