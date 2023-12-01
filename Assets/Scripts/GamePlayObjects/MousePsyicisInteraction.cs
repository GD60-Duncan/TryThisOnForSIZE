using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MousePsyicisInteraction : MouseInteraction
{
    [SerializeField] private bool Dragable;

    [Header("Scale")]

    [SerializeField] private bool Scaleable;

    [SerializeField] private float _minSize;

    [SerializeField] private float _maxSize;

    [Header("Other")]

    [SerializeField] private bool _unityEvent;

    [SerializeField] private Rigidbody2D _rigidbody2D;

    [SerializeField] private GameObject _highlight;

    protected override void OnMouseEnter()
    {
        _highlight.SetActive(true);
        _rigidbody2D.velocity = Vector2.zero;
        
        if(Dragable)
        {
            GameData.PickUpObjects.SetActiveObject(this.gameObject);
            _rigidbody2D.gravityScale = 0;

        }

        if(Scaleable)
        {
            GameData.ScaleObjects.SetActiveObject(this.gameObject);
            GameData.ScaleObjects.SetSizes(_maxSize,_minSize);
        }

    }

    void OnMouseExit()
    {
        DropObject();
        _highlight.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(GameData.PickUpObjects.obj == this.gameObject)
        {
            Debug.Log("Colision");
            //GameData.ScaleObjects.SetSizes(gameObject.transform.localScale.,_minSize);
        }
        
    }

    public virtual void DropObject()
    {
        GameData.PickUpObjects.DropObject();
        GameData.ScaleObjects.DropObject();

        _rigidbody2D.gravityScale = 1;
    }

    


}
