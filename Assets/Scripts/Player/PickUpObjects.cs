using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{

    private Vector3 mousePos;

    private Vector3 dragOffset;

    public GameObject obj;

    [SerializeField] private GameObject _pointObj;

    [SerializeField] private Sprite _icon;

    [SerializeField] private SpriteRenderer _rend;


    void Start()
    {
        GameData.PickUpObjects = this;
    }

    Vector3 GetMousePos()
    {
        GameData.ActiveCamera.orthographic = true;
        Debug.Log(Input.mousePosition);
        mousePos = GameData.ActiveCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        GameData.ActiveCamera.orthographic = false;

        _pointObj.transform.position = mousePos;
        
            
        return mousePos;
        

    }

    public void SetActiveObject(GameObject Object)
    {
        obj = Object;
        _rend.gameObject.SetActive(obj);
    }

    public void DropObject()
    {
        obj = null;
        _rend.gameObject.SetActive(obj);
    }

    public GameObject GetObject()
    {
        return obj;
    }





    // Update is called once per frame
    void Update()
    {

        if(obj == null) return;
        
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {

            dragOffset = obj.transform.position - GetMousePos();

            Debug.Log(":()");

            
        }

        if(Input.GetKeyUp(KeyCode.Mouse0))
        {
            DropObject();
        }
    }

    void FixedUpdate()
    {
        if(obj == null) return;

        if(Input.GetKey(KeyCode.Mouse0))
        {
            obj.transform.position = GetMousePos() + dragOffset;

            _rend.sprite = _icon;
            
        }

        Debug.Log("PP");


    }

}
