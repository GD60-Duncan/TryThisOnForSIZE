using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    [SerializeField] private GameObject _fpsObj;
    void Start()
    {
        
    }

    public void ToggleFPS()
    {
        if(_fpsObj.activeInHierarchy)
        {
            _fpsObj.SetActive(false);
            return;
        }
        _fpsObj.SetActive(true);
    }
}
