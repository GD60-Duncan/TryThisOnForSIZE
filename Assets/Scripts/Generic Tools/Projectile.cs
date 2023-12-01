using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigid;

    [SerializeField] private SpriteRenderer _renderer;

    [Header("Varibles")]
    
    public bool InvertDirection;

    public float StartVelocity;

    public bool Continous;

    public float FallSpeed;

    private float dirRef;


    void Start()
    {
        _rigid.gravityScale = FallSpeed;

        dirRef = InvertDirection ? -1 : 1;

        _rigid.drag = Continous ? 0 : 1;

        _rigid.AddForce(Vector2.right * StartVelocity * dirRef, ForceMode2D.Impulse);

        

        
    }

    public void SetSprite(Sprite sprite)
    {
        _renderer.sprite = sprite;
    }


    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
