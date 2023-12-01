using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UseEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _event;

    [SerializeField] private bool _useOnStart;
    
    void Start()
    {
        if(_useOnStart)
        {
            Use_Event();
        }
    }

    public void Use_Event()
    {
        _event.Invoke();
    }
}
