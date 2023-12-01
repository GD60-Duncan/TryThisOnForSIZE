using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private SaveData _saveData;

    [SerializeField] private Movement _movement;

    private int direction = 1;

    void Start()
    {
        //_movement.CanMove = false;
        GameData.playerMovement = _movement;
        GameData.PlayerObj = _movement.Rigidbody.gameObject;
        GameData.PlayerControl = this;
    }
    
    void Update()
    {
        if(_movement)
        {
            _movement.Move(GameData.CanInput, direction);
        }
       
       if(Input.GetKeyDown(_saveData.Left) && Input.GetKey(_saveData.Right) != true)
        {
            //if(direction == -1) return; 
            direction = -1;
            _movement.StartMove();
            return;
        }

        if(Input.GetKeyDown(_saveData.Right) && Input.GetKey(_saveData.Left) != true)
        {
           //if(direction == 1) return; 
            direction = 1;
            _movement.StartMove();
            return;
        }

        if(Input.GetKeyUp(_saveData.Left))
        {
            _movement.Stop();
            return;
        }

        if(Input.GetKeyUp(_saveData.Right))
        {
            _movement.Stop();
            return;
        }

        // if(Input.GetKeyDown(_saveData.Jump))
        // {
        //     _movement.Jump();
        // }

        

        
    }
}
