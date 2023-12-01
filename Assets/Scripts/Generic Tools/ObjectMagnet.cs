using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMagnet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;

    private GameObject _player;

    void Start()
    {
        _player = GameData.PlayerObj;
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
         if(other.CompareTag("Player"))
         {
             if(transform.position.x > _player.transform.position.x)
                {
                    _rigidbody.velocity = transform.right * _speed * -1;
                }

                if(transform.position.x < _player.transform.position.x)
                {
                     _rigidbody.velocity = transform.right * _speed;
                }
         }
    }

    void OnTriggerExit2D(Collider2D other)
    {
         if(other.CompareTag("Player"))
         {
             _rigidbody.velocity = Vector2.zero;
         }
    }
}
