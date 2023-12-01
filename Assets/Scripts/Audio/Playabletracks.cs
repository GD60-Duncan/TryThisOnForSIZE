using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Playabletracks
{
   public string _name;
   
   public AudioClip _clip;

   public float _volume;
   
    [Range(0f, 2f)]
   public float _multiplyer; 

   [HideInInspector]
   public AudioSource source;
}
