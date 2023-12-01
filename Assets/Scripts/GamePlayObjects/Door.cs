using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animation _animation;

    [SerializeField] private AudioSource _audioSource;

    private bool doorOpen;
    
    void OnTriggerEnter2D(Collider2D collider)
   {
      
       
       
       if (collider.gameObject.CompareTag("Player"))
       {
          GameData.InDoorway = true;
          if(doorOpen == false)
          {
            _animation.Play();
            doorOpen = true;
          }
       }
      
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
       {
          GameData.InDoorway = false;
       }
    }

    public void PlayAudio(AudioClip audio)
    {
       _audioSource.clip = audio;
       _audioSource.Play();
    }
}
