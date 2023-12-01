using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColLayer : MonoBehaviour
{
   [SerializeField] private LayerMask _layerafterDeath;

   public void ChangeLayer(int amount)
   {
       this.gameObject.layer = amount;
   }
}
