using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventAtCertainHeight : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] private UnityEvent _event;
     [SerializeField] private GameObject _object;

     [SerializeField] private float _height;

    void FixedUpdate()
    {
        if(_object.transform.position.y > _height)
        return;

        _event.Invoke();
    }
}
