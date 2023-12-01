using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectMovement : MonoBehaviour
{
     private Rigidbody2D _rigidbody;

    private float _inputDirection;

    [SerializeField] private float _bulletSpeed;

    [SerializeField] Sprite _sprite;
    
    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void Stop()
    {
        _rigidbody.velocity = Vector2.zero;
    }



    void Start()
    {
         //_inputDirection = _animationControl.transform.localScale.x;
        _rigidbody.velocity = transform.right *_bulletSpeed;
        
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
