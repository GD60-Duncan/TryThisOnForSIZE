using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAtCertainHeight : MonoBehaviour
{
    private GameObject _self;

    [SerializeField] private float _killHeight;

    private Vector2 _v;
    
    void Start()
    {
        _self = this.gameObject;
    }

    void FixedUpdate()
    {
        if(_self.transform.position.y > _killHeight)
        return;

        Destroy(_self);
    }
}
