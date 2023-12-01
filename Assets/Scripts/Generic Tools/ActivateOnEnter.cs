using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateOnEnter : MonoBehaviour
{
  
  [SerializeField] private GameObject _activateObject;

  [HideInInspector]
  public bool _isActavated;

  [SerializeField] private bool _deactivate; 
  [SerializeField] private bool _destroy;

  [SerializeField] private bool _useOnce;
  
  void OnEnable()
     {
        _isActavated = false;
     }
  
  
   private void OnTriggerEnter2D(Collider2D collider)
   {
      
       
       
       if (collider.gameObject.CompareTag("Player"))
       {
          if (_isActavated ==  true)
            {
               return;
            }

      if(_useOnce == true)
      {
         _isActavated = true;
      }

          _activateObject.SetActive(true);

          if(_deactivate == true)
          {
            this.gameObject.SetActive(false);
          }

          if(_destroy == true)
          {
             Destroy(this);
          }

       }

       else
       {
    
       }
   }
}
