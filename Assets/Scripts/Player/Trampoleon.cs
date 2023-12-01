using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoleon : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameData.playerMovement.MegaJump();
        Debug.Log("enter");
        _audioSource.Play();
    }

    
}
