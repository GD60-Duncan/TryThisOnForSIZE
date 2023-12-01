using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Audio;
[CreateAssetMenu]
public class SoundData : ScriptableObject
{
    public AudioClip audioClip  {get; private set;}

    
    public float volume;
    public bool twoD;

    public int Priority = 128;

    [SerializeField] private string _audioPath;

    void OnEnable()
    {
        if(_audioPath == null)
        {
            return;
        }

        audioClip = Resources.Load<AudioClip>(_audioPath);
    }
    //[SerializeField] private AnimationCurve volumeCurve;

    //[SerializeField] private 
}
