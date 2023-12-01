using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScaleObjects : MonoBehaviour
{

    [Header("Player")]

    [SerializeField] private GameObject _playerRigid;

    [SerializeField] private Movement _movement;

    [SerializeField] private float _scaleSpeed;

    [SerializeField] private GameObject _pointObj;

    [SerializeField] private GameObject _scaleGuide;

    [SerializeField] private Sprite _icon;

    [SerializeField] private SpriteRenderer _rend;

    //For Mouse Speed

    [HideInInspector] public Vector3 mouseDelta = Vector3.zero;

    private Vector3 lastMousePosition = Vector3.zero;

    private float minSize;

    private float maxSize;
    
    private GameObject obj;

    private Vector3 mousePos;

    private Vector2 currentScale;

    private float currentX = 1;

    private float currentY = 1;

    private Vector3 distance;

    private Vector2 newScale;

    void Start()
    {
        GameData.ScaleObjects = this;
    }

    Vector3 GetMousePos()
    {
        GameData.ActiveCamera.orthographic = true;
        mousePos = GameData.ActiveCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        GameData.ActiveCamera.orthographic = false;

         _pointObj.transform.position = mousePos;

        return mousePos;
    }

    float MouseSpeed()
    {
        return mouseDelta.magnitude;
    }

    public void SetSizes(float maxsize, float minsize)
    {
        maxSize = maxsize;
        minSize = minsize;
    }

    public void SetActiveObject(GameObject Object)
    {
        obj = Object;
        _rend.sprite = _icon;
        _scaleGuide.SetActive(obj);
    }

    public void DropObject()
    {
        obj = null;
        _rend.sprite = _icon;
        _scaleGuide.SetActive(obj);

    }

     private void ScaleX()
     {

     }

     private void SetObjectScale()
     {
            Vector2 scaleLimit = new Vector2(Mathf.Clamp(newScale.x,minSize, maxSize), Mathf.Clamp(newScale.y,minSize, maxSize));



            
            if(obj == _playerRigid)
            {
                //Debug.Log(scaleLimit);
                _movement.ChangeScale(scaleLimit);
                return;
            }

            obj.transform.localScale = scaleLimit;
     }

     void Update()
     {
        if(obj == null) return;

         mouseDelta = Input.mousePosition - lastMousePosition;
 
        lastMousePosition = Input.mousePosition;

        Debug.Log(MouseSpeed());
     }

    void FixedUpdate()
    {
        if(obj == null) return;




        
        if(GameData.PickUpObjects.obj == null && Input.GetKey(KeyCode.Mouse0))
        {

            distance = obj.transform.position - GetMousePos();

            if(distance.x > 0.1)
            {
                currentX = -_scaleSpeed;
               
            }

            if(distance.x < -0.1)
            {
                currentX = _scaleSpeed;
                
            }

            if(distance.y > 0.1)
            {
                currentY = -_scaleSpeed;
                Debug.Log("Up");
            }

            if(distance.y < -0.1f)
            {
                currentY = _scaleSpeed;
                Debug.Log("Down");
            }

            else if(obj.transform.localScale.x == minSize && obj.transform.localScale.y == minSize )
            {
                newScale = obj.transform.localScale * 1.1f;
                Debug.Log("TrollDispar");
                SetObjectScale();
                return;
                
            }

            newScale = obj.transform.localScale += new Vector3(currentX, currentY);

            SetObjectScale();

        }
    }


}
