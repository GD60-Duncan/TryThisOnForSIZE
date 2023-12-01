using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManger : MonoBehaviour
{
    [SerializeField] private ObjectType _objectType;

    [HideInInspector]
    public ObjectType PublicType;
    
    void Awake()
    {
        _objectType = PublicType;
    }
}
