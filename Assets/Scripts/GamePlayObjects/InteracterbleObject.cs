using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteracterbleObject : MonoBehaviour
{
    
    public UnityEvent unityEvent;
    
    public void Interact()
    {
        unityEvent.Invoke();
    }
}
