using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    public Transform _respawnPoint {get; set;}

    [SerializeField] private Respawn _respawn;
    //[SerializeField] private PlayerControl _playerControl;
    [SerializeField] private Movement _movement;

    void Awake()
    {
        _respawnPoint = gameObject.transform;
        
    }

    public void Respawn()
    {
        // _respawn.ObjectRespawn(_respawnPoint, this.gameObject);
        // _playerControl.ResetLastDirection();
        // _playerControl.Move = false;
        // _movement.Stop();
    }


}
